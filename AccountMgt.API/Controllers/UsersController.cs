using AccountMgt.CORE;
using AccountMgt.DAO;
using AccountMgt.SERVICE.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountMgt.API.Controllers
{
    [ApiController]
    [Route("api/accounts")]
    public class UsersController : Controller
    {
        private IRepoService _repoService;
        public UsersController(IRepoService repoService)
        {
            _repoService = repoService;
        }

        [Route("{id}/users")]
        [HttpGet]
        public IActionResult Get([FromRoute]int id)
        {
            try
            {
                var users = _repoService.UsersService.Get(id);
                return StatusCode(StatusCodes.Status200OK, new ApiResponseDto
                {
                    statusCode = StatusCodes.Status200OK,
                    message = "Successful",
                    validationError = false,
                    serverError = false,
                    data = users
                });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ApiResponseDto
                {
                    statusCode = StatusCodes.Status500InternalServerError,
                    message = "Error occured in server",
                    validationError = false,
                    serverError = true,
                    exception = ex
                });
            }
        }

        [Route("{accountId}/users/{userId}")]
        [HttpGet]
        public IActionResult Get([FromRoute]int accountId, [FromRoute]int userId)
        {
            try
            {
                var user = _repoService.UsersService.Get(accountId, userId);
                if (user == null)
                    return StatusCode(StatusCodes.Status404NotFound, new ApiResponseDto
                    {
                        statusCode = StatusCodes.Status404NotFound,
                        message = "User not found",
                        validationError = true,
                        serverError = false,
                    });

                return StatusCode(StatusCodes.Status200OK, new ApiResponseDto
                {
                    statusCode = StatusCodes.Status200OK,
                    message = "Successful",
                    validationError = false,
                    serverError = false,
                    data = user
                });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ApiResponseDto
                {
                    statusCode = StatusCodes.Status500InternalServerError,
                    message = "Error occured in server",
                    validationError = false,
                    serverError = true,
                    exception = ex
                });
            }
        }

        [Route("{id}/users")]
        [HttpPost]
        public async Task<IActionResult> Post([FromRoute]int id, [FromBody]Users user)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status422UnprocessableEntity, new ApiResponseDto
                    {
                        statusCode = StatusCodes.Status422UnprocessableEntity,
                        message = "Validation error in one or more entities",
                        validationError = true,
                        serverError = false,
                    });
                }

                var account = _repoService.AccountsService.Get(id);
                if (account == null)
                    return StatusCode(StatusCodes.Status404NotFound, new ApiResponseDto
                    {
                        statusCode = StatusCodes.Status404NotFound,
                        message = "Account not found",
                        validationError = true,
                        serverError = false,
                    });

                user.Account = account;
                await _repoService.UsersService.Add(user);
                return StatusCode(StatusCodes.Status200OK, new ApiResponseDto
                {
                    statusCode = StatusCodes.Status200OK,
                    message = "Successful",
                    validationError = false,
                    serverError = false
                });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ApiResponseDto
                {
                    statusCode = StatusCodes.Status500InternalServerError,
                    message = "Error occured in server",
                    validationError = false,
                    serverError = true,
                    exception = ex
                });
            }
        }

        [Route("{accountId}/users/{userId}")]
        [HttpPut]
        public async Task<IActionResult> Put([FromRoute]int accountId, [FromRoute]int userId, [FromBody] Users model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status422UnprocessableEntity, new ApiResponseDto
                    {
                        statusCode = StatusCodes.Status422UnprocessableEntity,
                        message = "Validation error in one or more entities",
                        validationError = true,
                        serverError = false,
                    });
                }

                var user = _repoService.UsersService.Get(accountId, userId);
                if (user == null)
                    return StatusCode(StatusCodes.Status404NotFound, new ApiResponseDto
                    {
                        statusCode = StatusCodes.Status404NotFound,
                        message = "User not found",
                        validationError = true,
                        serverError = false,
                    });

                user.FirstName = model.FirstName;
                user.LastName = model.LastName;

                await _repoService.UsersService.Update(user);
                return StatusCode(StatusCodes.Status200OK, new ApiResponseDto
                {
                    statusCode = StatusCodes.Status200OK,
                    message = "Successful",
                    validationError = false,
                    serverError = false
                });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ApiResponseDto
                {
                    statusCode = StatusCodes.Status500InternalServerError,
                    message = "Error occured in server",
                    validationError = false,
                    serverError = true,
                    exception = ex
                });
            }
        }

        [Route("{accountId}/users/{userId}")]
        [HttpDelete]
        public async Task<IActionResult> Delete([FromRoute]int accountId, [FromRoute]int userId)
        {
            try
            {
                var user = _repoService.UsersService.Get(accountId, userId);
                if (user == null)
                    return StatusCode(StatusCodes.Status404NotFound, new ApiResponseDto
                    {
                        statusCode = StatusCodes.Status404NotFound,
                        message = "User not found",
                        validationError = true,
                        serverError = false,
                    });
                await _repoService.UsersService.Delete(user);
                return StatusCode(StatusCodes.Status200OK, new ApiResponseDto
                {
                    statusCode = StatusCodes.Status200OK,
                    message = "Successful",
                    validationError = false,
                    serverError = false
                });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ApiResponseDto
                {
                    statusCode = StatusCodes.Status500InternalServerError,
                    message = "Error occured in server",
                    validationError = false,
                    serverError = true,
                    exception = ex
                });
            }
        }
    }
}
