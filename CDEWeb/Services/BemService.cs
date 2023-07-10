using CDEWeb.Data;
using CDEWeb.Data.Model;
using CDEWeb.DTOs;
using Microsoft.EntityFrameworkCore;

namespace CDEWeb.Services
{
    public class BemService : BaseService
    {
        //-------------------------------------------------------------
        #region construtor
        //-------------------------------------------------------------
        public BemService( DataContext context )
            : base( context )
        {
        }
        //-------------------------------------------------------------
        #endregion construtor
        //-------------------------------------------------------------

        //-------------------------------------------------------------
        #region public class
        //-------------------------------------------------------------
        public async Task<List<Bem>> GetAll()
        {
            return ( await _context.Bens.ToListAsync() );
        }

        //-------------------------------------------------------------
        public async Task<List<Funcionario>> Add( BemDto request )
        {
            var newBem = new Bem
            {
                Descricao = request.Descricao,
                Valor = request.Valor
            };

            var funcionario = await _context.Funcionarios.Where( x => x.Id.Equals( request.IdFuncionario ) ).FirstOrDefaultAsync();

            if( funcionario is null )
                return null;

            newBem.Funcionario = funcionario;

            _context.Bens.Add( newBem );

            await _context.SaveChangesAsync();

            return ( await _context.Funcionarios.ToListAsync() );
        }

        //-------------------------------------------------------------
        #endregion public class
        //-------------------------------------------------------------
    }
}
