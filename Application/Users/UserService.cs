using System.Collections.Generic;

namespace Hamporsesh.Application.Users
{
    public class UserService : IUserService
    {
        private readonly MainContext _mContext;

        public UserService()
        {
            _mContext = new MainContext();
        }


        /// <summary>
        /// 
        /// </summary>
        public void Create(UserInputViewModel input)
        {
            var users = _mContext.Set<User>();
            var user = new User
            {
                DisplayName = input.DisplayName,
            };
            users.Add(user);
            _mContext.SaveChanges();
        }





        /// <summary>
        /// 
        /// </summary>
        public void Update(UserInputViewModel input)
        {
            var users = _mContext.Set<User>();

            var user = users.FirstOrDefault(u => u.Id == input.Id);

            user.DisplayName = input.DisplayName;
            _mContext.Update(user);
            _mContext.SaveChanges();
        }



        /// <summary>
        /// 
        /// </summary>
        public UserOutputViewModel GetById(long id)
        {
            var users = _mContext.Set<User>();
            var user = users.FirstOrDefault(u => u.Id == id);

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
            var user = _mContext.Users.FirstOrDefault(u => u.Id == id);
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
            var users = _mContext.Set<User>();

            return users.OrderByDescending(u => u.Id)
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
            var users = _mContext.Set<User>();
            var user = users.FirstOrDefault(u => u.Id == id);
            _mContext.Remove(user);
            _mContext.SaveChanges();
        }



    }
}
