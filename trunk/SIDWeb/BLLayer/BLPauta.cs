using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using BELayer;
using DALayer;

namespace BLLayer
{
    public class BLPauta
    {
        public List<BEPauta> selectPautaProducto(BEPauta pauta)
        {
            List<BEPauta> listaPautas = new List<BEPauta>();
            
            try
            {
                DAPauta oDAPauta = new DAPauta();
                listaPautas = oDAPauta.selectPautaProducto(pauta);
            }
            catch (Exception ex)
            {
                ExceptionPolicy.HandleException(ex, "Policy");
            }

            return listaPautas;
        }
    }
}
