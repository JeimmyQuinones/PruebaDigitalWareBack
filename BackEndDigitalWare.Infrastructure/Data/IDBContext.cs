using BackEndDigitalWare.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BackEndDigitalWare.Infrastructure.Data
{
    public interface IDBContext
    {
        DbSet<Bill> Bill { get; set; }
        DbSet<Customer> Customer { get; set; }
        DbSet<DetailBill> DetailBill { get; set; }
        DbSet<IdentificationType> IdentificationType { get; set; }
        DbSet<Mark> Mark { get; set; }
        DbSet<Product> Product { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
        void RemoveRange(IEnumerable<object> entities);
        EntityEntry Update(object entity);
    }
}
