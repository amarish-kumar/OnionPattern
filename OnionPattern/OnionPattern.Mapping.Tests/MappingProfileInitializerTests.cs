﻿using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OnionPattern.Mapping.Tests
{
    [TestClass]
    public class MappingProfileInitializerTests
    {
        [TestMethod]
        public void MappingProfilesAreValid()
        {
            Action method = () => MappingProfileInitilizer.ConfigureMappings();
            method.Should().NotThrow();
        }
    }
}
