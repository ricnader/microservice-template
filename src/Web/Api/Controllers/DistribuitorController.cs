using Microsoft.AspNetCore.Mvc;
using Serilog;
using Application.Contracts;
using Application.Dtos;
using Application.Models;
using Application.DTOs.Distribuitor;

namespace Distribuitor.Api.Controllers
{
    [ApiController]
    [Route("Distribuitors")]
    public class DistribuitorController : ApiBaseController
    {
        private readonly IDistribuitorService _distribuitorService;

        public DistribuitorController(IDistribuitorService distribuitorService)
        {
            _distribuitorService = distribuitorService;
        }

        /// <summary>
        /// Obtem a listagem de distribuidores, conforme os filtros.
        /// </summary>
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAll([FromQuery] GridDTO gridDTO,
            [FromQuery] DistribuitorFilterDTO distribuitorFilterDTO)
        {
            var result = await _distribuitorService.GetAllAsync(gridDTO, distribuitorFilterDTO);
            var total = result.Count();

            Log.Logger.Information("Retorno dos distribuidores completo.");

            return OKReponse(result, total);

        }

        /// <summary>
        /// Cria um novo distribuidor do tipo Matriz ou Filial.
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<DistribuitorDTO>> Create([FromBody] DistribuitorCreateDTO distribuitorCreateDTO)
        {
            var distribuitorCreated = await _distribuitorService.CreateDistribuitor(distribuitorCreateDTO);

            string msgSucesso = "O distribuidor foi criado com sucesso.";

            Log.Logger.Information(msgSucesso);

            return OKReponse(distribuitorCreated, msgSucesso);
        }

        /// <summary>
        /// Atualiza o distribuidor.
        /// </summary>
        /// <param name="distribuitor"></param>
        /// <returns></returns>
        /// <exception cref="KeyNotFoundException"></exception>
        [HttpPut]
        [Route("")]
        public async Task<ActionResult> Update([FromBody] DistribuitorUpdateDTO distribuitor)
        {
            var id = distribuitor.Id;
            var existingDistribuitor = _distribuitorService.GetByIdAsync(id);

            if (existingDistribuitor == null)
                throw new KeyNotFoundException();

            await Task.Run(() => _distribuitorService.UpdateDistribuitor(distribuitor));
            return OKReponse(true, "O distribuidor foi atualziado com sucesso.");
        }

        /// <summary>
        /// Atualiza o status do distribuidor.
        /// </summary>
        [HttpPatch]
        [Route("update-status")]
        public async Task<ActionResult> UpdateStatus([FromBody] DistribuitorUpdateStatusDTO distribuitorStatusDTO)
        {
            await _distribuitorService.UpdateStatus(distribuitorStatusDTO);

            return OKReponse("O status do distribuidor foi atualizado com sucesso.");
        }
    }
}