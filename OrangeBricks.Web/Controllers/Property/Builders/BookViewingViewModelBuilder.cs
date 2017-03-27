using OrangeBricks.Web.Controllers.Property.ViewModels;
using OrangeBricks.Web.Models;
using System;
using System.Data.Entity;
using System.Linq;

namespace OrangeBricks.Web.Controllers.Property.Builders
{
    public class BookViewingViewModelBuilder
    {
        private readonly IOrangeBricksContext _context;

        public BookViewingViewModelBuilder(IOrangeBricksContext context)
        {
            _context = context;
        }

        public BookViewingViewModel Build(int id, string buyerUserId)
        {
            var property = _context.Properties.Find(id);

            return new BookViewingViewModel
            {
                PropertyId = property.Id,
                PropertyType = property.PropertyType,
                StreetName = property.StreetName,
                BuyerUserId = buyerUserId,
                Appointment = DateTime.Now
            };
        }

        public MyAppointmentsViewModel BuildList(string buyerUserId)
        {
            var listProperties = _context.Properties
                .Include(i => i.BookViewings)
                .Where(o => o.BookViewings.Any(a => a.BuyerUserId == buyerUserId))
                .ToList();

            return new MyAppointmentsViewModel
            {
                PropertyAppointments = listProperties
                    .Select(p => new AppointmentsOnPropertyViewModel
                    {
                        PropertyType = p.PropertyType,
                        StreetName = p.StreetName,
                        NumberOfBedrooms = p.NumberOfBedrooms,
                        HasBookings = p.BookViewings.Any(),
                        PropertyId = p.Id,
                        Appointments = p.BookViewings
                            .Where(w => w.BuyerUserId == buyerUserId)
                            .Select(s => new AppointmentViewModel
                            {
                                Id = s.Id,
                                Appointment = s.Appointment,
                                CreatedAt = s.CreatedAt,
                                IsPending = s.Status == ViewingStatus.Pending,
                                Status = s.Status.ToString()
                            })
                    })
                    .ToList()
            };
        }
    }
}


