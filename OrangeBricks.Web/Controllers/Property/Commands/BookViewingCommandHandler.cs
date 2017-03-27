using System;
using OrangeBricks.Web.Models;
using System.Collections.Generic;

namespace OrangeBricks.Web.Controllers.Property.Commands
{
    public class BookViewingCommandHandler
    {
        private readonly IOrangeBricksContext _context;

        public BookViewingCommandHandler(IOrangeBricksContext context)
        {
            _context = context;
        }

        public void Handle(BookViewingCommand command)
        {
            try
            {
                var property = _context.Properties.Find(command.PropertyId);

                var booking = new BookViewing
                {
                    Appointment = command.Appointment,
                    Status = ViewingStatus.Pending,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    BuyerUserId = command.BuyerUserId,
                };

                if (property.BookViewings == null)
                {
                    property.BookViewings = new List<BookViewing>();
                }

                property.BookViewings.Add(booking);

                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Write(ex);
            }
        }
    }
}


