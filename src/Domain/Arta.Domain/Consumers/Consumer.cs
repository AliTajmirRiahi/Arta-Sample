using Anshan.Framework.Domain;
using Arta.Domain.Catalogs;
using Domain.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arta.Domain.Consumers
{
    public class Consumer : AggregateRoot<int>
    {
        public Consumer()
        {
            Title = "";
            Description = "";
            SubDomain = "";
            Domain = "";
            HaveDomain = false;
            ExpireDomain = DateTime.Now;
            RegisterDomain = DateTime.Now;
            ExpireDate = DateTime.Now;
            RegisterSource = "";
            Enable = true;
            ThemeName = "";
        }

        public string Title { get; set; }
        public string Description { get; set; }
        public string SubDomain { get; set; }
        public bool HaveDomain { get; set; }
        public string Domain { get; set; }
        public DateTime ExpireDomain { get; set; }
        public DateTime RegisterDomain { get; set; }
        public DateTime ExpireDate { get; set; }
        public string RegisterSource { get; set; }
        public bool Enable { get; set; }
        public string ThemeName { get; set; }
        public Language Language { get; set; }


        public IReadOnlyCollection<Catalog> Catalogs => _catalogs;
        private readonly List<Catalog> _catalogs = new List<Catalog>();

        public void AddCatalog(Catalog catalog)
        {
            _catalogs.Add(catalog);
        }
        public void AddCatalog(List<Catalog> catalogs)
        {
            _catalogs.AddRange(catalogs);
        }

        public void RemoveCatalog(Catalog catalog)
        {
            _catalogs.Remove(catalog);
        }
        public void RemoveCatalog(List<Catalog> catalogs)
        {
            _catalogs.RemoveAll(p => catalogs.Any(k => k.Id == p.Id));
        }

        public void SetDomain(string subDomain)
        {
            Domain = subDomain;
            HaveDomain = true;
        }

        public void DisableConsumer()
        {
            Enable = false;
        }
        public void EnableConsumer()
        {
            Enable = true;
        }

        public void ChangeLanguage(Language language)
        {
            Language = language;
        }
    }
}
public enum Language
{
    fa = 0,
    en = 1,
    ar = 2,
}