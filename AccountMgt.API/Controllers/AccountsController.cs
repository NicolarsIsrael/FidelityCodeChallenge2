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
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : Controller
    {
        private IRepoService _repoService;
        public AccountsController(IRepoService repoService)
        {
            _repoService = repoService;
        }


        [Route("")]
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var accounts = _repoService.AccountsService.Get();
                return StatusCode(StatusCodes.Status200OK, new ApiResponseDto
                {
                    statusCode = StatusCodes.Status200OK,
                    message = "Successful",
                    validationError = false,
                    serverError = false,
                    data = accounts
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

        [Route("{id}")]
        [HttpGet]
        public IActionResult Get([FromQuery] int id)
        {
            try
            {
                var account = _repoService.AccountsService.Get(id);
                return StatusCode(StatusCodes.Status200OK, new ApiResponseDto
                {
                    statusCode = StatusCodes.Status200OK,
                    message = "Successful",
                    validationError = false,
                    serverError = false,
                    data = account
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

        [Route("")]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Accounts account)
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

                await _repoService.AccountsService.Add(account);
                return StatusCode(StatusCodes.Status200OK, new ApiResponseDto
                {
                    statusCode = StatusCodes.Status200OK,
                    message = "Successful",
                    validationError = false,
                    serverError = false,
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

        [Route("{id}")]
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Accounts model, [FromQuery] int id)
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
                if(account == null)
                    return StatusCode(StatusCodes.Status404NotFound, new ApiResponseDto
                    {
                        statusCode = StatusCodes.Status404NotFound,
                        message = "Account not found",
                        validationError = true,
                        serverError = false,
                    });

                account.CompanyName = model.CompanyName;
                account.Website = model.Website;
                await _repoService.AccountsService.Update(account);

                return StatusCode(StatusCodes.Status200OK, new ApiResponseDto
                {
                    statusCode = StatusCodes.Status200OK,
                    message = "Successful",
                    validationError = false,
                    serverError = false,
                });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ApiResponseDto
                {
                    statusCode = StatusCodes.Status500InternalServerError,
                    message = "Error occured in server",
                    validationError = true,
                    serverError = true,
                    exception = ex
                });
            }
        }

        [Route("{id}")]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var account = _repoService.AccountsService.Get(id);
                if (account == null)
                    return StatusCode(StatusCodes.Status404NotFound, new ApiResponseDto
                    {
                        statusCode = StatusCodes.Status404NotFound,
                        message = "Account not found",
                        validationError = true,
                        serverError = false,
                    });

                await _repoService.AccountsService.Delete(account);
                return StatusCode(StatusCodes.Status200OK, new ApiResponseDto
                {
                    statusCode = StatusCodes.Status200OK,
                    message = "Successful",
                    validationError = false,
                    serverError = false,
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
                }) ;
            }
        }
    }
}
