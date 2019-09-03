using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebRelayer.Helpers;
using WebRelayer.Repositories;
using WebRelayer.WebClientModels;

namespace WebRelayer.Controllers
{
    [ApiController]
    public class EmployeeArrivalHistoryController : ControllerBase
    {
        private IEmployeeArrivalRepository _repository;
        private IMapper _mapper;

        public EmployeeArrivalHistoryController(IEmployeeArrivalRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // GET: api/EmployeeArrivalHistory
        [HttpGet]
        [Route("/api/history")]
        public async Task<IActionResult> Get([FromQuery]EmployeeHistoryResourceParameters parameters)
        {
            var data = await _repository.ListEmployeeArrivalsHistoryAsync(parameters);

            var metaDataPagination = new
            {
                totalCount = data.TotalCount,
                pageSize = data.PageSize,
                totalPages = data.TotalPages,
                currentPage = data.CurrentPage
            };

            //Response.Headers.Add("Access-Control-Allow-Origin", "*");
            //Response.Headers.Add("Access-Control-Allow-Methods", "POST, GET");
            Response.Headers.Add("Custom-Header", "X-Pagination");
            //Response.Headers.Add("Access-Control-Expose-Headers", "X-Pagination");
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metaDataPagination));
            
            var resultData = _mapper.Map<IEnumerable<EmployeeHistoryResponseModel>>(data);
            return Ok(resultData);
        }
    }
}
