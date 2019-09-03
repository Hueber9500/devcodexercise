using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebRelayer.Services;
using WebRelayer.WebClientModels;

namespace WebRelayer.Controllers
{
    [ApiController]
    public class SubscriptionController:ControllerBase
    {
        private ISubscriptionService _subscriptionService;
        private IRelayService _relayService;
        private IMapper _mapper;

        public SubscriptionController(ISubscriptionService subscriptionService, IRelayService relayService, IMapper mapper)
        {
            _subscriptionService = subscriptionService;
            _relayService = relayService;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("/api/subscribe")]
        public async Task<IActionResult> SubscribeAsync(SubscriptionRequestModel request)
        {
            var relayUrl = Url.Link("Relay", null);

            var model = new DomainModels.SubscriptionModel()
            {
                CallbackUrl = relayUrl,
                ShortDate = DateTime.Now,
                SignalRConnectionId = request.ConnectionId
            };

            var result = await _subscriptionService.SubscribeAsync(model);

            if (result)
                return Ok();
            else
                return StatusCode((int)result);
        }

        [HttpPost]
        [Route("/api/relay", Name = "Relay")]
        public async Task<IActionResult> RelayAsync([FromHeader(Name = "X-Alaric-Token")] string token, [FromBody]IEnumerable<AlaricMonitorRelayRequestModel> model)
        {
            var data = _mapper.Map<IEnumerable<DomainModels.EmployeeArrivalInformationModel>>(model);
            var result = await _relayService.RelayAsync(data, token);

            if(!result)
            {
                return StatusCode((int)result);
            }

            return Ok();
        }
    }
}
