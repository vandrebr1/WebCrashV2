using Dapper;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using WebCrashV2.LIB.Infraestrutura.Modelos;

namespace WebCrashV2.LIB.Repository.DB
{
    public class ConfiguracoesRepository
    {
        private DBSession session;

        public ConfiguracoesRepository(DBSession session)
        {
            this.session = session;
        }

        public int? Salvar(Configuracoes entity)
        {
            try
            {
                return session.Connection.Insert(entity);
            }
            catch (Exception ex)
            {
                Log.Warning($"Erro ao salvar: {entity} \n{ex.Message})");
            }
            return 0;
        }

        public IEnumerable<Configuracoes> SelecionarTodos()
        {
            return session.Connection.GetList<Configuracoes>().OrderBy(e => e.Id);
        }

        public Configuracoes GetUltimaConfiguracao()
        {
            var telaInformacoes = session.Connection.GetListPaged<Configuracoes>(1, 1, "", "Id desc");
            var telaInformacoesOrdenado = telaInformacoes.FirstOrDefault();

            return telaInformacoesOrdenado;
        }

        public Configuracoes SelectById(int Id)
        {
            return session.Connection.Get<Configuracoes>(Id);
        }
    }
}
