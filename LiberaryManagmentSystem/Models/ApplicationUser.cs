using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

public class ApplicationUser : IdentityUser
{
    [Required]
    [MaxLength(100)]
    public string FullName { get; set; }=string.Empty;

    [MaxLength(250)]
    public string Address { get; set; }= string.Empty;

    [DataType(DataType.Date)]
    public DateTime? DateOfBirth { get; set; }

    [MaxLength(50)]
    public string Gender { get; set; } = string.Empty;

    [DataType(DataType.DateTime)]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    [DataType(DataType.DateTime)]
    public DateTime? LastLogin { get; set; }

    [MaxLength(50)]
    public string RoleDisplayName { get; set; } = string.Empty;

    public bool IsActive { get; set; } = true;

    // You can also store profile image URL or Base64 string
    [MaxLength(500)]
    public string ProfilePictureUrl { get; set; }=string.Empty ;
}
