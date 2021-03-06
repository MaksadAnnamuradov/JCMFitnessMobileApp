using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JCMFitnessMobileApp.Models
{
    public class User
    {
        [PrimaryKey]
       
        public string Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string PasswordHash { get; set; }

        public string SecurityStamp { get; set; }

        public string ConcurrencyStamp { get; set; }

        public string UserName { get; set; }
        public string NormalizedUserName { get; set; }

        public string Email { get; set; }

        public string NormalizedEmail { get; set; }

        public bool EmailConfirmed { get; set; }

        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }

        public bool TwoFactorEnabled { get; set; }

        public string LockoutEnd { get; set; }
        public bool LockoutEnabled { get; set; }

        public int AccessFailedCount { get; set; }

        public DateTime JoinedDate { get; set; }
        public bool IsAdmin { get; set; }
     

        public DateTimeOffset LastUpdated { get; set; }

        public bool IsDeleted { get; set; }

        //public List<ApiUserWorkout> UserWorkouts { get; set; }

    }
}
