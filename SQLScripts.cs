using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Google.Protobuf.WellKnownTypes.Field.Types;

namespace tempo
{
    internal class SQLScripts
    {
        public static readonly string leerlingen = "SELECT kindnaam,kindvoornaam, kindid FROM tblleerlingen";
        public static readonly string ouder = "SELECT ouderid,kindid FROM tblouders WHERE kindid=@kindid";
    }
}
