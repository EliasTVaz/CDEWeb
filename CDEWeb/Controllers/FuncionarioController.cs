using CDEWeb.Data;
using CDEWeb.Data.Model;
using CDEWeb.DTOs;
using CDEWeb.Services;
using Microsoft.AspNetCore.Mvc;

namespace CDEWeb.Controllers
{
    [ApiController]
    public class FuncionarioController : ControllerBase
    {

        //-------------------------------------------------------------
        #region variáveis
        //-------------------------------------------------------------
        private readonly DataContext _context;
        private readonly FuncionarioService _funcionarioService;
        //-------------------------------------------------------------
        #endregion variáveis
        //-------------------------------------------------------------

        //-------------------------------------------------------------
        #region construtor
        //-------------------------------------------------------------
        public FuncionarioController( DataContext context )
        {
            _context = context;
            _funcionarioService = new FuncionarioService( _context );
        }
        //-------------------------------------------------------------
        #endregion construtor
        //-------------------------------------------------------------

        //-------------------------------------------------------------
        #region public class
        //-------------------------------------------------------------
        [HttpGet]
        [Route( "api/FuncionarioController/GetAll" )]
        public async Task<ActionResult<List<Empresa>>> GetAll()
        {
            return Ok( await _funcionarioService.GetAll() );
        }

        //-------------------------------------------------------------
        [HttpGet]
        [Route( "api/FuncionarioController/Find" )]
        public async Task<ActionResult<Empresa>> Find( int Id )
        {
            var result = await _funcionarioService.Find( Id );

            if( result == null )
                return NotFound( "Nenhum funcionário foi encontrado com o identificador informado." );

            return Ok( result );
        }

        //-------------------------------------------------------------
        [HttpPost]
        [Route( "api/FuncionarioController/Add" )]
        public async Task<ActionResult<List<Funcionario>>> Add( [FromBody] FuncionarioDto request )
        {
            var result = await _funcionarioService.Add( request );

            if( result == null )
                return NotFound( "Erro" );

            return Ok( result );
        }

        //-------------------------------------------------------------
        #endregion public class
        //-------------------------------------------------------------
    }
}
