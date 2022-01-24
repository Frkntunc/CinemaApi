using Application.Abstract;
using Application.ModelOperations.UserModelOperations;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            GetUsers getUsers = new GetUsers(_userService);
            var result = await getUsers.Handle();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int Id)
        {
            GetUserById getUser = new GetUserById(_userService);
            getUser.Id = Id;

            try
            {
                var result = await getUser.Handle();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] CreateUserModel user)
        {
            AddUser addUser = new AddUser(_userService);
            addUser.createUserModel = user;
            try
            {
                await addUser.Handle();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser(User user)
        {
            var updatedUser = await _userService.GetUserById(user.ID);

            if (updatedUser != null)
            {
                await _userService.UpdateUser(user);
                return Ok("Müşteri güncellendi.");
            }
            return BadRequest();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUser(int Id)
        {
            var deletedUser = await _userService.GetUserById(Id);

            if (deletedUser!=null)
            {
                await _userService.DeleteUser(deletedUser);
                return Ok("Müşteri Silindi");
            }
            return BadRequest();
        }
    }
}
