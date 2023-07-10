using CDEWeb.Data;
using CDEWeb.Data.Model;
using CDEWeb.DTOs;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CDEWeb.Services
{
    public class FuncionarioService : BaseService
    {
        //-------------------------------------------------------------
        #region construtor
        //-------------------------------------------------------------
        public FuncionarioService( DataContext context )
            : base( context )
        {
        }
        //-------------------------------------------------------------
        #endregion construtor
        //-------------------------------------------------------------

        //-------------------------------------------------------------
        #region public class
        //-------------------------------------------------------------
        public async Task<List<Funcionario>> GetAll()
        {
            return ( await _context.Funcionarios.ToListAsync() );
        }

        //-------------------------------------------------------------
        public async Task<Funcionario?> Find( int Id )
        {
            var funcionario = await _context.Funcionarios.FindAsync( Id );

            if( funcionario is null )
                return null;

            return ( funcionario );
        }

        //-------------------------------------------------------------
        public async Task<List<Funcionario>> Add( FuncionarioDto request )
        {
            var newFuncionario = new Funcionario
            {
                Nome = request.Nome,
                Salario = request.Salario
            };
            
            var empresa = await _context.Empresas.Where( x => x.Id.Equals( request.IdEmpresa ) ).FirstOrDefaultAsync();

            if( empresa is null )
                return null;

            newFuncionario.Empresa = empresa;

            _context.Funcionarios.Add( newFuncionario );

            await _context.SaveChangesAsync();

            return ( await _context.Funcionarios.ToListAsync() );
        }
        //-------------------------------------------------------------
        #endregion public class
        //-------------------------------------------------------------
    }
}
