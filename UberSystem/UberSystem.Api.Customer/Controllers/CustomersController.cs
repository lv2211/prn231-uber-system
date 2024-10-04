using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using UberSystem.Domain.Contracts.Services;
using UberSystem.Domain.Entities;
using UberSystem.Dto;
using UberSystem.Dto.Helpers;
using UberSystem.Dto.Requests;
using UberSystem.Dto.Responses;

namespace UberSystem.Api.Customer.Controllers
{
    [Route("api/uber-system")]
    [ApiController]
    public class CustomersController(
        ICustomerService customerService,
        IMapper mapper,
        IDriverService driverService) : ControllerBase
    {
        private readonly ICustomerService _customerService = customerService;
        private readonly IMapper _mapper = mapper;
        private readonly IDriverService _driverService = driverService;

        /// <summary>
        /// Get customers in Uber with pagination
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("customers/pageNumber/{pageNumber}/pageSize/{pageSize}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ApiResponseModel<PagedResponse<UserResponseModel>>>> GetCustomers(int pageNumber = 1, int pageSize = 10)
        {
            var customers = _mapper.Map<IList<UserResponseModel>>(await _customerService.GetCustomers());
            if (!customers.Any()) return NotFound(new ApiResponseModel<string>
            {
                StatusCode = HttpStatusCode.NotFound,
                Message = "No data of customers!"
            });
            var response = PaginationHelper.GetPagedResponse(customers.AsQueryable(), pageNumber, pageSize);
            return Ok(new ApiResponseModel<PagedResponse<UserResponseModel>>
            {
                StatusCode = HttpStatusCode.OK,
                Message = "Customers fetched successfully!",
                Response = response
            });
        }

        /// <summary>
        /// Get customer by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("customers/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ApiResponseModel<UserResponseModel>>> GetCustomer(Guid id)
        {
            var customer = _mapper.Map<UserResponseModel>(await _customerService.GetCustomerById(id));
            if (customer is null)
            {
                return NotFound(new ApiResponseModel<string>
                {
                    StatusCode = HttpStatusCode.NotFound,
                    Message = "Customer is not found!"
                });
            }
            return Ok(new ApiResponseModel<UserResponseModel>
            {
                StatusCode = HttpStatusCode.OK,
                Message = "Customer fetched successfully!",
                Response = customer
            });
        }
        
        /// <summary>
        /// Update customer's information from client
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        [HttpPatch("customer/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<string>> UpdateCustomer(Guid id, [FromBody] UpdateUserRequestModel value)
        {
            if (id != value.Id)
                return BadRequest(new ApiResponseModel<string>
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    Message = "Id is not matched!"
                });

            if (!ModelState.IsValid) return BadRequest();
            var customer = await _customerService.GetCustomerById(id);
            if (customer is null)
            {
                return NotFound(new ApiResponseModel<string>
                {
                    StatusCode = HttpStatusCode.NotFound,
                    Message = "Customer is not found!"
                });
            }
            _ = _mapper.Map(value, customer);
            var result = await _customerService.UpdateCustomer(customer);
            if (result)
            {
                return Ok(new ApiResponseModel<string>
                {
                    StatusCode = HttpStatusCode.OK,
                    Message = "Customer updated successfully!"
                });
            }
            return BadRequest(new ApiResponseModel<string>
            {
                StatusCode = HttpStatusCode.BadRequest,
                Message = "Failed to update customer!"
            });
        }

        /// <summary>
        /// Delete customer
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("customer/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<string>> DeleteCustomer(Guid id)
        {
            var customer = await _customerService.GetCustomerById(id);
            if (customer is null)
            {
                return NotFound(new ApiResponseModel<string>
                {
                    StatusCode = HttpStatusCode.NotFound,
                    Message = "Customer is not found!"
                });
            }
            var result = await _customerService.DeleteCustomer(customer);
            if (result)
            {
                return Ok(new ApiResponseModel<string>
                {
                    StatusCode = HttpStatusCode.OK,
                    Message = "Customer deleted successfully!"
                });
            }
            return BadRequest(new ApiResponseModel<string>
            {
                StatusCode = HttpStatusCode.BadRequest,
                Message = "Failed to delete customer!"
            });
        }

        /// <summary>
        /// Create feedback to driver for a trip
        /// </summary>
        /// <param name="model">Feedback request model</param>
        /// <returns></returns>
        [HttpPost("customer/feedback")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ApiResponseModel<string>>> CreateFeedback([FromBody] FeedbackRequestModel model)
        {
            // Check whether driver and customer are existed in the system
            var customer = await _customerService.GetCustomerById(model.CustomerId);
            if (customer is null) return NotFound(new ApiResponseModel<string>
            {
                StatusCode = HttpStatusCode.NotFound,
                Message = "Customer is not found!"
            });
            var driver = await _driverService.GetDriverById(model.DriverId);
            if (driver is null) return NotFound(new ApiResponseModel<string>
            {
                StatusCode = HttpStatusCode.NotFound,
                Message = "Driver is not found!"
            });
            if (!ModelState.IsValid) return BadRequest();
            
            var rating = _mapper.Map<Rating>(model);
            var result = await _customerService.CreateFeedbackForDriver(rating);
            if (!result) return BadRequest(new ApiResponseModel<string>
            {
                StatusCode = HttpStatusCode.BadRequest,
                Message = "Cannot create rating for driver!",
                Response = null,
            });
            return Ok(new ApiResponseModel<string>
            {
                StatusCode = HttpStatusCode.OK,
                Message = "Success",
            });
        }
    }
}
