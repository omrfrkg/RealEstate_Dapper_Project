﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Repositories.AppUserRepositories;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUsersController : ControllerBase
    {
        private readonly IAppUserRepository _appUserRepository;

        public AppUsersController(IAppUserRepository appUserRepository)
        {
            _appUserRepository = appUserRepository;
        }

        [HttpGet("GetAppUserByProductId")]
        public async Task<IActionResult> GetAppUserByProductId(int id)
        {
            var result = await _appUserRepository.GetAppUserByProductId(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
