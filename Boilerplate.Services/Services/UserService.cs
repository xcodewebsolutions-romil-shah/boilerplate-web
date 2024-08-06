using Boilerplate.Data.Contracts;
using Boilerplate.Infrastructure.Dtos;
using Boilerplate.Infrastructure.Mapping;
using Boilerplate.Infrastructure.Utilities;
using Boilerplate.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Boilerplate.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public UserDto Login(string username, string password)
        {

            try
            {
                var user = _unitOfWork.UserRepository.Query().FirstOrDefault(x => x.Username != null && x.Username.ToLower() == username.ToLower());
                if (user == null)
                {
                    throw new BadRequestException("Username is not registered");
                }
                if (user.Password.ToLower() != password.ToLower())
                {
                    throw new BadRequestException("Password is invalid");
                }

                return Map.EntityToDto(user);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
