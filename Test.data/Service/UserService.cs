namespace Test.data
{
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using Test.data.Models;
    using System.Linq;
    using Test.data.ViewModels;
    using System;
    using System.Threading.Tasks;
    using System.Data;
    using System.Reflection;

    public partial class UserService : ServiceBase<User>, IUserService
    {
        private readonly IUnitOfWork _uow;
        public UserService(IDbFactory dbFactory, IUnitOfWork unitOfWork) : base(dbFactory, unitOfWork)
        {
            _uow = unitOfWork;
        }

        public async Task<User> CheckInsertOrUpdateAsync(User user)
        {
            var existingItem = _uow.UserRepository.GetManyAsync(t => t.Id == user.Id).Result.FirstOrDefault();

            if (existingItem != null)
            {
                return await UpdateUserAsync(existingItem, user);
            }
            else
            {
                return await InsertUserAsync(user);
            }
        }
        public async Task<User> UpdateUserAsync(User existingItem, User user)
        {
            foreach (PropertyInfo item in user.GetType().GetProperties())
            {
                if (!item.CanRead || (item.GetIndexParameters().Length > 0))
                    continue;

                PropertyInfo other = existingItem.GetType().GetProperty(item.Name);
                if ((other != null) && (other.CanWrite))
                    other.SetValue(existingItem, item.GetValue(user, null), null);
            }

            await _uow.UserRepository.UpdateAsync(existingItem, existingItem.Id);
            return existingItem;
        }
        public async Task<User> InsertUserAsync(User user)
        {
            var newItem = await _uow.UserRepository.AddAsync(user);
            return newItem;
        }
        public async Task<List<User>> GetAllActiveUser()
        {
            return await _uow.UserRepository.GetAllAsyncList();
        }
    }

    public partial interface IUserService : IService<User>
    {
        Task<User> CheckInsertOrUpdateAsync(User user);
        Task<List<User>> GetAllActiveUser();
    }
}