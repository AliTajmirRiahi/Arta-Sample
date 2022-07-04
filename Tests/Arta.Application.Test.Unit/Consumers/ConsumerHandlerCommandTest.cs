using Arta.Framework.Application.Command;
using Arta.Application.ConsumerHandlers;
using Arta.Application.Contracts.ConsumerCommand;
using Arta.Domain.Consumers;
using Domain.Models.Consumers;
using FluentAssertions;
using FluentValidation.TestHelper;
using Framework.Resources;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Localization;
using NSubstitute;
using Arta.Application.Tests.Unit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Arta.Application.Test.Unit.Consumers
{
    public class ConsumerHandlerCommandTest
    {
        public ConsumerHandlerCommandTest()
        {
        }

        [Fact]
        public void Should_Create_Consumer()
        {
            // arrange
            var command = new CreateConsumerCommand()
            {
                SubDomain = "test",
                Language = Language.fa,
            };
            var repository = Substitute.For<IConsumerRepository>();
            
            var configuration = Substitute.For<IConfiguration>();

            var handler = new CreateConsumerHandler(repository, configuration);

            //Act
            handler.Handle(command).Wait();

            //Assertion
            repository.Received(Times.Once()).CreateConsumer(Verify.That<Consumer>(consumer =>
            {
                consumer.Title.Should().Be("test");
                consumer.SubDomain.Should().Be("test");
                consumer.Language.Should().Be(Language.fa);
            }));
        }


        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Should_have_error_when_properties_are_not_filled(string subDomain)
        {
            CreateConsumerCommandValidator _validator = new CreateConsumerCommandValidator(LocalizerFactory.SubstituteLocalizer());

            var model = new CreateConsumerCommand
            {
                SubDomain = subDomain,
            };
            var result = _validator.TestValidate(model);
            result.ShouldHaveAnyValidationError();
        }
    }
}
