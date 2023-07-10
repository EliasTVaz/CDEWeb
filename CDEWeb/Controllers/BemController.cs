using CDEWeb.Data;
using CDEWeb.Data.Model;
using CDEWeb.DTOs;
using CDEWeb.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CDEWeb.Controllers
{
    [ApiController]
    public class BemController : ControllerBase
    {
        //-------------------------------------------------------------
        #region variáveis
        //-------------------------------------------------------------
        private readonly DataContext _context;
        private readonly BemService _bemService;
        //-------------------------------------------------------------
        #endregion variáveis
        //-------------------------------------------------------------

        //-------------------------------------------------------------
        #region construtor
        //-------------------------------------------------------------
        public BemController( DataContext context )
        {
            _context = context;
            _bemService = new BemService( _context );
        }
        //-------------------------------------------------------------
        #endregion construtor
        //-------------------------------------------------------------

        //-------------------------------------------------------------
        #region public class
        //-------------------------------------------------------------
        [HttpGet]
        [Route( "api/BemController/GetAll" )]
        public async Task<ActionResult<List<Empresa>>> GetAll()
        {
            return Ok( await _bemService.GetAll() );
        }

        //-------------------------------------------------------------
        [HttpPost]
        [Route( "api/BemController/Add" )]
        public async Task<ActionResult<List<Funcionario>>> Add( [FromBody] BemDto request )
        {
            var result = await _bemService.Add( request );

            if( result == null )
                return NotFound( "Erro" );

            return Ok( result );
        }

        //-------------------------------------------------------------
        #endregion public class
        //-------------------------------------------------------------
    }
}
