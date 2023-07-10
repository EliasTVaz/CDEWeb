using CDEWeb.Data.Model;
using CDEWeb.Data;
using Microsoft.EntityFrameworkCore;
using CDEWeb.DTOs;

namespace CDEWeb.Services
{
    public class ContratoService : BaseService
    {
        //-------------------------------------------------------------
        #region construtor
        //-------------------------------------------------------------
        public ContratoService( DataContext context )
            : base( context )
        {
        }
        //-------------------------------------------------------------
        #endregion construtor
        //-------------------------------------------------------------

        //-------------------------------------------------------------
        #region public class
        //-------------------------------------------------------------
        public async Task<List<Contrato>> GetAll()
        {
            var contrato = await _context.Contratos
                                 .Include( c => c.Funcionario )
                                 .Include( c => c.Vendedor )
                                 .Include( c => c.Bem )
                                 .Include( c => c.Pagamentos )
                                 .ToListAsync();
            if( contrato is null )
                return ( null );

            return ( contrato );
        }

        //-------------------------------------------------------------
        public async Task<string> Add( ContratoDto request )
        {
            var newContrato = new Contrato
            {
                dataInicio = request.DataInicio,
                dataFim = request.DataFim,
                ValorEmprestimo = request.ValorEmprestimo
            };

            var funcionario = await _context.Funcionarios.FindAsync( request.IdFuncionario );

            if( funcionario is null )
                return ( "Funcionário não encontrado" );
            
            var spc = await _context.SPCs.Where( x => x.Funcionario.Id.Equals( request.IdFuncionario ) ).FirstOrDefaultAsync();

            if( spc is not null )
                return ( "Funcionário está no SPC, não pode fazer emprestimos." );

            var vendedor = await _context.Vendedores.FindAsync( request.IdVendedor );

            if ( vendedor is null )
                return ( "Vendedor não encontrado" );

            var bem = await _context.Bens.FindAsync( request.IdBem );

            if( bem is null )
                return ( "Bem não cadastrado." );

            if( ( request.DataInicio == DateTime.MinValue || request.DataFim == DateTime.MinValue ) ||
                ( DateTime.Compare( request.DataInicio, request.DataFim ) > 0 ) )
                return ( "Datas inválidas." );

            if ( ( ( request.DataFim.Subtract( request.DataInicio ).Days ) / 30 > Const.MAX_MESES_ENDIVIMANETO ) )
                return ( string.Format( "O limite de tempo para o contrato é de {0} meses.", Const.MAX_MESES_ENDIVIMANETO ) );

            if( ( funcionario.Salario < request.ValorEmprestimo ) ||
                ( funcionario.Salario / request.ValorEmprestimo ) > Const.PERC_LIMITE_ENDIVIDAMENTO )
                return ( string.Format( "O limite de endividamento é de {0}% do salário do Funcionários.", Const.MAX_MESES_ENDIVIMANETO ) );

            newContrato.Funcionario = funcionario;
            newContrato.Vendedor = vendedor;
            newContrato.Bem = bem;

            _context.Contratos.Add( newContrato );
            await _context.SaveChangesAsync();

            return( string.Empty );
        }

        //-------------------------------------------------------------
        #endregion public class
        //-------------------------------------------------------------

        //-------------------------------------------------------------
    }
}
