using System;
using OrangeBricks.Web.Models;

namespace OrangeBricks.Web.Controllers.Offers.Commands
{
    public class AcceptViewingCommandHandler
    {
        private readonly IOrangeBricksContext _context;

        public AcceptViewingCommandHandler(IOrangeBricksContext context)
        {
            _context = context;
        }

        public void Handle(AcceptViewingCommand command)
        {
            var viewing = _context.BookViewings.Find(command.AppointmentId);

            viewing.UpdatedAt = DateTime.Now;
            viewing.Status = ViewingStatus.Accepted;

            _context.SaveChanges();
        }
    }
}

