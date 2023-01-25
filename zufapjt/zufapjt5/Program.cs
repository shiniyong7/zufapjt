using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zufapjt5
{
    class Program
    {
        static void Main(string[] args)
        {
            DBMaster dB = new DBMaster();

            dB.DB_Inser("10900004", "harry", "11111111");
            dB.DB_Delete("10900004");
        }
    }
}
