using CDEWeb.Data;
using CDEWeb.Data.Model;
using CDEWeb.Services;
using Microsoft.AspNetCore.Mvc;

namespace CDEWeb.Controllers
{
    [ApiController]
    public class VendedorController : ControllerBase
    {

        //-------------------------------------------------------------
        #region variáveis
        //-------------------------------------------------------------
        private readonly DataContext _context;
        private readonly VendedorService _vendedorService;
        //-------------------------------------------------------------
        #endregion variáveis
        //-------------------------------------------------------------

        //-------------------------------------------------------------
        #region construtor
        //-------------------------------------------------------------
        public VendedorController( DataContext context )
        {
            _context = context;
            _vendedorService = new VendedorService( _context );
        }
        //-------------------------------------------------------------
        #endregion construtor
        //-------------------------------------------------------------

        //-------------------------------------------------------------
        #region public class
        //-------------------------------------------------------------
        [HttpGet]
        [Route( "api/VendedorController/GetAll" )]
        public async Task<ActionResult<List<Empresa>>> GetAll()
        {
            return Ok( await _vendedorService.GetAll() );
        }

        //-------------------------------------------------------------
        [HttpGet]
        [Route( "api/VendedorController/Find" )]
        public async Task<ActionResult<Empresa>> Find( int Id )
        {
            var result = await _vendedorService.Find( Id );

            if( result == null )
                return NotFound( "Nenhum funcionário foi encontrado com o identificador informado." );

            return Ok( result );
        }

        //-------------------------------------------------------------
        [HttpPost]
        [Route( "api/VendedorController/Add" )]
        public async Task<ActionResult<List<Funcionario>>> Add( [FromBody] Vendedor vendedor )
        {
            var result = await _vendedorService.Add( vendedor );
            return Ok( result );
        }

        //-------------------------------------------------------------
        #endregion public class
        //-------------------------------------------------------------
    }
}
