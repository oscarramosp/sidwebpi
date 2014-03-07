using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using BELayer;


namespace DALayer
{
    public class DACanilla : DABase
    {
        public DataSet listarCanillas()
        {
            Database db = DatabaseFactory.CreateDatabase();
            System.Data.Common.DbCommand dbCommand = db.GetStoredProcCommand("SP_LISTAR_CANILLAS");
            DataSet ds = db.ExecuteDataSet(dbCommand);
            ds.Tables[0].TableName = "DataTable1";
            return db.ExecuteDataSet(dbCommand);
        }

        public List<BECanilla> selectCanillas(BECanilla canilla)
        {
            return null;
        }
    }
}
