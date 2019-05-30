using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeddingGo.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Image { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Description { get; set; }

    }
}
