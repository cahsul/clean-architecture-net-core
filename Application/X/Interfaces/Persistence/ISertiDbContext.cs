using Domain.Entities;
using Domain.Entities.Serti;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.X.Interfaces.Persistence
{
    public interface ISertiDbContext
    {
        public DbSet<Domain.Entities.Serti.Event> Events { get; set; }
        public DbSet<EventSpeaker> EventSpeakers { get; set; }
        public DbSet<Participant> Participants { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        public DatabaseFacade Database { get; }
    }
}
