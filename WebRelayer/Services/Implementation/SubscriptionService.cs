using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WebRelayer.DomainModels;
using WebRelayer.DomainModels.Communication;
using WebRelayer.Repositories;
using WebRelayer.WebClientModels;

namespace WebRelayer.Services
{
    public class SubscriptionService : ISubscriptionService
    {
        private ISubscriptionDataRepository _repository;
        private IConfiguration _configuration;
        private IHttpClient _httpClient;
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        private ILogger _logger;
        private IConnectionStoreService _connectionStore;

        public SubscriptionService(
            ISubscriptionDataRepository repository, 
            IConfiguration configuration, 
            IHttpClient httpClient,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            ILogger<SubscriptionService> logger,
            IConnectionStoreService connectionStore)
        {
            _repository = repository;
            _configuration = configuration;
            _httpClient = httpClient;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
            _connectionStore = connectionStore;
        }

        public async Task<BaseResponse> SubscribeAsync(SubscriptionModel subscriptionModel)
        {
            try
            {
                string requestUrl =
                    $"{_configuration["WebService:url"]}" +
                    $"?date={subscriptionModel.ShortDate.ToString("yyyy-MM-dd")}" +
                    $"&callback={subscriptionModel.CallbackUrl}";

                var responseObject = await _httpClient.SendGetAsync<AlaricMonitorResponseModel>(requestUrl);

                var domainModel = _mapper.Map<SubscirptionDataModel>(responseObject);
                var entityModel = _mapper.Map<Entities.SubscriptionData>(domainModel); 

                await _repository.AddAsync(entityModel);
                await _unitOfWork.SaveChangesAsync();

                _connectionStore.Add(domainModel.Token, subscriptionModel.SignalRConnectionId);

                return BaseResponse.Ok();
            }
            catch(HttpRequestException httpEx)
            {
                _logger.LogError(httpEx, "When making http request");
                return BaseResponse.Fail("Error when making http request", System.Net.HttpStatusCode.BadGateway);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "SubscriptionService");
                return BaseResponse.Fail("Error in internal service", System.Net.HttpStatusCode.InternalServerError);
            }
        }
    }
}
