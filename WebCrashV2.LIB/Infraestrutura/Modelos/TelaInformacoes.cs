using Dapper;
using Newtonsoft.Json;
using System;

namespace WebCrashV2.LIB.Infraestrutura.Modelos
{
    [Table("TelaInformacoes")]
    public class TelaInformacoes
    {
        public TelaInformacoes()
        {
        }

        public TelaInformacoes(string multiplicador, DateTime HorarioCaptura, bool houveErroLeitura)
        {

            Multiplicador = ConvertDouble(multiplicador);
            this.HorarioCaptura = HorarioCaptura;

            HouveErroLeitura = houveErroLeitura;
        }

        internal static TelaInformacoes MontarRegistroErroLeitura()
        {
            return new TelaInformacoes("-1", DateTime.Now, true);
        }

        public int Id { get; }

        public double Multiplicador { get; }


        public DateTime HorarioCaptura { get; }

        public bool HouveErroLeitura { get; set; }

        private static DateTime ConvertHorarioServidor(string horarioServidor)
        {
            return DateTime.Parse(horarioServidor);
        }

        private double ConvertDouble(string valor)
        {
            valor = valor.ToUpper().Replace("X", "").Replace(".", ",").Replace("RUB", "").Replace("BRL", "").Trim();
            return Convert.ToDouble(valor);
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
