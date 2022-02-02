using Application.Abstract;
using Application.ModelOperations.UserModelOperations;
using Application.ValidationRules;
using Application.ValidationRules.UserValidationRules;
using AutoMapper;
using Domain.Entities;
using FluentValidation;
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
        private readonly IMapper _mapper;
        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            GetUsers getUsers = new GetUsers(_userService, _mapper);
            var result = await getUsers.Handle();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            GetUserById getUser = new GetUserById(_userService, _mapper);
            GetUserByIdValidator validator = new GetUserByIdValidator();
            getUser.Id = id;

            await validator.ValidateAndThrowAsync(getUser);
            var result = await getUser.Handle();

            return Ok(result);
        }

        //[HttpPost]
        //public async Task<IActionResult> AddUser([FromBody] CreateUserModel user)
        //{
        //    AddUser addUser = new AddUser(_userService, _mapper);
        //    AddUserValidator validator = new AddUserValidator();
        //    addUser.createUserModel = user;

        //    await validator.ValidateAndThrowAsync(user);
        //    await addUser.Handle();

        //    return Ok("User added.");
        //}

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UpdateUserViewModel user)
        {
            UpdateUser updateUser = new UpdateUser(_userService);
            UpdateUserValidator validator = new UpdateUserValidator();
            updateUser.user = user;
            updateUser.Id = id;

            await validator.ValidateAndThrowAsync(updateUser);
            await updateUser.Handle();

            return Ok("User updated.");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUser(int Id)
        {
            DeleteUser deleteUser = new DeleteUser(_userService);
            DeleteUserValidator validator = new DeleteUserValidator();
            deleteUser.Id = Id;

            await validator.ValidateAndThrowAsync(deleteUser);
            await deleteUser.Handle();

            return Ok("User deleted.");
        }
    }
}
