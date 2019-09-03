using AutoMapper;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebRelayer.DomainModels;
using WebRelayer.DomainModels.Communication;
using WebRelayer.Entities;
using WebRelayer.Repositories;
using WebRelayer.SignalRHub;
using WebRelayer.WebClientModels;

namespace WebRelayer.Services
{
    public class RelayService:IRelayService
    {
        private ISubscriptionDataRepository _repository;
        private IEmployeeArrivalRepository _employeeArrivalRepository;
        private ILogger _logger;
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        private IConnectionStoreService _connectionStore;
        private INotificationService _notificationService;
        private IEmployeeRepository _employeeRepository;

        public RelayService(ISubscriptionDataRepository repository, 
            IEmployeeArrivalRepository employeeArrivalRepository, 
            ILogger<RelayService> logger, 
            IUnitOfWork unitOfWork, 
            IMapper mapper,
            IConnectionStoreService connectionStoreService,
            INotificationService notificationService,
            IEmployeeRepository employeeRepository)
        {
            _repository = repository;
            _employeeArrivalRepository = employeeArrivalRepository;
            _logger = logger;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _connectionStore = connectionStoreService;
            _notificationService = notificationService;
            _employeeRepository = employeeRepository;
        }

        private async Task<bool> IsTokenValidAsync(string token)
        {
            try
            {
                var tokenData = await _repository.GetByTokenAsync(token);

                if (tokenData == null || tokenData.ValidTo < DateTime.UtcNow)
                {
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, string.Empty);
                return false;
            }
        }

        public async Task<BaseResponse> RelayAsync(IEnumerable<EmployeeArrivalInformationModel> data, string token)
        {
            try
            {
                var isValidToken = await IsTokenValidAsync(token);

                if (!isValidToken)
                    return BaseResponse.Fail("Provided token is not valid", System.Net.HttpStatusCode.Unauthorized);

                await _employeeArrivalRepository.AddRangeAsync(_mapper.Map<IEnumerable<EmployeeArrival>>(data));
                await _unitOfWork.SaveChangesAsync();

                var employees = await _employeeRepository.ListByIdsAsync(data.Select(d => d.EmployeeId));

                var employeeArrivalDictionary = data.ToDictionary(e => e.EmployeeId, e => e.When);

                var employeesJsonArr = employees.Select(e => new EmployeeArrivalJsonObject()
                {
                    Name = e.FirstName,
                    SurName = e.Surname,
                    When = employeeArrivalDictionary[e.Id].ToString("dd-MM-yyyy hh:mm:ss")
                }).ToList();

                var json = JsonConvert.SerializeObject(employeesJsonArr);
                
                await _notificationService.NotifyClient(json, _connectionStore.Get(token));

                return BaseResponse.Ok();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, string.Empty);
                return BaseResponse.Fail(string.Empty, System.Net.HttpStatusCode.InternalServerError);
            }
                
        }
    }
}
