using Arta.Domain.Catalogs;
using Arta.Domain.Models.Catalogs;
using Arta.Persistence.EF.Contexts;
using Framework.Exceptions;
using Framework.Resources;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arta.Persistence.EF.Repositories
{
    public class CatalogRepository : ICatalogRepository
    {
        private readonly ArtaDbContext _dbContext;
        private readonly IStringLocalizer<SharedResources> _localizer;

        public CatalogRepository(ArtaDbContext dbContext, IStringLocalizer<SharedResources> localizer)
        {
            _dbContext = dbContext;
            _localizer = localizer;
        }

        public async Task<int> CreateCatalog(Catalog catalog)
        {
            _dbContext.Catalogs.Add(catalog);

            if(await SaveChange() > 0)
                return catalog.Id;

            throw new RestException(System.Net.HttpStatusCode.BadRequest, _localizer["DefaultSaveChangeError"]);
        }

        public async Task<Catalog> FindById(int id)
        {
            return await _dbContext.Catalogs.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<int> SaveChange()
        {
            return await _dbContext.SaveChangesAsync();
        }

    }
}