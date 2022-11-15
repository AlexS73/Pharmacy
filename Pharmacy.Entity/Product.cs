namespace Pharmacy.Entity
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Article { get; set; }
        public virtual Warehouse Warehouse { get; set; }
    }
}
