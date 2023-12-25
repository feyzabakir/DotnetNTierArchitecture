using AutoMapper;
using DotnetNTierArchitecture.Core.DTOs;
using DotnetNTierArchitecture.Core.Models;
using DotnetNTierArchitecture.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotnetNTierArchitecture.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfilesController : CustomBasesController
    {
        private readonly IMapper _mapper;
        private readonly IUserProfileService _userProfileService;

        public UserProfilesController(IMapper mapper, IUserProfileService userProfileService)
        {
            _mapper = mapper;
            _userProfileService = userProfileService;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var users = await _userProfileService.GetAllAsync();
            var usersDto = _mapper.Map<List<UserProfileDto>>(users.ToList());
            return CreateActionResult(GlobalResultDto<List<UserProfileDto>>.Success(200, usersDto));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _userProfileService.GetById(id);
            var userDto = _mapper.Map<UserProfileDto>(user);
            return CreateActionResult(GlobalResultDto<UserProfileDto>.Success(200, userDto));
        }

        [HttpPost]
        public async Task<IActionResult> Save(UserProfileDto userDto)
        {
            var user = await _userProfileService.AddAsync(_mapper.Map<UserProfile>(userDto));
            var userDtos = _mapper.Map<UserProfileDto>(user);
            return CreateActionResult(GlobalResultDto<UserProfileDto>.Success(201, userDtos));
        }
        [HttpPut]
        public async Task<IActionResult> Update(UserProfileDto userDto)
        {
            await _userProfileService.UpdateAsync(_mapper.Map<UserProfile>(userDto));
            return CreateActionResult(GlobalResultDto<NoContentDto>.Success(204));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var user = await _userProfileService.GetById(id);
            await _userProfileService.RemoveAsync(user);
            return CreateActionResult(GlobalResultDto<NoContentDto>.Success(204));
        }
    }
}
