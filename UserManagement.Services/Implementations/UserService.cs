using System.Collections.Generic;
using System.Linq;
using UserManagement.Data;
using UserManagement.Models;
using UserManagement.Services.Domain.Interfaces;

namespace UserManagement.Services.Domain.Implementations
{
    public class UserService : IUserService
    {
        // constructor: database instantiation 
        private readonly IDataContext _dataAccess;
        public UserService(IDataContext dataAccess) => _dataAccess = dataAccess;


        // general dataset retrieval methods
        public IEnumerable<User> GetAllUsers() => _dataAccess.GetAll<User>(); // users        


        // returns user collection filtered by active state
        public IEnumerable<User> FilterByActive(bool isActive) => _dataAccess.GetAll<User>().Where(x => x.IsActive == isActive);


        // create a new user
        public void CreateUser(User newUser)
        {
            _dataAccess.Create(newUser);
        }


        // delete a user
        public void DeleteUser(long userId)
        {
            var userToDelete = _dataAccess.GetById<User>(userId);
            if (userToDelete != null)
            {
                _dataAccess.Delete(userToDelete);
            }
        }


        // update user details
        public void UpdateUser(User updatedUser)
        {
            var existingUser = _dataAccess.GetById<User>(updatedUser.Id);
            if (existingUser != null)
            {
                existingUser.Forename = updatedUser.Forename;
                existingUser.Surname = updatedUser.Surname;
                existingUser.Email = updatedUser.Email;
                existingUser.IsActive = updatedUser.IsActive;
                existingUser.DateOfBirth = updatedUser.DateOfBirth;
                _dataAccess.Update(existingUser);
            }
        }
    }
}

