namespace FruitsRestSystem.Models
{
    public class Response
    {
        public int statusCode { get; set; }
        public string message { get; set; }
        public Fruits fruit { get; set; }
        public List<Fruits> fruits { get; set; }
    }
}
