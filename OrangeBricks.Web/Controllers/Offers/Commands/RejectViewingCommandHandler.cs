using System;
using OrangeBricks.Web.Models;

namespace OrangeBricks.Web.Controllers.Offers.Commands
{
    public class RejectViewingCommandHandler
    {
        private readonly IOrangeBricksContext _context;

        public RejectViewingCommandHandler(IOrangeBricksContext context)
        {
            _context = context;
        }

        public void Handle(RejectViewingCommand command)
        {
            var viewing = _context.BookViewings.Find(command.AppointmentId);

            viewing.UpdatedAt = DateTime.Now;
            viewing.Status = ViewingStatus.Rejected;

            _context.SaveChanges();
        }
    }
}


