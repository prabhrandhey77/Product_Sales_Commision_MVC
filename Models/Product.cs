namespace Product_Sales_Commision_MVC.Models
{//Product details including the commision and price
    public class Product
    {
        public int Id { get; set; }


        public int ManufacturerId { get; set; }

        public Manufacturer Manufacturer { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public decimal SalesCommission { get; set; }

    }
}
