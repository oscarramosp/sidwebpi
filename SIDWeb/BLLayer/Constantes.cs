﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLLayer
{
    public class Constantes
    {
        public enum CodigoGrabarFormula
        {
            Ok = 0,
            ErrorSintaxis = 2,
            Error = -2,
            ErrorReferenciaCircular = 1,
            ErrorDivisionporCero = 3

        }
    }
}
