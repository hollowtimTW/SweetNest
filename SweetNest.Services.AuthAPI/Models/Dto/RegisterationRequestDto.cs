﻿using System.ComponentModel.DataAnnotations;

namespace SweetNest.Services.AuthAPI.Models.Dto
{
    public class RegisterationRequestDto
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Password { get; set; }
        public string? Role { get; set; }
    }
}
