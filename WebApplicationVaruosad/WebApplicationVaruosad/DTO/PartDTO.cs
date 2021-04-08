using System.Collections.Generic;

namespace WebApplicationVaruosad.DTO
{
    public class PartDTO
    {
        private Dictionary<string, int> stock = new Dictionary<string, int>();

        public string Serial { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string PriceVAT { get; set; }
        public string CarModel { get; set; }
        public Dictionary<string, int> Stock { get => stock; set => stock = value; }
    }
}
