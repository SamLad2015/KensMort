using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pertemps.Dtos;
using Pertemps.Services;
using Pertemps.v1.Controllers;
using Xunit;

namespace Pertemps.Tests
{
    public class RestaurantControllerTest
    {
        private CandidateListingController _controller;
        private ICandidateService _service;
        
        public RestaurantControllerTest()
        {
            _service = new CandidateServiceFake();
            _controller = new CandidateListingController(_service);
        }
        
        [Fact]
        public void GetAll_WhenCalled_ReturnsOkResult()
        {
            var okResult = _controller.GetAllItems(ApiVersion.Default);
            Assert.IsType<OkObjectResult>(okResult);
        }
        
        [Fact]
        public async Task GetAll_WhenCalled_ReturnAllCandidates()
        {
            var result = _service.GetAll();
            Assert.Equal(3, result.Result.Count());
        }

        [Fact]
        public async Task AddCandidate_WhenPosted_WithCandidate_ReturnOkStatus()
        {
            await _service.AddCandidate(new CandidateRequestDto
            {
                Name = "test 4",
                Position = "test position for 4",
                Contract = true,
                Available = false,
                Match = 5
            });
            var result = _service.GetAll();
            Assert.Equal("test 4", result.Result
                .FirstOrDefault(r => r.Name=="test 4")?
                .Name);
        }
        
        [Fact]
        public async Task UpdateCandidate_WhenPosted_WithCandidate_ReturnOkStatus()
        {
            _service.UpdateCandidate(3, new CandidateRequestDto
            {
                Name = "test  changed",
                Position = "new position for 3",
                Contract = true,
                Available = false,
                Match = 4
            });
            var result = _service.GetAll();
            Assert.Equal("test  changed", result.Result
                .FirstOrDefault(c => c.Id == 3)?
                .Name);
        }
        
        [Fact]
        public async Task DeleteCandidate_WhenDeleted_WithCandidateId_ReturnOkStatus()
        {
            var prevResult = _service.GetAll();
            Assert.Equal(3, prevResult.Result.Count());
            
            _service.DeleteCandidate(1);
            var result = _service.GetAll();
            Assert.Equal(3, result.Result.Count());
        }
    }
}