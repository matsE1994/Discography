using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Project.App.MainObject1Module.Contracts;

namespace Project.App.MainObject1Module
{
    public class MainObject1CreateRequest : IRequest<MainObject1Response>
    {
        public MainObject1CreateRequest(MainObject1CreateModel model)
        {
            Model = model;
        }

        public MainObject1CreateModel Model { get; set; }
    }

    public class MainObject1CreateRequestHandler : IRequestHandler<MainObject1CreateRequest, MainObject1Response>
    {
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public MainObject1CreateRequestHandler(IMapper mapper, ILogger<MainObject1CreateRequestHandler> logger)
        {
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<MainObject1Response> Handle(MainObject1CreateRequest request,
            CancellationToken cancellationToken)
        {
            var domainObject = _mapper.Map<MainObject1>(request.Model);
            var responseObject = _mapper.Map<MainObject1Response>(domainObject);

            _logger.LogDebug($"Object with id {responseObject.Id} was created");
            return responseObject;
        }
    }
}