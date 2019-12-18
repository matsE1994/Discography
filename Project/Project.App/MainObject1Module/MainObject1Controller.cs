using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project.App.Common;
using Project.App.MainObject1Module.Contracts;

namespace Project.App.MainObject1Module
{
    [Controller]
    public class MainObject1Controller : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public MainObject1Controller(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet(ApiRoutes.MainObject1.Get)]
        public async Task<IActionResult> Get()
        {
            var domainObjects = await _mediator.Send(new MainObject1GetRequest());
            var responseObjects = _mapper.Map<List<MainObject1Response>>(domainObjects);
            return Ok(responseObjects);
        }

        [HttpPost(ApiRoutes.MainObject1.Post)]
        public async Task<IActionResult> Post([FromBody] MainObject1CreateModel model)
        {
            var responseObject = await _mediator.Send(new MainObject1CreateRequest(model));
            return StatusCode(201, responseObject);
        }
    }
}