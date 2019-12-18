using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
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

        public MainObject1CreateRequestHandler(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<MainObject1Response> Handle(MainObject1CreateRequest request, CancellationToken cancellationToken)
        {
            var domainObject = _mapper.Map<MainObject1>(request.Model);
            return _mapper.Map<MainObject1Response>(domainObject);
        }
    }
}