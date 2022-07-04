using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arta.Query.Model.ConsumerQueryModel
{
    public class ConsumerPermissionModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string SubDomain { get; set; }
        public bool HaveDomain { get; set; }
        public string Domain { get; set; }
        public DateTime ExpireDomain { get; set; }
        public DateTime RegisterDomain { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ExpireDate { get; set; }
        public string RegisterSource { get; set; }
        public bool Enable { get; set; }
        public string ThemeName { get; set; }
        public Language Language { get; set; }
        public bool IsExpired { get; set; }
        public int UntilToExpire { get; set; }

    }
}
