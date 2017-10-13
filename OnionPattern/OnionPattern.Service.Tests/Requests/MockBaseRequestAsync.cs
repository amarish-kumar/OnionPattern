﻿using OnionPattern.Domain.Repository;
using Serilog;

namespace OnionPattern.Service.Tests.Requests
{
    public class MockBaseRequestAsync : BaseServiceRequestAsync<FakeEntity>
    {
        public MockBaseRequestAsync(IRepositoryAsync<FakeEntity> repository, IRepositoryAsyncAggregate repositoryAggregate, ILogger logger) 
            : base(repository, repositoryAggregate, logger) { }
    }
}