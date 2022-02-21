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

        public PatternsIgnorar(int id, string patternIgnorar)
        {
            Id = id;
            PatternIgnorar = patternIgnorar;
        }

        public int Id { get; set; }

        public string PatternIgnorar { get; set; }

    }
}
