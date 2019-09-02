using Actio.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Actio.Services.Identity.Domain.Models
{
    public class User
    {
        public Guid Id { get; protected set; }

        public string Email { get; protected set; }

        public string Name { get; protected set; }

        public string Password { get; protected set; }

        public string Salt { get; protected set; }

        public DateTime CreatedAt { get; protected set; }

        protected User()
        {

        }

        public User(string email, string name)
        {
            if (string.IsNullOrEmpty(email))
            {
                throw new ActioException("empty_user_email", $"User email can not be empty.");
            }

            if (string.IsNullOrEmpty(name))
            {
                throw new ActioException("empty_user_name", $"User name can not be empty.");
            }

            Id = Guid.NewGuid();
            Email = email;
            Name = name;
            CreatedAt = DateTime.UtcNow;
        }
    }
}
