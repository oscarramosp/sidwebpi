using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Common;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using DALayer;
using BELayer;
using System.Data;


namespace BLLayer
{
    public class BLCanilla
    {
        public DataSet listarCanillas()
        {
            DACanilla oDACanilla = new DACanilla();
            try
            {
                return oDACanilla.listarCanillas();
            }
            catch (Exception ex)
            {
                ExceptionPolicy.HandleException(ex, "Policy");
                return null;
            }
        }
    }
}
