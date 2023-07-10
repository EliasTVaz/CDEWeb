using CDEWeb.Data.Model;
using CDEWeb.Data;
using Microsoft.EntityFrameworkCore;
using CDEWeb.DTOs;

namespace CDEWeb.Services
{
    public class PagamentoService : BaseService
    {
        //-------------------------------------------------------------
        #region construtor
        //-------------------------------------------------------------
        public PagamentoService( DataContext context )
            : base( context )
        {
        }
        //-------------------------------------------------------------
        #endregion construtor
        //-------------------------------------------------------------

        //-------------------------------------------------------------
        #region public class
        //-------------------------------------------------------------
        public async Task<List<Pagamento>> GetAll()
        {
            return ( await _context.Pagamentos.ToListAsync() );
        }

        //-------------------------------------------------------------
        public async Task<string> Add( PagamentoDto request )
        {
            var newPagamento = new Pagamento
            {
                ValorPago = request.Valor
            };

            var contrato = await _context.Contratos.FindAsync( request.IdContrato );

            if( contrato is null )
                return ( "Contrato não encontrado" );

            _context.Pagamentos.Add( newPagamento );

            await _context.SaveChangesAsync();

            return ( string.Empty );
        }

        //-------------------------------------------------------------
        #endregion public class
        //-------------------------------------------------------------
    }
}
