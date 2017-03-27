using System;

namespace OrangeBricks.Web.Controllers.Property.Commands
{
    public class BookViewingCommand
    {
        public DateTime Appointment { get; set; }
        public int PropertyId { get; set; }
        public string BuyerUserId { get; set; }
    }
}