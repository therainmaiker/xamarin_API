﻿using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace Api_Xamarin.Models
{
    public class RegisterModel
    {
        [Required] [StringLength(100)] public string FirstName { get; set; }

        [Required] [StringLength(100)] public string LastName { get; set; }

        [Required] [StringLength(50)] public string Username { get; set; }

        [Required] [StringLength(128)] public string Email { get; set; }

        [Required] [StringLength(256)] public string Password { get; set; }

        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        [Required] public string Address { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
    }
}