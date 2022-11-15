namespace Pharmacy.Entity
{
    public class EntranceProduct
    {
        public int Id { get; set; }
        public virtual Entrance Entrance { get; set; }
        public int EntranceId { get; set; }
        public virtual Product Product { get; set; }
        public int ProductId { get; set; }
        public int Count { get; set; }
    }
}
