using System.Linq;
using UserManagement.Models;
using UserManagement.Services.Domain.Interfaces;
using UserManagement.Web.Models.Users;

namespace UserManagement.WebMS.Controllers;

[Route("/Users")]
public class UsersController : Controller
{
    private readonly IUserService _userService;
    public UsersController(IUserService userService) => _userService = userService;


    // return All users
    [HttpGet("AllUsers")]
    public ViewResult ListAll()
    {
        return (ViewResult)ListUsers(_userService.GetAllUsers());
    }


    // return Active users
    [HttpGet("ActiveUsers")]
    public IActionResult ListActiveOnly()
    {
        return ListUsers(_userService.FilterByActive(true));
    }


    // return Non-Active users
    [HttpGet("InactiveUsers")]
    public IActionResult ListNonActive()
    {
        return ListUsers(_userService.FilterByActive(false));
    }


    // return view with passed user(s) model
    private IActionResult ListUsers(IEnumerable<User> filteredUsers)
    {
        var usersFromService = filteredUsers.Select(p => new UserListItemViewModel
        {
            Id = p.Id,
            Forename = p.Forename,
            Surname = p.Surname,
            Email = p.Email,
            IsActive = p.IsActive,
            DateOfBirth = p.DateOfBirth
        });       

        var users = new UserListViewModel { Items = usersFromService.ToList() };     

        return View("List", users);
    }
}
