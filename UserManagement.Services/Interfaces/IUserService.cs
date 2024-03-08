using System.Collections.Generic;
using UserManagement.Models;

namespace UserManagement.Services.Domain.Interfaces;

public interface IUserService 
{
    /// <summary>
    /// Return users by active state
    /// </summary>
    /// <param name="isActive"></param>
    /// <returns></returns>
    IEnumerable<User> FilterByActive(bool isActive);

    /// <summary>
    /// Retrieves all users from the data source.
    /// </summary>
    /// <returns>An IEnumerable collection of User objects representing all users in the data source.</returns>
    IEnumerable<User> GetAllUsers();
}
