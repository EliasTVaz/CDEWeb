using CDEWeb.Data;
using CDEWeb.Data.Model;
using CDEWeb.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace CDEWeb.Controllers
{
    [ApiController]
    public class EmpresaController : Controller
    {
        //-------------------------------------------------------------
        #region variáveis
        //-------------------------------------------------------------
        private readonly DataContext _context;
        private readonly EmpresaService _empresaService;
        //-------------------------------------------------------------
        #endregion variáveis
        //-------------------------------------------------------------

        //-------------------------------------------------------------
        #region construtor
        //-------------------------------------------------------------
        public EmpresaController( DataContext context )
        {
            _context = context;
            _empresaService = new EmpresaService( _context );
        }
        //-------------------------------------------------------------
        #endregion construtor
        //-------------------------------------------------------------

        //-------------------------------------------------------------
        #region public class
        //-------------------------------------------------------------
        [HttpGet]
        [Route( "api/EmpresaController/GetAll" )]
        public async Task<ActionResult<List<Empresa>>> GetAll()
        {
            return Ok( await _empresaService.GetAll() );
        }

        //-------------------------------------------------------------
        [HttpGet]
        [Route( "api/EmpresaController/Find" )]
        public async Task<ActionResult<Empresa>> Find( int Id )
        {
            var result = await _empresaService.Find( Id );

            if( result == null )
                return NotFound( "Nenhum empresa foi encontrada com o identificador informado." );

            return Ok( result );
        }

        //-------------------------------------------------------------
        [HttpPost]
        [Route( "api/EmpresaController/Add" )]
        public async Task<ActionResult<List<Empresa>>> Add( [FromBody] Empresa empresa )
        {
            var result = await _empresaService.Add( empresa );
            return Ok( result );
        }

        //-------------------------------------------------------------
        [HttpDelete]
        [Route( "api/EmpresaController/DeleteCar" )]
        public async Task<ActionResult> Delete( int IdEmpresa )
        {
            string result = await _empresaService.Delete( IdEmpresa );

            if( result.IsNullOrEmpty() )
                return Ok();
            else
                return NotFound( result );
        }

        //-------------------------------------------------------------
        #endregion public class
        //-------------------------------------------------------------
    }
}
