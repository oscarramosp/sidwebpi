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

        public DTOResultado proyectarPautas(BEPauta pauta)
        {
            var oDAPauta = new DAPauta();
            var oDTOResultado = new DTOResultado();

            try
            {
                Int32 intValidacion = oDAPauta.validarProyectarPauta(ref pauta);
                if (intValidacion != (int)Constantes.CodigoProyectarPauta.Ok)
                {
                    if (intValidacion == (int)Constantes.CodigoProyectarPauta.FechaProyeccionIncorrecta)
                    {
                        oDTOResultado.Codigo = (int)Constantes.CodigoProyectarPauta.FechaProyeccionIncorrecta;
                    }
                    else if (intValidacion == (int)Constantes.CodigoProyectarPauta.FueraDeHorario)
                    {
                        oDTOResultado.Codigo = (int)Constantes.CodigoProyectarPauta.FueraDeHorario;
                    }
                    else
                    {
                        oDTOResultado.Codigo = (int)Constantes.CodigoProyectarPauta.FormulaNoDefinida;
                    }
                    
                    oDTOResultado.Objeto = pauta;
                    return oDTOResultado;
                }
            }
            catch (Exception ex)
            {
                ExceptionPolicy.HandleException(ex, "Policy");
                oDTOResultado.Codigo = (int)Constantes.CodigoProyectarPauta.Error;
            }

            oDAPauta.mIniciarTransaccion();

            try
            {
                oDAPauta.proyectarPautas(pauta,oDAPauta.mtransaction);
                oDAPauta.mCommitTransaccion();
                oDTOResultado.Codigo = (int)Constantes.CodigoProyectarPauta.Ok;
                oDTOResultado.Objeto = pauta;
                return oDTOResultado;
            }
            catch (Exception ex)
            {
                oDAPauta.mRollbackTransaccion();
                ExceptionPolicy.HandleException(ex, "Policy");
                oDTOResultado.Codigo = (int)Constantes.CodigoProyectarPauta.Error;
            }

            return oDTOResultado;
        }
    }
}
