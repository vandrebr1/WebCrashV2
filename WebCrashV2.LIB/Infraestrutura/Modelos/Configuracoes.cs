using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCrashV2.LIB.Infraestrutura.Modelos
{
    [Table("Configuracoes")]
    public class Configuracoes
    {
        public Configuracoes()
        {
        }

        public Configuracoes(int id, double multiplicador, double valorAposta, bool apostarPraValer)
        {
            Id = id;
            Multiplicador = multiplicador;
            ValorAposta = valorAposta;
            ApostarPraValer = apostarPraValer;
        }

        public int Id { get; set; }
        public double Multiplicador { get; set; }
        public double ValorAposta { get; set; }
        public bool ApostarPraValer { get; set; }
    }
}
