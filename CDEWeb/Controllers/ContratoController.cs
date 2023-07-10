using CDEWeb.Data;
using CDEWeb.Data.Model;
using CDEWeb.DTOs;
using CDEWeb.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace CDEWeb.Controllers
{
    [ApiController]
    public class ContratoController : ControllerBase
    {
        //-------------------------------------------------------------
        #region variáveis
        //-------------------------------------------------------------
        private readonly DataContext _context;
        private readonly ContratoService _contratoService;
        //-------------------------------------------------------------
        #endregion variáveis
        //-------------------------------------------------------------

        //-------------------------------------------------------------
        #region construtor
        //-------------------------------------------------------------
        public ContratoController( DataContext context )
        {
            _context = context;
            _contratoService = new ContratoService( _context );
        }
        //-------------------------------------------------------------
        #endregion construtor
        //-------------------------------------------------------------

        //-------------------------------------------------------------
        #region public class
        //-------------------------------------------------------------
        [HttpGet]
        [Route( "api/ContratoController/GetAll" )]
        public async Task<ActionResult<List<Contrato>>> GetAll()
        {
            return Ok( await _contratoService.GetAll() );
        }

        //-------------------------------------------------------------
        [HttpPost]
        [Route( "api/ContratoController/Add" )]
        public async Task<ActionResult> Add( [FromBody] ContratoDto request )
        {
            var result = await _contratoService.Add( request );

            if( result.IsNullOrEmpty() )
                return Ok( "Contrato criado com sucesso." );
            else
                return BadRequest( result );
        }
        //-------------------------------------------------------------
        #endregion public class
        //-------------------------------------------------------------
    }
}
