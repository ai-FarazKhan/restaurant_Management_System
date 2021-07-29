using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Final_OOP_Project
{
    class TokenNumber
    {
        private static int seed; private static int Cvalue = -1;
        private static int increament = 1;

        public static int getnextvalue()
        {
            if (Cvalue == -1)
            {
                Cvalue = seed;
            }
            return Cvalue += increament;
        }

    }
}
