using System;
using System.Collections.Generic;

namespace VetPrescriptionKiosk.Helpers
{
    public static class EnumHelper
    {
        public static IEnumerable<T> GetValues<T>() where T : Enum
        {
            return (T[])Enum.GetValues(typeof(T));
        }
    }
}