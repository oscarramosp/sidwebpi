using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BELayer
{
    public class BEPauta : BEBase
    {
        public string codigoEmpresa { get; set; }
        public string razonSocialEmpresa { get; set; }
        public string codigoCanal { get; set; }
        public string descripcionCanal { get; set; }
        public string codigoProducto { get; set; }
        public string descripcionProducto { get; set; }
        public DateTime? fechaPauta { get; set; }
        public Int32 cantidadSolicitada { get; set; }
        public Int32 cantidadProyectada { get; set; }
        public Int32 cantidadSugerida { get; set; }
        public Int32 cantidadAprobada { get; set; }
        public Int32 cantidadEntregada { get; set; }
        public Int32 cantidadDevuelta { get; set; }
    }
}
