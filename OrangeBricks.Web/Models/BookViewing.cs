using System;
using System.ComponentModel.DataAnnotations;

namespace OrangeBricks.Web.Models
{
    public class BookViewing
    {
        [Key]
        public int Id { get; set; }

        public ViewingStatus Status { get; set; }

        [Required]
        public DateTime Appointment { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        [Required]
        public string BuyerUserId { get; set; }
    }
}


