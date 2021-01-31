﻿using System.ComponentModel.DataAnnotations;

namespace SIGO.Domain.Common
{
    public class AppUser
    {
        [Key]
        public long Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }
    }
}
