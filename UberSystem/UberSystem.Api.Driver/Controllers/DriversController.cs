﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UberSystem.Domain.Contracts.Services;
using UberSystem.Dto;
using UberSystem.Dto.Helpers;
using UberSystem.Dto.Requests;
using UberSystem.Dto.Responses;

namespace UberSystem.Api.Driver.Controllers
{
    [Route("api/uber-system")]
    [ApiController]
    public class DriversController(IDriverService driverService, IMapper mapper) : ControllerBase
    {
        private readonly IDriverService _driverService = driverService;
        private readonly IMapper _mapper = mapper;

        /// <summary>
        /// Get drivers with pagination
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("drivers/pageNumer/{pageNumber}/pageSize/{pageSize}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ApiResponseModel<PagedResponse<UserResponseModel>>>> GetDrivers(int pageNumber = 1, int pageSize = 10)
        {
            var drivers = _mapper.Map<IList<UserResponseModel>>(await _driverService.GetDrivers());
            if (!drivers.Any()) return NotFound(new ApiResponseModel<string>
            {
                StatusCode = System.Net.HttpStatusCode.NotFound,
                Message = "No data for drivers!"
            });
            var response = PaginationHelper.GetPagedResponse(drivers.AsQueryable(), pageNumber, pageSize);
            return Ok(new ApiResponseModel<PagedResponse<UserResponseModel>>
            {
                StatusCode = System.Net.HttpStatusCode.OK,
                Message = "Drivers fetched successfully!",
                Response = response
            });
        }

        /// <summary>
        /// Get driver by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("drivers/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ApiResponseModel<UserResponseModel>>> GetDriver(Guid id)
        {
            var driver = await _driverService.GetDriverById(id);
            if (driver is null) return NotFound(new ApiResponseModel<string>
            {
                StatusCode = System.Net.HttpStatusCode.NotFound,
                Message = "Driver is not found!"
            });
            return Ok(new ApiResponseModel<UserResponseModel>
            {
                StatusCode = System.Net.HttpStatusCode.OK,
                Message = "Driver fetched successfully!",
                Response = _mapper.Map<UserResponseModel>(driver)
            });
        }
        
        /// <summary>
        /// Update driver's information from client
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        [HttpPatch("driver/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ApiResponseModel<string>>> UpdateDriver(Guid id, [FromBody] UpdateUserRequestModel value)
        {
            if (id != value.Id)
                return BadRequest(new ApiResponseModel<string>
                {
                    StatusCode = System.Net.HttpStatusCode.BadRequest,
                    Message = "Id mismatch!"
                });
            if (!ModelState.IsValid) return BadRequest();
            
            var driver = await _driverService.GetDriverById(id);
            if (driver is null) return NotFound(new ApiResponseModel<string>
            {
                StatusCode = System.Net.HttpStatusCode.NotFound,
                Message = "Driver not found!"
            });
            _ = _mapper.Map(value, driver);
            var result = await _driverService.UpdateDriver(driver);
            if (result) return Ok(new ApiResponseModel<string>
            {
                StatusCode = System.Net.HttpStatusCode.OK,
                Message = "Driver updated successfully!"
            });
            return BadRequest(new ApiResponseModel<string>
            {
                StatusCode = System.Net.HttpStatusCode.BadRequest,
                Message = "Failed to update driver!"
            });

        }

        /// <summary>
        /// Delete driver
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("driver/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<string>> DeleteDriver(Guid id)
        {
            var driver = await _driverService.GetDriverById(id);
            if (driver is null) return NotFound(new ApiResponseModel<string>
            {
                StatusCode = System.Net.HttpStatusCode.NotFound,
                Message = "Driver not found!"
            });
            var result = await _driverService.DeleteDriver(driver);
            if (result) return Ok(new ApiResponseModel<string>
            {
                StatusCode = System.Net.HttpStatusCode.OK,
                Message = "Driver deleted successfully!"
            });
            return BadRequest(new ApiResponseModel<string>
            {
                StatusCode = System.Net.HttpStatusCode.BadRequest,
                Message = "Failed to delete driver!"
            });
        }
    }
}
