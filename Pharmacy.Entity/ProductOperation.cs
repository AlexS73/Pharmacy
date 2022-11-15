using System;

namespace Pharmacy.Entity
{
    public class ProductOperation
    {
        public int Id { get; set; }
        public virtual User User { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
