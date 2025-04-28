namespace APIBlazor.Model
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; }
        public List<Menu> MenuItems { get; set; } = new List<Menu>();
    }
}
