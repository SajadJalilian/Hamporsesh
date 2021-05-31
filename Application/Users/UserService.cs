using System.Collections.Generic;
using Hamporsesh.Application.Core.ViewModels.Users;
using Hamporsesh.Domain.Entities;
using Hamporsesh.Infrastructure.Data.Context;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Hamporsesh.Application.Users
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<User> _users;


        public UserService(IUnitOfWork uow)
        {
            _uow = uow;
            _users = uow.Set<User>();
        }


        /// <summary>
        /// 
        /// </summary>
        public void Create(UserInputViewModel input)
        {
            var user = new User
            {
                DisplayName = input.DisplayName,
            };
            _users.Add(user);
            _uow.SaveChanges();
        }





        /// <summary>
        /// 
        /// </summary>
        public void Update(UserInputViewModel input)
        {
            

            var user = _users.FirstOrDefault(u => u.Id == input.Id);

            user.DisplayName = input.DisplayName;
            _uow.MarkAsModified(user);
            _uow.SaveChanges();
        }



        /// <summary>
        /// 
        /// </summary>
        public UserOutputViewModel GetById(long id)
        {
            
            var user = _users.FirstOrDefault(u => u.Id == id);

            return new UserOutputViewModel
            {
                Id = user.Id,
                DisplayName = user.DisplayName,
                CreateDateTimeStr = user.CreateDateTime.ToString(),

            };


        }




        /// <summary>
        /// 
        /// </summary>
        public UserInputViewModel GetToUpdate(long id)
        {
            var user = _users.FirstOrDefault(u => u.Id == id);
            return new UserInputViewModel
            {
                Id = user.Id,
                DisplayName = user.DisplayName,
            };

        }

        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<UserOutputViewModel> GetAll()
        {
            

            return _users.OrderByDescending(u => u.Id)
                  .Select(user => new UserOutputViewModel
                  {
                      Id = user.Id,
                      DisplayName = user.DisplayName,
                      CreateDateTimeStr = user.CreateDateTime.ToString()
                  }).ToList();

        }



        /// <summary>
        /// 
        /// </summary>
        public void Delete(long id)
        {
            
            var user = _users.FirstOrDefault(u => u.Id == id);
            _uow.MarkAsDeleted(user);
            _uow.SaveChanges();
        }



    }
}
