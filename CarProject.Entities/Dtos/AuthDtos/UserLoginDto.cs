using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CarProject.Entities.Dtos.AuthDtos
{
    public class UserLoginDto
    {
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        [NotMapped]
        [JsonIgnore]
        public string IpAddress { get; set; }
    }
}

