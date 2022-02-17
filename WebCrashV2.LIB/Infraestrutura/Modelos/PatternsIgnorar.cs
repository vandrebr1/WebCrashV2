using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCrashV2.LIB.Infraestrutura.Modelos
{
    [Table("PatternsIgnorar")]
    public class PatternsIgnorar
    {
        public PatternsIgnorar()
        {
        }
        public string PatternJogarKey { get; set; }
        public string PatternIgnorar { get; set; }

    }
}
