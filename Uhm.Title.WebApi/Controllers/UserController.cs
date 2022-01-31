using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Uhm.Title.Constants;
using Uhm.Title.Data.Models;
using Uhm.Title.Dto;
using Uhm.Title.Helper;
using Uhm.Title.Repository.Users;

namespace Uhm.Title.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserController(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        [HttpPost("AddUser")]
        public async Task<ActionResult<bool>> AddUser(UserDto request)
        {
            try
            {
                User user = _mapper.Map<User>(request);
                var data = _userRepository.CreateUser(user);
                return Ok(ApiResponse.CreateResponse(data, StatusConstants.StatusCode200));
            }
            catch (Exception ex)
            {
                await _userRepository.SaveErrorLogging(ex);
                return Ok(ApiResponse.CreateResponse(string.Empty, StatusConstants.StatusCode500));
            }
        }
        [HttpGet("GetUserList")]
        public async Task<ActionResult<User>> GetUserList()
        {
            try
            {
                var data = await _userRepository.GetUserList();
                return Ok(ApiResponse.CreateResponse(data, StatusConstants.StatusCode200));
            }
            catch (Exception ex)
            {
                await _userRepository.SaveErrorLogging(ex);
                return Ok(ApiResponse.CreateResponse(false, StatusConstants.StatusCode500));
            }

        }
        [HttpPost("Update")]
        public async Task<ActionResult<User>> Update([FromBody] User user)
        {
            try
            {
                UserDto userDto = _mapper.Map<UserDto>(user);
                var data = _userRepository.UpdateUser(user);

                return Ok(ApiResponse.CreateResponse(data, StatusConstants.StatusCode200));
            }
            catch (Exception ex)
            {
                await _userRepository.SaveErrorLogging(ex);
                return Ok(ApiResponse.CreateResponse(string.Empty, StatusConstants.StatusCode500));
            }
        }
        [HttpPost("Delete")]
        public async Task<ActionResult<bool>> Delete([FromBody] int id)
        {
            try
            {
                var data = _userRepository.DeleteUserById(id);
                return Ok(ApiResponse.CreateResponse(data, StatusConstants.StatusCode200));
            }
            catch (Exception ex)
            {
                await _userRepository.SaveErrorLogging(ex);
                return Ok(ApiResponse.CreateResponse(string.Empty, StatusConstants.StatusCode500));
            }
        }
    }
}
