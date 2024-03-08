using System.Collections.Generic;
using System.Linq;
using UserManagement.Data;
using UserManagement.Models;
using UserManagement.Services.Domain.Interfaces;

namespace UserManagement.Services.Domain.Implementations;

public class UserService : IUserService
{
    // constructor: database instantiation 
    private readonly IDataContext _dataAccess;
    public UserService(IDataContext dataAccess) => _dataAccess = dataAccess;

    // general dataset retrieval methods
    public IEnumerable<User> GetAllUsers() => _dataAccess.GetAll<User>(); // users

    // returns user collection filtered by active state
    public IEnumerable<User> FilterByActive(bool isActive) => _dataAccess.GetAll<User>().Where(x => x.IsActive == isActive);    
}
