using AutoMapper;
using Microsoft.Extensions.Caching.Memory;
using Moq;
using ParkingProject.Application.Services;
using ParkingProject.Domain.Interfaces;
using ParkingProject.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ParkingProject.Tests
{
    public class GarageServiceTest
    {
        [Fact]
        public void GetGarages_NotExistingGarages_ResultShouldBeEmpty()
        {
            // arange
            var mockGarageRepositoty = new Mock<IGarageRepository>();
            var mockMapper = new Mock<IMapper>();
            var mockMemoryCache = new Mock<IMemoryCache>();
            var mockCarRepository = new Mock<ICarRepository>();

            //act
            var garageService = new GarageService(mockGarageRepositoty.Object, mockCarRepository.Object, mockMemoryCache.Object, mockMapper.Object);
            var result = garageService.GetGarages();

            //assert
            Assert.IsType<IEnumerable<Garage>>(result);
        }
    }
}
