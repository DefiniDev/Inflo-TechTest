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


    // retrieve UserView view of passed id matching User
    [HttpGet("UserID/{id}")]
    public IActionResult UserView(int id)
    {
        var userFromService = _userService
            .GetAllUsers().Where(p => p.Id == id).Select(p => new UserListItemViewModel
            {
                Id = p.Id,
                Forename = p.Forename,
                Surname = p.Surname,
                Email = p.Email,
                IsActive = p.IsActive,
                DateOfBirth = p.DateOfBirth
            });
                
        var user = new UserListViewModel { Items = userFromService.ToList() };     

        return View("List", user);
    }


    // return empty UserCreate view
    [HttpGet("UserCreate")]
    public IActionResult ShowUserCreate()
    {
        return View("UserCreate");
    }


    // return UserEdit view with passed id matching User
    [HttpGet("UserEdit")]
    public IActionResult ShowUserEdit(int id)
    {
        var user = _userService
            .GetAllUsers()
            .Where(p => p.Id == id)
            .Select(p => new UserListItemViewModel
            {
                Id = p.Id,
                Forename = p.Forename,
                Surname = p.Surname,
                Email = p.Email,
                IsActive = p.IsActive,
                DateOfBirth = p.DateOfBirth
            })
            .FirstOrDefault();

        return View("UserEdit", user);
    }


    // post new user with view defined props to db and return to Users list view
    [HttpPost("UserCreate")]
    public IActionResult UserCreate(UserListItemViewModel user)
    {
        if (ModelState.IsValid)
        {
            User userForService = new User
            {
                Id = user.Id,
                Forename = user.Forename,
                Surname = user.Surname,
                Email = user.Email,
                IsActive = user.IsActive,
                DateOfBirth = user.DateOfBirth
            };

            _userService.CreateUser(userForService);
           
            return RedirectToAction(nameof(ListAll));
        }
        return View("UserCreate", user);
    }


    // post current user with redefined view props to db and return to Users list view
    [HttpPost("UserEdit")]
    public IActionResult UserEdit(UserListItemViewModel user)
    {
        if (ModelState.IsValid)
        {
            User userForService = new User()
            {
                Id = user.Id,
                Forename = user.Forename,
                Surname = user.Surname,
                Email = user.Email,
                IsActive = user.IsActive,
                DateOfBirth = user.DateOfBirth
            };

            _userService.UpdateUser(userForService);
           
            return RedirectToAction(nameof(ListAll));
        }
        return View("UserEdit", user);
    }


    // delete user from db and return User list view
    [HttpPost("UserDelete")]
    public IActionResult UserDelete(int id)
    {
        _userService.DeleteUser(id);
        return RedirectToAction(nameof(ListAll));
    }
}
