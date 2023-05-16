using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Pharmacy.Core.Models
{
    public class RoleModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public RoleModel()
        {
            
        }

        public RoleModel(IdentityRole<int> role)
        {
            this.Id = role.Id;;
            this.Name = role.Name;
        }
    }
}
