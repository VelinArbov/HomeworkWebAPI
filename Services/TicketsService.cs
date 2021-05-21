using System;
using System.Collections.Generic;
using System.Linq;
using Endava.Internship2020.WebApiExamples.Services.Models;
using Microsoft.AspNetCore.JsonPatch;

namespace Endava.Internship2020.WebApiExamples.Services
{
    public class TicketsService : ITicketService
    {
        private readonly ITicketsRepository repository;

        public TicketsService(ITicketsRepository repository)
        {
            this.repository = repository;
        }

        public bool Contains(int id)
        {
            return repository.Contains(id);
        }

        public IReadOnlyCollection<Ticket> GetAll()
        {
            return this.repository.GetAll();
        }

        public Ticket Get(int id)
        {
            if (!Contains(id))
            {
                throw new ArgumentNullException($"Ticket with {id} not found");
            }
            return repository.Get(id);
        }

        public Ticket Create(Ticket ticket)
        {
            return repository.Create(ticket);
        }

        public Ticket Update(Ticket ticket)
        {
            if (!Contains(ticket.Id))
            {
                throw new ArgumentNullException($"Ticket with {ticket.Id} not found");
            }
            return repository.Update(ticket);
        }

       
        public Ticket Update(int id, JsonPatchDocument<Ticket> patch)
        {
            if (!Contains(id))
            {
                throw new ArgumentNullException($"Ticket with {id} not found");
            }
            var existingTicket = Get(id);

            patch.ApplyTo(existingTicket);

            return repository.Update(existingTicket);
        }

        public void Delete(int id)
        {
            if (!Contains(id))
            {
                throw new ArgumentNullException($"Ticket with {id} not found");
            }
            repository.Delete(id);
        }
    }
}
