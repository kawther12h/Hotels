﻿using System.ComponentModel.DataAnnotations;

namespace Hotels.Models
{
    public class Card
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int IdHotel { get; set; }
        [Required]
        public int IdRoom { get; set; }
        [Required]
        public int IdRoomDetails {  get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int UserId { get; set; }

        
    }
}
