using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Models.Models
{

    public class User : Entity
    {
        public User(int id)
        {
            
        }

        public string Name { get; set; }
        public UserRoles Role { get; set; }

        [JsonIgnore]
        public string PasswordHash { get; set; }
    }
    public enum UserRoles
    {
        Viewer,Creator
    }
}
