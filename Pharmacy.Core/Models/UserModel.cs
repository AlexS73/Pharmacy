using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pharmacy.Entity;

namespace Pharmacy.Core.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DepartmentModel Department { get; set; }
        public string UserName { get; set; }
        public ICollection<string> Roles { get; set; }

        public UserModel()
        {
            
        }

        public UserModel(User user)
        {
            this.Id = user.Id;
            this.Email = user.Email;
            this.UserName = user.NormalizedUserName;
            this.Department = new DepartmentModel(user.Department);
            
        }

    }
}
