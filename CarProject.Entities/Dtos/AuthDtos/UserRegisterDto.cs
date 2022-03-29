using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using CarProject.Entities.Concrete;

namespace CarProject.Entities.Dtos.AuthDtos
{
    public class UserRegisterDto
    {
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public byte[]? File { get; set; }
        [NotMapped]
        [JsonIgnore]
        public string IpAddress { get; set; }
    }
}

