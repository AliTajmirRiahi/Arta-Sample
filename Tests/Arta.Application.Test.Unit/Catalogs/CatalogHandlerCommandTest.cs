using Arta.Application.CatalogHandlers;
using Arta.Application.Contracts.CatalogCommand;
using Arta.Domain.Models.Catalogs;
using Castle.Core.Configuration;
using NSubstitute;
using Arta.Application.Tests.Unit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Arta.Domain.Catalogs;
using FluentAssertions;
using FluentValidation.TestHelper;
using Framework.Exceptions;

namespace Arta.Application.Test.Unit.Catalogs
{
    public class CatalogHandlerCommandTest
    {
        public CatalogHandlerCommandTest()
        {

        }

        [Fact]
        public void Should_Create_Catalog()
        {
            // arrange
            var command = new CreateCatalogCommand()
            {
                ConsumerId = 1,
                Description = "test",
                Title = "test",
            };
            var repository = Substitute.For<ICatalogRepository>();

            var handler = new CreateCatalogHandler(repository);

            //Act
            handler.Handle(command).Wait();

            //Assertion
            repository.Received(Times.Once()).CreateCatalog(Verify.That<Catalog>(consumer =>
            {
                consumer.Title.Should().Be("test");
                consumer.Description.Should().Be("test");
                consumer.ConsumerId.Should().Be(1);
            }));
        }


        [Fact]
        public void NotFound_catalog_to_update_catalog_Should_throw_rest_exception()
        {
            // arrange
            var command = new UpdateCatalogCommand()
            {
                Id = -1,
                Description = "test",
                Title = "test",
            };
            var repository = Substitute.For<ICatalogRepository>();

            var localizer = LocalizerFactory.SubstituteLocalizer();

            var handler = new UpdateCatalogHandler(repository, localizer);

            //Act
            Action act = () => handler.Handle(command).Wait();

            //Assertion
            act.Should().Throw<RestException>();
        }

        [Theory]
        [InlineData("",0)]
        [InlineData(null, 0)]
        [InlineData("",-1)]
        [InlineData(null,-1)]
        public void Should_have_error_when_properties_are_not_filled(string title, int consumerId)
        {
            CreateCatalogCommandValidator _validator = new CreateCatalogCommandValidator(LocalizerFactory.SubstituteLocalizer());

            var model = new CreateCatalogCommand
            {
                ConsumerId = consumerId,
                Title = title,
            };
            var result = _validator.TestValidate(model);
            result.ShouldHaveAnyValidationError();
        }
    }
}
