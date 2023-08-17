using System.ComponentModel.DataAnnotations;

namespace e_commerce.Requests
{
    public class FilterProductRequest
    {
        public string Category { get; set; } = string.Empty;
        public List<int>? BrandID { get; set; }
        public int ColorID { get; set; }
        public int SizeID { get; set; }
        public int minPrice { get; set; }
        public int maxPrice { get; set; }
        public List<int>? MaterialID { get; set; }
    }
}
