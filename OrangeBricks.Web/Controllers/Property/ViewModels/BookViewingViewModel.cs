using System;
using System.ComponentModel.DataAnnotations;

namespace OrangeBricks.Web.Controllers.Property.ViewModels
{
    public class BookViewingViewModel
    {
        public string PropertyType { get; set; }
        public string StreetName { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/mm/yyyy hh:mm}", ApplyFormatInEditMode = true)]
        public DateTime Appointment { get; set; }
        public int PropertyId { get; set; }
        public string BuyerUserId { get; set; }
    }
}

