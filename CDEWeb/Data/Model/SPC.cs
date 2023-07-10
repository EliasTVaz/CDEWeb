using CDEWeb.Data.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CDEWeb.Data.Model
{
    public class SPC
    {
        //-------------------------------------------------------------
        #region Variáveis
        //-------------------------------------------------------------
        [Key]
        
        public int          Id              { get; set; }
        
        public Funcionario  Funcionario     { get; set; }
        
        public DateTime     DataEntrada     { get; set; }
        //-------------------------------------------------------------
        #endregion Variáveis
        //-------------------------------------------------------------

        //-------------------------------------------------------------
        #region Construtor
        //------------------------------------------------------------
        public SPC()
        {
            Funcionario = new Funcionario();
        }
        //-------------------------------------------------------------
        #endregion Construtor
        //-------------------------------------------------------------

    }
}
