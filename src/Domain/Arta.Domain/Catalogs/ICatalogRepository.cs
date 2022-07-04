using Anshan.Framework.Application;
using Arta.Domain.Catalogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arta.Domain.Models.Catalogs
{
    public interface ICatalogRepository : IRepository
    {
        Task<int> CreateCatalog(Catalog catalog);
        Task<int> SaveChange();
        Task<Catalog> FindById(int Id);
    }
}
