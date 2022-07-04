using Anshan.Framework.Application.Command;
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
using Microsoft.Extensions.Localization;

namespace Arta.Application.CatalogHandlers
{
    public class CreateCatalogCommandValidator : AbstractValidator<CreateCatalogCommand>
    {
        public CreateCatalogCommandValidator(IStringLocalizer<SharedResources> localizer)
        {
            RuleFor(p => p.Title).NotEmpty().WithMessage(localizer["TitleNotEmpty"]).NotNull().WithMessage(localizer["TitleNotEmpty"]);
            RuleFor(p => p.ConsumerId).LessThanOrEqualTo(0).WithMessage(localizer["ConsumerNotEmpty"]);
        }
    }
    public class CreateCatalogHandler : ICommandHandler<CreateCatalogCommand, int>
    {
        private readonly ICatalogRepository _catalogRepository;

        public CreateCatalogHandler(ICatalogRepository catalogRepository)
        {
            _catalogRepository = catalogRepository;
        }
        public async Task<int> Handle(CreateCatalogCommand command)
        {
            Catalog catalog = CatalogFactory.CreateCatalog(command.Title, command.Description, command.ConsumerId);

            return await _catalogRepository.CreateCatalog(catalog);
        }
    }
}
