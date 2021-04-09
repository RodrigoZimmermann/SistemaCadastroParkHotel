using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    internal static class Parametros
    {
        //{nomeClasse}.{nomeMétodo}
        public static string GetConnectionString()
        {
            return @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\54003\Documents\ParkHotelSystem.mdf;Integrated Security=True;Connect Timeout=30";
        }
    }
}
