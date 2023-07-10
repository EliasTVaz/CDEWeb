using CDEWeb.Data;
using CDEWeb.Data.Model;
using CDEWeb.Services;
using Microsoft.AspNetCore.Mvc;

namespace CDEWeb.Controllers
{
    [ApiController]
    public class SPCController : ControllerBase
    {

        //-------------------------------------------------------------
        #region variáveis
        //-------------------------------------------------------------
        private readonly DataContext _context;
        private readonly SPCService _SPCService;
        //-------------------------------------------------------------
        #endregion variáveis
        //-------------------------------------------------------------

        //-------------------------------------------------------------
        #region construtor
        //-------------------------------------------------------------
        public SPCController( DataContext context )
        {
            _context = context;
            _SPCService = new SPCService( _context );
        }
        //-------------------------------------------------------------
        #endregion construtor
        //-------------------------------------------------------------

        //-------------------------------------------------------------
        #region public class
        //-------------------------------------------------------------
        [HttpGet]
        [Route( "api/SPCController/GetAll" )]
        public async Task<ActionResult<List<SPC>>> GetAll()
        {
            return Ok( await _SPCService.GetAll() );
        }

        //-------------------------------------------------------------
        [HttpGet]
        [Route( "api/SPCController/Find" )]
        public async Task<ActionResult<SPC>> Find( int IdFuncionario )
        {
            var result = await _SPCService.Find( IdFuncionario );

            if( result == null )
                return NotFound( "Nenhum funcionario foi encontrado com o identificador informado." );

            return Ok( result );
        }

        //-------------------------------------------------------------
        [HttpPost]
        [Route( "api/SPCController/Add" )]
        public async Task<ActionResult<List<SPC>>> Add( [FromBody] SPC spc )
        {
            var result = await _SPCService.Add( spc );
            return Ok( result );
        }

        //-------------------------------------------------------------
        [HttpDelete]
        [Route( "api/SPCController/Delete" )]
        public async Task<ActionResult<SPC>> Delete( int Id )
        {
            var result = await _SPCService.Delete( Id );

            if( result is null )
                return NotFound( "Nenhum registro de SPC encontrado." );

            return Ok( result );
        }

        //-------------------------------------------------------------
        #endregion public class
        //-------------------------------------------------------------
    }
}
