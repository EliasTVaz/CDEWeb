using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CDEWeb.Data.Model
{
    public class Funcionario
    {
        //-------------------------------------------------------------
        #region Variáveis
        //-------------------------------------------------------------
        [Key]
        public int      Id          { get; set; }
        
        public string   Nome        { get; set; }
        
        public Empresa  Empresa     { get; set; }
        
        [Column( TypeName = "decimal(18,4)" )]
        public decimal  Salario     { get; set; }
        //-------------------------------------------------------------
        #endregion Variáveis
        //-------------------------------------------------------------

        //-------------------------------------------------------------
        #region Construtor
        //-------------------------------------------------------------
        public Funcionario()
        {
            Empresa = new Empresa();
            Nome = string.Empty;
        }
        //-------------------------------------------------------------
        #endregion Construtor
        //-------------------------------------------------------------
    }
}
