using Domain.Models.Consumers;
using Arta.Persistence.EF.Contexts;
using Domain.Models.Users;
using Framework.Exceptions;
using Framework.Resources;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arta.Domain.Consumers;

namespace Arta.Persistence.EF.Repositories
{
    public class ConsumerRepository : IConsumerRepository
    {
        private readonly ArtaDbContext _dbContext;
        private readonly IStringLocalizer<SharedResources> _localizer;

        public ConsumerRepository(ArtaDbContext dbContext, IStringLocalizer<SharedResources> localizer)
        {
            _dbContext = dbContext;
            _localizer = localizer;
        }
        public Task<int> SaveChange()
        {
            throw new NotImplementedException();
        }
        public async Task<int> CreateConsumer(Consumer consumer)
        {
            _dbContext.Consumers.Add(consumer);

            if (await _dbContext.SaveChangesAsync() > 0)
                return consumer.Id;

            throw new RestException( System.Net.HttpStatusCode.BadRequest, _localizer["DefaultSaveChangeError"]);
        }

        public async Task<bool> IsSubDoaminDuplicate(string subDomain)
        {
            return await _dbContext.Consumers.AnyAsync(p => p.SubDomain == subDomain);
        }

    }
}
