namespace FruitsRestSystem.Models
{
    public class Fruits
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal Amount { get; set; }
        public decimal Price { get; set; }

        public decimal Weight { get; set; }

        public decimal ItemSale(decimal weight, decimal price)
        {
            decimal itemSale = weight * price;
            return itemSale;
        }

        private static decimal totalSale = 0;

        public static void AddToTotalSale(decimal itemSale)
        {
            totalSale += itemSale;
        }

        public static decimal GetTotalSale()
        {
            return totalSale;
        }
    }
}
