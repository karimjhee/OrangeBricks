using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using OrangeBricks.Web.Controllers.Offers.ViewModels;
using OrangeBricks.Web.Models;

namespace OrangeBricks.Web.Controllers.Offers.Builders
{
    public class OffersOnPropertyViewModelBuilder
    {
        private readonly IOrangeBricksContext _context;

        public OffersOnPropertyViewModelBuilder(IOrangeBricksContext context)
        {
            _context = context;
        }

        public OffersOnPropertyViewModel Build(int id)
        {
            var property = _context.Properties
                .Where(p => p.Id == id)
                .Include(x => x.Offers)
                .Include(x => x.BookViewings)
                .SingleOrDefault();

            var offers = property.Offers ?? new List<Offer>();
            var appointments = property.BookViewings ?? new List<BookViewing>();

            return new OffersOnPropertyViewModel
            {
                HasOffers = offers.Any(),
                Offers = offers.Select(x => new OfferViewModel
                {
                    Id = x.Id,
                    Amount = x.Amount,
                    CreatedAt = x.CreatedAt,
                    IsPending = x.Status == OfferStatus.Pending,
                    Status = x.Status.ToString()
                }),
                PropertyId = property.Id, 
                PropertyType = property.PropertyType,
                StreetName = property.StreetName,
                NumberOfBedrooms = property.NumberOfBedrooms,
                HasViewings = appointments.Any(),
                Appointments = appointments.Select(x => new BookingViewModel
                {
                    Id = x.Id,
                    Appointment = x.Appointment,
                    CreatedAt = x.CreatedAt,
                    IsPending = x.Status == ViewingStatus.Pending,
                    Status = x.Status.ToString()
                })
            };
        }

        public MyOffersViewModel BuildList(string buyerUserId)
        {
            var listProperties = _context.Properties
                .Include(i => i.Offers)
                .Where(o => o.Offers.Any(a => a.BuyerUserId == buyerUserId))
                .ToList();

            return new MyOffersViewModel
            {
                PropertyOffers = listProperties
                    .Select(p => new OffersOnPropertyViewModel
                    {
                        StreetName = p.StreetName,
                        PropertyType = p.PropertyType,
                        NumberOfBedrooms = p.NumberOfBedrooms,
                        HasOffers = p.Offers.Any(),
                        PropertyId = p.Id,
                        Offers = p.Offers
                            .Where(w => w.BuyerUserId == buyerUserId)
                            .Select(o => new OfferViewModel
                            {
                                Id = o.Id,
                                Amount = o.Amount,
                                CreatedAt = o.CreatedAt,
                                IsPending = o.Status == OfferStatus.Pending,
                                Status = o.Status.ToString()
                            })
                    })
                    .ToList()
            };
        }
    }
}