﻿using CDEWeb.Data;

namespace CDEWeb.Services
{
    public class BaseService
    {
        //-------------------------------------------------------------
        #region variáveis
        //-------------------------------------------------------------
        public DataContext  _context        { get; set; }
        //-------------------------------------------------------------
        #endregion variáveis
        //-------------------------------------------------------------

        //-------------------------------------------------------------
        #region construtor
        //-------------------------------------------------------------
        public BaseService( DataContext context )
        {
            _context = context;
        }
        //-------------------------------------------------------------
        #endregion construtor
        //-------------------------------------------------------------

    }
}
