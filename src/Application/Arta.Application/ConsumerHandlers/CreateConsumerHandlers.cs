using Anshan.Framework.Application.Command;
using Arta.Application.Contracts.ConsumerCommand;
using Arta.Domain.Consumers;
using Arta.Query.CunsumerQueries;
using Domain.Models.Consumers;
using Domain.Models.Users;
using FluentValidation;
using Framework.CommonUtility;
using Framework.Exceptions;
using Framework.Resources;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Arta.Application.ConsumerHandlers
{
    public class CreateConsumerCommandValidator : AbstractValidator<CreateConsumerCommand>
    {
        public CreateConsumerCommandValidator(IStringLocalizer<SharedResources> localizer)
        {
            RuleFor(p => p.SubDomain).NotEmpty().WithMessage(localizer["SubDomainNotEmpty"]).NotNull().WithMessage(localizer["SubDomainNotEmpty"]);
        }
    }
    public class CreateConsumerHandler : ICommandHandler<CreateConsumerCommand, int>
    {
        private readonly IConsumerRepository _consumerRepository;
        private readonly IConfiguration _configuration;

        public CreateConsumerHandler(IConsumerRepository consumerRepository, IConfiguration configuration)
        {
            _consumerRepository = consumerRepository;
            _configuration = configuration;
        }
        public async Task<int> Handle(CreateConsumerCommand command)
        {
            int userFreeDay = ConfigFreeDay();

            Consumer consumer = ConsumerFactory.CreateConsumerForm(command, userFreeDay, _configuration["NewUserThemeName"]);

            int Id = await _consumerRepository.CreateConsumer(consumer);

            return Id;
        }

        private int ConfigFreeDay()
        {
            int userFreeDay;
            int.TryParse(_configuration["FreeUserExpireDay"], out userFreeDay);
            if (userFreeDay == 0)
                userFreeDay = 30;
            return userFreeDay;
        }

    }
}
