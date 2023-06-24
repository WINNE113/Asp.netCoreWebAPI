namespace eStoreAPIApp.Data
{
    public class ProductToPost
    {
        public int CategoryId { get; set; }
      
        public string? ProductName { get; set; }
       
        public double Weight { get; set; }
      
        public decimal UnitPrice { get; set; }
        
        public int UnitStock { get; set; }
    }
}
