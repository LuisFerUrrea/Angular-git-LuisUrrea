using Microsoft.EntityFrameworkCore;
using ProyectoAngular.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ProyectoAngular.Context
{
    public interface IContextDB
    {
        DbSet<Message> Messages { get; set; }
        int SaveChanges();

        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default);
    }
}
