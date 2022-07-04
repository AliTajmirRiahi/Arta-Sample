using Arta.Domain.Catalogs;
using Arta.Domain.Consumers;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Arta.Domain.Test.Unit.Consumers
{
    public class ConsumerDomainTest
    {
        [Fact]
        public void Set_consumer_domain_should_set_domain_and_should_havedomain_be_true()
        {
            var Consumer = GetNewConsumer();

            Consumer.SetDomain("arta.com");

            Consumer.Domain.Should().Be("arta.com");
            Consumer.HaveDomain.Should().Be(true);
        }

        [Fact]
        public void Disable_consumer_should_Enable_be_false()
        {
            var Consumer = GetNewConsumer();

            Consumer.DisableConsumer();

            Consumer.Enable.Should().Be(false);
        }

        [Fact]
        public void Enable_consumer_should_Enable_be_true()
        {
            var Consumer = GetNewConsumer();

            Consumer.EnableConsumer();

            Consumer.Enable.Should().Be(true);
        }

        [Fact]
        public void Add_catalog_should_be_success()
        {
            var Consumer = GetNewConsumer();

            Consumer.AddCatalog(GetCatalog());

            Consumer.Catalogs.Count.Should().Be(1);
        }

        [Fact]
        public void Remove_catalog_should_be_success()
        {
            var Consumer = GetNewConsumer();

            var catalog = GetCatalog();

            Consumer.AddCatalog(catalog);

            Consumer.Catalogs.Count.Should().Be(1);

            Consumer.RemoveCatalog(catalog);

            Consumer.Catalogs.Count.Should().Be(0);
        }

        [Fact]
        public void Add_catalogs_should_be_success()
        {
            var Consumer = GetNewConsumer();

            Consumer.AddCatalog(GetCatalogs());

            Consumer.Catalogs.Count.Should().Be(3);
        }

        [Fact]
        public void Remove_catalogs_should_be_success()
        {
            var Consumer = GetNewConsumer();

            var catalogs = GetCatalogs();

            Consumer.AddCatalog(catalogs);

            Consumer.Catalogs.Count.Should().Be(3);

            Consumer.RemoveCatalog(catalogs);

            Consumer.Catalogs.Count.Should().Be(0);
        }

        [Fact]
        public void Change_language_should_be_success()
        {
            var Consumer = GetNewConsumer();

            Consumer.ChangeLanguage(Language.en);

            Consumer.Language.Should().Be(Language.en);
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

        private Catalog GetCatalog()
        {
            Catalog catalog = new Catalog()
            {
                Title = "Catalog1",
                Description = "Description Catalog1"
            };

            return catalog;
        }

        private List<Catalog> GetCatalogs()
        {
            List<Catalog> catalog = new List<Catalog>()
            {
                new Catalog()
                {
                    Title = "Catalog1",
                    Description = "Description Catalog1"
                },
                new Catalog()
                {
                    Title = "Catalog2",
                    Description = "Description Catalog2"
                },
                new Catalog()
                {
                    Title = "Catalog3",
                    Description = "Description Catalog3"
                },
            };

            return catalog;
        }
    }
}
