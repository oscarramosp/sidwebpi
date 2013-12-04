﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using BELayer;

namespace DALayer
{
    public class DAPauta : DABase
    {
        public List<BEPauta> selectPautaProducto(BEPauta pauta)
        {
            List<BEPauta> listaPautas = new List<BEPauta>();
            Database db = DatabaseFactory.CreateDatabase();
            System.Data.Common.DbCommand dbCommand = db.GetStoredProcCommand("SP_LISTAR_PAUTAS_AGRUPA_PRODUCTOS");
            db.AddInParameter(dbCommand, "@DT_FECHA_PAUTA", DbType.Date, pauta.fechaPauta);
            IDataReader rdr = null;
            rdr = db.ExecuteReader(dbCommand);
            while (rdr.Read())
            {
                pauta = new BEPauta();
                pauta.codigoEmpresa = rdr.IsDBNull(rdr.GetOrdinal("CH_CODIGO_EMPRESA")) ? String.Empty : rdr.GetString(rdr.GetOrdinal("CH_CODIGO_EMPRESA"));
                pauta.razonSocialEmpresa = rdr.IsDBNull(rdr.GetOrdinal("VC_RAZON_SOCIAL_EMPRESA")) ? String.Empty : rdr.GetString(rdr.GetOrdinal("VC_RAZON_SOCIAL_EMPRESA"));
                pauta.codigoCanal = rdr.IsDBNull(rdr.GetOrdinal("CH_CODIGO_CANAL")) ? String.Empty : rdr.GetString(rdr.GetOrdinal("CH_CODIGO_CANAL"));
                pauta.descripcionCanal = rdr.IsDBNull(rdr.GetOrdinal("VC_DESCRIPCION_CANAL")) ? String.Empty : rdr.GetString(rdr.GetOrdinal("VC_DESCRIPCION_CANAL"));
                pauta.codigoProducto = rdr.IsDBNull(rdr.GetOrdinal("CH_CODIGO_PRODUCTO")) ? String.Empty : rdr.GetString(rdr.GetOrdinal("CH_CODIGO_PRODUCTO"));
                pauta.descripcionProducto = rdr.IsDBNull(rdr.GetOrdinal("VC_DESCRIPCION_PRODUCTO")) ? String.Empty : rdr.GetString(rdr.GetOrdinal("VC_DESCRIPCION_PRODUCTO"));
                pauta.fechaPauta = rdr.IsDBNull(rdr.GetOrdinal("DT_FECHA_PAUTA")) ? new DateTime() : rdr.GetDateTime(rdr.GetOrdinal("DT_FECHA_PAUTA"));
                pauta.cantidadSolicitada = rdr.IsDBNull(rdr.GetOrdinal("IN_CANTIDAD_SOLICITADA")) ? 0 : rdr.GetInt32(rdr.GetOrdinal("IN_CANTIDAD_SOLICITADA"));
                pauta.cantidadProyectada = rdr.IsDBNull(rdr.GetOrdinal("IN_CANTIDAD_PROYECTADA")) ? 0 : rdr.GetInt32(rdr.GetOrdinal("IN_CANTIDAD_PROYECTADA"));
                pauta.cantidadSugerida = rdr.IsDBNull(rdr.GetOrdinal("IN_CANTIDAD_SUGERIDA")) ? 0 : rdr.GetInt32(rdr.GetOrdinal("IN_CANTIDAD_SUGERIDA"));
                pauta.cantidadAprobada = rdr.IsDBNull(rdr.GetOrdinal("IN_CANTIDAD_APROBADA")) ? 0 : rdr.GetInt32(rdr.GetOrdinal("IN_CANTIDAD_APROBADA"));
                pauta.cantidadEntregada = rdr.IsDBNull(rdr.GetOrdinal("IN_CANTIDAD_ENTREGADA")) ? 0 : rdr.GetInt32(rdr.GetOrdinal("IN_CANTIDAD_ENTREGADA"));
                pauta.cantidadDevuelta = rdr.IsDBNull(rdr.GetOrdinal("IN_CANTIDAD_DEVUELTA")) ? 0 : rdr.GetInt32(rdr.GetOrdinal("IN_CANTIDAD_DEVUELTA"));
                listaPautas.Add(pauta);
            }
            return listaPautas;
        }
    }
}
