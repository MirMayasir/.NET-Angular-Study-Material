using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CapstoneProjectAPI.Models;

public partial class User
{
    public int UserId { get; set; }

    [Required(ErrorMessage = "User Name is required.")]
    [StringLength(50, ErrorMessage = "User Name cannot be longer than 50 characters.")]
    public string UserName { get; set; } = null!;

    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Invalid email address format.")]
    [StringLength(100, ErrorMessage = "Email cannot be longer than 100 characters.")]
    public string Email { get; set; } = null!;

    [Required(ErrorMessage = "Password is required.")]
    [StringLength(100, MinimumLength = 6, ErrorMessage = "Password must be at least 6 characters long and cannot exceed 100 characters.")]
    public string Password { get; set; } = null!;
}
