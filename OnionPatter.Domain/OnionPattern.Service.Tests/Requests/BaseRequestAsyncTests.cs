﻿using FakeItEasy;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnionPattern.Domain.Repository;
using System;

namespace OnionPattern.Service.Tests.Requests
{
    public class BaseRequestAsyncTests
    {
        [TestClass]
        public class ConstructorTests
        {
            private IRepositoryAsync<FakeEntity> fakeRepository;
            private IRepositoryAsyncAggregate fakeRepositoryAggregate;

            [TestInitialize]
            public void TestInitialize()
            {
                fakeRepository = A.Fake<IRepositoryAsync<FakeEntity>>();
                fakeRepositoryAggregate = A.Fake<IRepositoryAsyncAggregate>();
            }

            [TestCleanup]
            public void TestCleanup()
            {
                Fake.ClearConfiguration(fakeRepository);
                Fake.ClearConfiguration(fakeRepositoryAggregate);
            }

            [TestMethod]
            public void RepositoryIsNull()
            {
                Action ctor = () => new MockBaseRequestAsync(null, fakeRepositoryAggregate);
                ctor.ShouldThrow<ArgumentNullException>()
                    .WithMessage($"Value cannot be null.{Environment.NewLine}Parameter name: repository cannot be null.");
            }

            [TestMethod]
            public void RepositoryAggregateIsNull()
            {
                Action ctor = () => new MockBaseRequestAsync(fakeRepository, null);
                ctor.ShouldThrow<ArgumentNullException>()
                    .WithMessage($"Value cannot be null.{Environment.NewLine}Parameter name: repositoryAggregate cannot be null.");
            }

            [TestMethod]
            public void IsValid()
            {
                var baseRequest = new MockBaseRequestAsync(fakeRepository, fakeRepositoryAggregate);

                baseRequest.Should().NotBeNull();
                baseRequest.Should().BeAssignableTo<BaseServiceRequestAsync<FakeEntity>>();
                baseRequest.Should().BeOfType<MockBaseRequestAsync>();
            }
        }
    }


}
