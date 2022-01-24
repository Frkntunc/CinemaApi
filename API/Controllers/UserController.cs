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
        public async Task<IActionResult> GetUserById(int id)
        {
            GetUserById getUser = new GetUserById(_userService);
            getUser.Id = id;
            try
            {
                var result = await getUser.Handle();
                return Ok(result);
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
                return Ok("Kullanıcı eklendi.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UpdateUserViewModel user)
        {
            UpdateUser updateUser = new UpdateUser(_userService);
            updateUser.user = user;
            updateUser.Id = id;

            try
            {
                await updateUser.Handle();
                return Ok("Kullanıcı güncellendi.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUser(int Id)
        {
            DeleteUser deleteUser = new DeleteUser(_userService);
            deleteUser.Id = Id;
            try
            {
                await deleteUser.Handle();
                return Ok("Kullanıcı silindi");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
