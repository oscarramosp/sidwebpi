using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using BELayer;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;

namespace DALayer
{
    public class DAFormula : DABase
    {
        public string validarFormula(BEFormula formula)
        {
            string resultado = string.Empty;
            Database db = DatabaseFactory.CreateDatabase();
            System.Data.Common.DbCommand dbCommand = db.GetStoredProcCommand("SP_VALIDAR_FORMULA");
            db.AddInParameter(dbCommand, "@VC_FORMULA1", DbType.String, formula.formula);
            db.AddOutParameter(dbCommand, "@VC_LISTA_ERROR", DbType.String, 32);

            try
            {
                db.ExecuteNonQuery(dbCommand);
                return dbCommand.Parameters["@VC_LISTA_ERROR"].Value.ToString();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
