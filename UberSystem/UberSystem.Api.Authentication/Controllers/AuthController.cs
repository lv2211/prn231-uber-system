using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using UberSystem.Domain.Contracts.Services;
using UberSystem.Domain.Entities;
using UberSystem.Domain.Enums;
using UberSystem.Dto;
using UberSystem.Dto.Requests;
using UberSystem.Dto.Responses;
using UberSystem.Service;

namespace UberSystem.Api.Authentication.Controllers
{
    [Route("api/uber-system")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IEmailService _emailService;
        private readonly TokenService _tokenService;
        private readonly IMapper _mapper;

        public AuthController(
            IUserService userService,
            IEmailService emailService,
            TokenService tokenService,
            IMapper mapper)
        {
            _userService = userService;
            _emailService = emailService;
            _tokenService = tokenService;
            _mapper = mapper;
        }

        /// <summary>
        /// Sign in into Uber
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("sign-in")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ApiResponseModel<LoginResponseModel>>> Login([FromBody] LoginModel request)
        {
            if (!ModelState.IsValid) return BadRequest();
            var result = await _userService.Login(request.Email, request.Password);
            if (result is null) return NotFound(new ApiResponseModel<string>
            {
                StatusCode = HttpStatusCode.NotFound,
                Message = "User not found"
            });
            var accessToken = _tokenService.GenerateToken(result, new List<string> { result.Role.ToString() });
            var response = _mapper.Map<LoginResponseModel>(result);
            response.AccessToken = accessToken;

            return Ok(new ApiResponseModel<LoginResponseModel>
            {
                StatusCode = HttpStatusCode.OK,
                Message = "Success",
                Response = response
            });
        }

        /// <summary>
        /// Verifies the user's email based on the provided token.
        /// </summary>
        /// <param name="token">The token used to verify the email.</param>
        /// <returns>A response message indicating the result of the verification process.</returns>
        [HttpGet("verify-email")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<string>> VerifyEmail(string token)
        {
            if (string.IsNullOrEmpty(token)) return BadRequest(new ApiResponseModel<string>
            {
                StatusCode = HttpStatusCode.BadRequest,
                Message = "Invalid verified email token!"
            });
            if (!ModelState.IsValid) return BadRequest();
            var user = await _userService.GetUserByToken(token);
            if (user == null)
                return NotFound(new ApiResponseModel<string>
                {
                    StatusCode = HttpStatusCode.NotFound,
                    Message = "User is not found!"
                });
            // Remove the email verification token from the user's record.
            user.EmailVerified = true;
            user.VerifiedToken = null;

            var result = await _userService.UpdateUser(user);

            return Ok(new ApiResponseModel<string>
            {
                Message = "Verified successfully!",
                StatusCode = HttpStatusCode.OK
            });
        }

        /// <summary>
        /// Sign up into Uber 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("sign-up")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponseModel<string>>> Signup([FromBody] SignupModel request)
        {
            // Convert the string role to the corresponding enum
            if (!Enum.TryParse<UserRole>(request.Role, true, out var userRole) ||
                !Enum.IsDefined(typeof(UserRole), userRole))
            {
                return BadRequest(new ApiResponseModel<string>
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    Message = "Invalid role's value in the system!"
                });
            }
            if (!ModelState.IsValid) return BadRequest();
            request.Id = Guid.NewGuid();
            var user = _mapper.Map<User>(request);

            // Generate verified email token
            // TODO: The verified token should have a time limit, e.g, 60 minutes.
            user.VerifiedToken = Guid.NewGuid().ToString();
            var verificationLink = Url.Action(nameof(VerifyEmail), "Auth",
                new { token = user.VerifiedToken }, Request.Scheme) ?? string.Empty;
            // Send the verification link to the user's email
            await _emailService.SendVerificationEmailAsync(request.Email, verificationLink);
            var result = await _userService.AddUser(user);
            if (!result)
                return BadRequest(new ApiResponseModel<string>
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    Message = "Failed to add user!"
                });
            return Ok(new ApiResponseModel<string>
            {
                StatusCode = HttpStatusCode.OK,
                Message = "Success!",
            });
        }
    }
}
