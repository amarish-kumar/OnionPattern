﻿using System;
using System.Linq;
using OnionPattern.Domain.DataTransferObjects.Platform;
using OnionPattern.Domain.Repository;
using OnionPattern.Domain.Services.Requests.Platform;
using Serilog;

namespace OnionPattern.Service.Requests.Platform
{
    public class GetAllPlatformsRequest : BaseServiceRequest<Domain.Entities.Platform>, IGetAllPlatformsRequest
    {
        public GetAllPlatformsRequest(IRepository<Domain.Entities.Platform> repository, IRepositoryAggregate repositoryAggregate) : base(repository, repositoryAggregate) {}

        #region Implementation of IGetAllPlatformsRequest

        public PlatformListResponseDto Execute()
        {
            Log.Logger.Information("Retrieving Platform List...");
            var platformListResponse = new PlatformListResponseDto();
            try
            {
                var platforms = Repository.GetAll()?.ToArray();
                if (platforms == null || !platforms.Any()) { throw new Exception("No Platforms Returned."); }
                platformListResponse.Platforms = platforms;
                platformListResponse.StatusCode = 200;
                Log.Logger.Information($"Retrieved [{platformListResponse.Platforms.Count()}] Platforms.");
            }
            catch (Exception x)
            {
                Log.Logger.Information($"Failed to get Platforms List. [{x.Message}].");
                HandleErrors(platformListResponse, x);
            }
            return platformListResponse;
        }

        #endregion
    }
}
