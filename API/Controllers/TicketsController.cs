using System;
using Microsoft.AspNetCore.Mvc;
using Endava.Internship2020.WebApiExamples.Services;
using Endava.Internship2020.WebApiExamples.Services.Models;
using Microsoft.AspNetCore.JsonPatch;

namespace API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class TicketsController : ControllerBase
    {
        private readonly ITicketService _ticketService;


        public TicketsController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        [HttpPost]
        public IActionResult Create(Ticket ticket)
        {
            var newTicket =_ticketService.Create(ticket);
            return Ok(newTicket);
        }

        [HttpGet("{id}")]
        public IActionResult GetTicketById(int id)
        {
            var contains = _ticketService.Contains(id);
            return Ok(contains);
        }

        [HttpGet]
        public IActionResult GetAllTickets()
        {
            var tickets = _ticketService.GetAll();
            return Ok(tickets);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteById(int id)
        {
            var contains = _ticketService.Contains(id);
            if(contains) _ticketService.Delete(id);
            else
            {
                throw new ArgumentNullException($"Ticket with {id} not found");
            }
            return Ok(contains);
        }


        [HttpPut]
        public IActionResult Update(Ticket ticket)
        {
            var updated = _ticketService.Update(ticket);
            return Ok(updated);
        }

        [HttpPatch("{id}")]
        public IActionResult Update(int id, [FromBody] JsonPatchDocument<Ticket> patch)
        {
            var updated = _ticketService.Update(id, patch);
            return Ok(updated);
        }
    }
}
