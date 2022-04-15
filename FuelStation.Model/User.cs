using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FuelStation.Model
{
    public class User : BaseEntity
    {
            public string Name { get; set; }
            public string Surname { get; set; }
            public string Username { get; set; }
            [JsonIgnore]
            public string PasswordHash { get; set; }
    }
}
