using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Project.App.MainObject1Module
{
    public class MainObject1GetRequest : IRequest<List<MainObject1>>
    {
    }

    public class MainObject1GetRequestHandler : IRequestHandler<MainObject1GetRequest, List<MainObject1>>
    {
        public async Task<List<MainObject1>> Handle(MainObject1GetRequest request, CancellationToken cancellationToken)
        {
            return new List<MainObject1>
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
        }
    }
}