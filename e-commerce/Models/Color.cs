using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace e_commerce.Models
{
    public class Color
    {
        public int ID { get; set; }
        public string? ColorName { get; set; }
        public string ColorHex { get; set; }
        public ICollection<ProductStyle>? ProductStyles { get; set; }
    }
}
