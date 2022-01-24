using Application.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ModelOperations.UserModelOperations
{
    public class DeleteUser
    {
        public int Id { get; set; }
        private readonly IUserService _userService;
        public DeleteUser(IUserService userService)
        {
            _userService = userService;
        }

        public async Task Handle()
        {
            var user = await _userService.GetUserById(Id);
            if (user is null)
                throw new InvalidOperationException("Bu Id numarasına sahip bir kullanıcı yok.");

            await _userService.DeleteUser(user);
        }
    }
}
