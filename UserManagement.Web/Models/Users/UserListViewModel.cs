using System;
using System.ComponentModel.DataAnnotations;

namespace UserManagement.Web.Models.Users
{
    public class UserListViewModel
    {
        public List<UserListItemViewModel> Items { get; set; } = new();
    }


    public class UserListItemViewModel
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "Forename is required")]
        [StringLength(50, ErrorMessage = "Forename cannot exceed 50 characters")]
        public string? Forename { get; set; } = default!;

        [Required(ErrorMessage = "Surname is required")]
        [StringLength(50, ErrorMessage = "Surname cannot exceed 50 characters")]
        public string? Surname { get; set; } = default!;

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string? Email { get; set; } = default!;

        public bool IsActive { get; set; }

        [Required(ErrorMessage = "Date of Birth is required")]
        [DataType(DataType.Date, ErrorMessage = "Invalid date format")]
        public DateOnly DateOfBirth { get; set; } = new DateOnly(1900, 1, 1);
    }
}
