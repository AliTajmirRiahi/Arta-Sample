using Arta.Framework.Application.Command;
using Arta.Framework.EF;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Localization;
using Framework.CommonUtility;
using Framework.Resources;
using Microsoft.Extensions.Configuration;
using Arta.Application.Contracts.CatalogCommand;
using Arta.Domain.Models.Catalogs;
using Arta.Query.CatalogQueries;

namespace Arta.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogController : BaseController
    {
        private readonly IBus _bus;
        private readonly IConfiguration _configuration;
        private readonly IStringLocalizer<SharedResources> _localizer;
        private readonly ICatalogQueryFacade _catalogQueryFacade;

        public CatalogController(IBus bus , IConfiguration configuration ,
            IStringLocalizer<SharedResources> localizer , ICatalogQueryFacade catalogQueryFacade)
        {
            _bus = bus;
            _configuration = configuration;
            _localizer = localizer;
            _catalogQueryFacade = catalogQueryFacade;
        }

        [HttpPost("add")]
        public async Task<IActionResult> CreateCatalog(CreateCatalogCommand command)
        {
            int id = await _bus.Dispatch<CreateCatalogCommand, int>(command);
            return CustomOk(id);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateCatalog(UpdateCatalogCommand command)
        {
            bool result = await _bus.Dispatch<UpdateCatalogCommand, bool>(command);
            return CustomOk(result);
        }

        [HttpGet("find/{id}")]
        public async Task<IActionResult> FindCatalog(int id)
        {
            return CustomOk(await _catalogQueryFacade.GetCatalogsById(id));
        }
    }
}
