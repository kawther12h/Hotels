using System.ComponentModel.DataAnnotations;

namespace Hotels.Models
{
    public class RoomDetails
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [StringLength(50)]
        public string Image1 { get; set; }
        [Required]
        [StringLength(50)]
        public string Image2 { get; set; }
        [Required]
        [StringLength(50)]
        public string Image3 { get; set; }
        [StringLength(50)]
        public string? Food { get; set; }
        [Required]
        public string Features { get; set; }
        [Required]
        public int IdRoom { get; set; }
        [Required]
        public int IdHotel { get; set; }


    }
}
