using System;
using System.Linq;
using UserManagement.Models;
using UserManagement.Services.Domain.Interfaces;
using UserManagement.Web.Models.ActionLogs;
using UserManagement.Web.Models.Users;


[Route("/Users")]
public class UsersController : Controller
{
    // return All users
    private readonly IUserService _userService;
    public UsersController(IUserService userService) => _userService = userService;


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

        var logsFromService = _userService.GetAllLogs().Select(p => new ActionLogItemViewModel
        {
            Id = p.Id,
            UserId = p.UserId,
            ActionType = p.ActionType,
            Timestamp = p.Timestamp
        });

        var users = new UserListViewModel { Items = usersFromService.ToList() };
        var logs = new ActionLogViewModel { Items = logsFromService.ToList() };
        var model = new Tuple<UserListViewModel, ActionLogViewModel>(users, logs);

        return View("List", model);
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

        var logFromService = _userService.GetAllLogs().Where(p => p.UserId == id).Select(p => new ActionLogItemViewModel
        {
            Id = p.Id,
            UserId = p.UserId,
            ActionType = p.ActionType,
            Timestamp = p.Timestamp
        });

        var user = new UserListViewModel { Items = userFromService.ToList() };
        var logs = new ActionLogViewModel { Items = logFromService.ToList() };
        var model = new Tuple<UserListViewModel, ActionLogViewModel>(user, logs);

        return View("List", model);
    }


    // return empty UserCreate view
    [HttpGet("UserCreate")]
    public IActionResult ShowUserCreate()
    {
        return View("UserCreate");
    }


    // retrieve UserEdit view with passed id matching User
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


    // post current user with redefined view props to db and return to Users list view
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

            ActionLog userLog = new ActionLog()
            {
                Id = 0,
                UserId = userForService.Id,
                ActionType = "Create",
                Timestamp = DateTime.Now
            };
            _userService.CreateLog(userLog);
            return RedirectToAction(nameof(ListAll));
        }
        return View("UserCreate", user);
    }


    // edit current user with defined props, post to db and return to Users list view
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

            ActionLog userLog = new ActionLog()
            {
                Id = 0,
                UserId = userForService.Id,
                ActionType = "Edit",
                Timestamp = DateTime.Now
            };

            _userService.CreateLog(userLog);
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


    // return ActionLogs view
    [HttpGet("ActionLogs")]
    public IActionResult ListActionLogs()
    {
        var logsFromService = _userService.GetAllLogs().Select(p => new ActionLogItemViewModel
        {
            Id = p.Id,
            UserId = p.UserId,
            ActionType = p.ActionType,
            Timestamp = p.Timestamp
        });

        var logs = new ActionLogViewModel { Items = logsFromService.ToList() };

        return View("ActionLogs", logs);
    }


    // return ActionLogDetails view of id matching log
    [HttpGet("ActionLogDetails/{id}")]
    public IActionResult ListActionLogDetails(int id)
    {
        var logsFromService = _userService.GetAllLogs().Where(p => p.Id == id).Select(p => new ActionLogItemViewModel
        {
            Id = p.Id,
            UserId = p.UserId,
            ActionType = p.ActionType,
            Timestamp = p.Timestamp,
            Notes = p.Notes
        });

        var log = new ActionLogViewModel { Items = logsFromService.ToList() };

        return View("ActionLogDetails", log);
    }
}
