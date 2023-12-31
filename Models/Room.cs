﻿using System.ComponentModel.DataAnnotations;

namespace Hotels.Models
{
    public class Room
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(35)]
        public string Type { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public string Images { get; set; }
        [Required]
        public int RoomNo { get; set; }
        [Required]
        public int IdHotel { get; set; }
    }

}
