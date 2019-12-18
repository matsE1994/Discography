using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Project.App.MainObject1Module.Contracts;

namespace Project.App.MainObject1Module
{
    public class MainObject1GetRequest : IRequest<List<MainObject1Response>>
    {
    }

    public class MainObject1GetRequestHandler : IRequestHandler<MainObject1GetRequest, List<MainObject1Response>>
    {
        private readonly IMapper _mapper;

        public MainObject1GetRequestHandler(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<List<MainObject1Response>> Handle(MainObject1GetRequest request, CancellationToken cancellationToken)
        {
            var domainObjects = new List<MainObject1>
            {
                new MainObject1
                {
                    Id = Guid.NewGuid(),
                    Message = "hello world1"
                },
                new MainObject1
                {
                    Id = Guid.NewGuid(),
                    Message = "hello world2"
                }
            };
            var responseObjects = _mapper.Map<List<MainObject1Response>>(domainObjects);

            return responseObjects;
        }
    }
}