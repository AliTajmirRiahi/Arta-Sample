using Arta.Domain.Catalogs;
using Arta.Domain.Consumers;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Arta.Domain.Test.Unit.Catalogs
{
    public class CatalogDomainTest
    {
        [Fact]
        public void Set_Catalog_consumer_should_should_be_success()
        {
            var Consumer = GetNewConsumer();
            var Catalog = GetCatalog();

            Catalog.SetConsumer(Consumer);

            Catalog.Consumer.SubDomain.Should().Be(Consumer.SubDomain);
            Catalog.Consumer.Description.Should().Be(Consumer.Description);
            Catalog.Consumer.Enable.Should().Be(Consumer.Enable);
            Catalog.Consumer.Language.Should().Be(Consumer.Language);
        }
        private Catalog GetCatalog()
        {
            Catalog catalog = new Catalog()
            {
                Title = "Catalog1",
                Description = "Description Catalog1"
            };

            return catalog;
        }
        private Consumer GetNewConsumer()
        {
            Consumer consumer = new Consumer()
            {
                SubDomain = "arta",
                Description = "test",
                Enable = true,
                Language = Language.fa
            };

            return consumer;
        }
    }
}
