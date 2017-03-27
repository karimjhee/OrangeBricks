using System;
using System.Collections.Generic;

namespace OrangeBricks.Web.Controllers.Property.ViewModels
{
    public class AppointmentsOnPropertyViewModel
    {
        public string PropertyType { get; set; }
        public int NumberOfBedrooms { get; set; }
        public string StreetName { get; set; }
        public bool HasBookings { get; set; }
        public IEnumerable<AppointmentViewModel> Appointments { get; set; }
        public int PropertyId { get; set; }
    }

    public class AppointmentViewModel
    {
        public int Id;
        public DateTime Appointment { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsPending { get; set; }
        public string Status { get; set; }
    }
}


