using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BELayer;
using DALayer;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;

namespace BLLayer
{
    public class BLFormula
    {
        public DTOResultado grabarFormula(BEFormula formula)
        {
            var oDAFormula = new DAFormula();
            var oDTOResultado = new DTOResultado();

            try
            {
                Int32 intValidacion = 0;

                if (intValidacion != (int)Constantes.CodigoGrabarFormula.Ok)
                {
                    oDTOResultado.Codigo = (int)Constantes.CodigoGrabarFormula.ErrorSintaxis;
                    oDTOResultado.Objeto = formula;
                    return oDTOResultado;
                }
            }
            catch (Exception ex)
            {
                ExceptionPolicy.HandleException(ex, "Policy");
                return null;
            }

            return oDTOResultado;
        }

        public string validarSintaxisFormula(BEFormula formula)
        {
            try
            {
                var strRutina = "";
                if (strRutina.IndexOf("ER1") >= 0)
                {
                    return "1";
                }
                if (strRutina.IndexOf("ER2") >= 0)
                {
                    return "2";
                }
                var oDAFormula = new DAFormula();
            }
            catch (Exception ex)
            {
                ExceptionPolicy.HandleException(ex, "Policy");
                return "";
            }
        }
    }
}
