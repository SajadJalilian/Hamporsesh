using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Hamporsesh.Application.Core.ViewModels.Users;
using Hamporsesh.Domain.Entities;
using Hamporsesh.Infrastructure.Data.Context;
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
        /// </summary>
        public void Create(UserInputDto input)
        {
            var user = new User
            {
                DisplayName = input.DisplayName
            };
            _users.Add(user);
        }


        /// <summary>
        /// </summary>
        public void Update(UserInputDto input)
        {
            var user = _users.FirstOrDefault(u => u.Id == input.Id);

            user.DisplayName = input.DisplayName;
            _uow.MarkAsModified(user);
        }


        /// <summary>
        /// </summary>
        public UserOutputDto GetById(long id)
        {
            var user = _users.FirstOrDefault(u => u.Id == id);

            return new UserOutputDto
            {
                Id = user.Id,
                DisplayName = user.DisplayName,
                CreateDateTimeStr = user.CreateDateTime.ToString()
            };
        }


        /// <summary>
        /// </summary>
        public UserInputDto GetToUpdate(long id)
        {
            var user = _users.FirstOrDefault(u => u.Id == id);
            return new UserInputDto
            {
                Id = user.Id,
                DisplayName = user.DisplayName
            };
        }


        /// <summary>
        /// </summary>
        public UserOutputDto GetByUserName(string currentUserName)
        {
            var user = _users.FirstOrDefault(u => u.UserName == currentUserName);
            return new UserOutputDto
            {
                Id = user.Id,
                DisplayName = user.DisplayName
            };
        }


        /// <summary>
        /// </summary>
        public IEnumerable<UserOutputDto> GetAll()
        {
            return _users.OrderByDescending(u => u.Id)
                .Select(user => new UserOutputDto
                {
                    Id = user.Id,
                    DisplayName = user.DisplayName,
                    CreateDateTimeStr = user.CreateDateTime.ToString()
                }).ToList();
        }


        /// <summary>
        /// </summary>
        public void Delete(long id)
        {
            var user = _users.FirstOrDefault(u => u.Id == id);
            _uow.MarkAsDeleted(user);
        }
    }
}