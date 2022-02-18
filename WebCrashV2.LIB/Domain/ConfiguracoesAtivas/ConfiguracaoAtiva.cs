using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCrashV2.LIB.Infraestrutura.Modelos;
using WebCrashV2.LIB.Repository.DB;

namespace WebCrashV2.LIB.Domain.ConfiguracoesAtivas
{
    public sealed class ConfiguracaoAtiva
    {
        private ConfiguracaoAtiva() { }

        private static Configuracoes Configuracao;

        public static Configuracoes GetInstance()
        {
            if (Configuracao == null)
            {
                var repoConfig = new ConfiguracoesRepository(new DBSession());
                Configuracao = repoConfig.GetUltimaConfiguracao();
            }
            return Configuracao;
        }

        public static Configuracoes SetInstance(Configuracoes configuracoes)
        {
            Configuracao = configuracoes;
            return Configuracao;
        }
    }
}
