using Endava.Internship2020.WebApiExamples.Services.Models;
using Swashbuckle.AspNetCore.Filters;

namespace API.Examples
{
    public class CreateTicketRequestExample : IExamplesProvider<Ticket>
    {
        public Ticket GetExamples()
        {
            return new Ticket
            {
                EventName = ".NET Web API",
                Owner = "Velin Arbov",
            };
        }
    }
}
