using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CDEWeb.Data.Model
{
    public class Bem
    {
        //-------------------------------------------------------------
        #region Variáveis
        //-------------------------------------------------------------
        [Key]
        public int          Id              { get; set; }
        public Funcionario  Funcionario     { get; set; }
        public string       Descricao       { get; set; }
        
        [Column( TypeName = "decimal(18,4)" )]
        public decimal      Valor           { get; set; }
        //-------------------------------------------------------------
        #endregion Variáveis
        //-------------------------------------------------------------

        //-------------------------------------------------------------
        #region Construtor
        //-------------------------------------------------------------
        public Bem()
        {
            Descricao = string.Empty;
            Funcionario = new Funcionario();
        }
        //-------------------------------------------------------------
        #endregion Construtor
        //-------------------------------------------------------------
    }

}
