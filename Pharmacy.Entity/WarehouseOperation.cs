using System;

namespace Pharmacy.Entity
{
    public class WarehouseOperation
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public DateTime CreatedOn { get; set; }
        public int WarehouseId { get; set; }
        public virtual Warehouse Warehouse { get; set; }
        public TypeOfOperation TypeOfOperation { get; set; }
    }

    public enum TypeOfOperation
    {
        Subtraction,
        Addition
    }
}
