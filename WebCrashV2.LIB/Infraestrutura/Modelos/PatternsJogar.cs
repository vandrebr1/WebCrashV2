using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCrashV2.LIB.Infraestrutura.Modelos
{
    [Table("PatternsJogar")]


    public class PatternsJogar
    {
        public PatternsJogar(int id, string pattern, bool ativo, DateTime dtCadastro, bool geradoPeloComputador)
        {
            Id = id;
            Pattern = pattern;
            Ativo = ativo;
            DtCadastro = dtCadastro;
            GeradoPeloComputador = geradoPeloComputador;
        }

        public PatternsJogar()
        {
        }

        public int Id { get; set; }
        public string Pattern { get; set; }
        public bool Ativo { get; set; }
        public DateTime DtCadastro { get; set; }
        public bool GeradoPeloComputador { get; set; }
    }
}
