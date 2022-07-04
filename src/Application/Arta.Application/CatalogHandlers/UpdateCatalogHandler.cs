using Arta.Framework.Application.Command;
using FluentValidation;
using Framework.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arta.Application.Contracts.CatalogCommand;
using Arta.Domain.Catalogs;
using Arta.Domain.Models.Catalogs;
using Framework.Exceptions;
using Microsoft.Extensions.Localization;

namespace Arta.Application.CatalogHandlers
{

    public class UpdateCatalogHandler : ICommandHandler<UpdateCatalogCommand, bool>
    {
        private readonly ICatalogRepository _catalogRepository;
        private readonly IStringLocalizer<SharedResources> _localizer;

        public UpdateCatalogHandler(ICatalogRepository catalogRepository, IStringLocalizer<SharedResources> localizer)
        {
            _catalogRepository = catalogRepository;
            _localizer = localizer;
        }
        public async Task<bool> Handle(UpdateCatalogCommand command)
        {
            Catalog catalog = await _catalogRepository.FindById(command.Id);

            if (catalog == null)
                throw new RestException(System.Net.HttpStatusCode.NotFound, _localizer["RecordNotFound"]);

            CatalogFactory.UpdateCatalog(catalog ,command.Title, command.Description);

            return await _catalogRepository.SaveChange() > 0;
        }
    }
}
