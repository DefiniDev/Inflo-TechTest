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


    /// <summary>
    /// Create a new user.
    /// </summary>
    /// <param name="newUser">The user to be created.</param>
    void CreateUser(User newUser);


    /// <summary>
    /// Delete a user.
    /// </summary>
    /// <param name="deleteUser">The user to be deleted.</param>
    void DeleteUser(long id);


    /// <summary>
    /// Update a user.
    /// </summary>
    /// <param name="updateUser">The user to be updated.</param>
    void UpdateUser(User newUser);
}
