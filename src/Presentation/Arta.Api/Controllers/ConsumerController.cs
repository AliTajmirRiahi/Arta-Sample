using Anshan.Framework.Application.Command;
using Arta.Application.Contracts.ConsumerCommand;
using Arta.Query.CunsumerQueries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System.Threading.Tasks;

namespace Arta.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsumerController : BaseController
    {
        private readonly IBus _bus;
        private readonly IConsumerQueryFacade _consumerQueryFacade;
        private readonly IStringLocalizer<SharedResources> _localizer;

        public ConsumerController(IBus bus, IConsumerQueryFacade consumerQueryFacade,
            IStringLocalizer<SharedResources> localizer)
        {
            _bus = bus;
            _consumerQueryFacade = consumerQueryFacade;
            _localizer = localizer;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateConsumer(CreateConsumerCommand command)
        {
            int Id = await _bus.Dispatch<CreateConsumerCommand, int>(command);
            return CustomOk(Id);
        }

        [HttpGet("existSubDomain/{subDomain}")]
        public async Task<IActionResult> GetIsExistSubDomain(string subDomain)
        {
            return CustomOk(new { isExist = await _consumerQueryFacade.IsExitSubDomain(subDomain) });
        }

        [HttpGet("find/{id}")]
        public async Task<IActionResult> GetConsumerById(int id)
        {
            return CustomOk(await _consumerQueryFacade.GetCunsumersById(id));
        }

        [HttpGet("catalogs/{id}")]
        public async Task<IActionResult> GetCatalogsConsumerById(int id)
        {
            return CustomOk(await _consumerQueryFacade.GetCunsumerCatalogsById(id));
        }
    }
}
