using CDEWeb.Data;
using CDEWeb.Data.Model;
using CDEWeb.DTOs;
using CDEWeb.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace CDEWeb.Controllers
{
    [ApiController]
    public class PagamentoController : ControllerBase
    {
        //-------------------------------------------------------------
        #region variáveis
        //-------------------------------------------------------------
        private readonly DataContext _context;
        private readonly PagamentoService _pagamentoService;
        //-------------------------------------------------------------
        #endregion variáveis
        //-------------------------------------------------------------

        //-------------------------------------------------------------
        #region construtor
        //-------------------------------------------------------------
        public PagamentoController( DataContext context )
        {
            _context = context;
            _pagamentoService = new PagamentoService( _context );
        }
        //-------------------------------------------------------------
        #endregion construtor
        //-------------------------------------------------------------

        [HttpGet]
        [Route( "api/PagamentoController/GetAll" )]
        public async Task<ActionResult<List<Pagamento>>> GetAll()
        {
            return Ok( await _pagamentoService.GetAll() );
        }

        //-------------------------------------------------------------
        [HttpPost]
        [Route( "api/PagamentoController/Add" )]
        public async Task<ActionResult> Add( [FromBody] PagamentoDto request )
        {
            var result = await _pagamentoService.Add( request );

            if( result.IsNullOrEmpty() )
                return Ok( "Pagamento registrado com sucesso." );
            else
                return BadRequest( result );
        }
    }
}
