using System.ComponentModel.DataAnnotations;

namespace e_commerce.Requests
{
    public class GetSizeByColorRequest
    {
        [Required]
        public int ProductID { get; set; }

        [Required]
        public int ColorID { get; set; }
    }
}
