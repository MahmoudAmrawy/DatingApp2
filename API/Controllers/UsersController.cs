using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UsersController(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        [HttpGet]

        public async Task<ActionResult<IEnumerable<MemberDtos>>> GetUsers()
        {
            var user = await _userRepository.GetMembersAsync();
            return Ok(user);
        }

        [HttpGet("{username}")]
        public async Task<ActionResult<MemberDtos>> GetUser(string username)
        {
            return  await _userRepository.GetMemberAsync(username);
        }
    }
}