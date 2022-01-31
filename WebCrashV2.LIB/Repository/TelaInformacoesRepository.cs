using Dapper;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using WebCrashV2.LIB.Infraestrutura.Modelos;

namespace WebCrashV2.LIB.Repository.DB
{
    public class TelaInformacoesRepository
    {
        private DBSession session;

        public TelaInformacoesRepository(DBSession session)
        {
            this.session = session;
        }

        public int? Salvar(TelaInformacoes entity)
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

        public IEnumerable<TelaInformacoes> SelecionarTodos()
        {
            return session.Connection.GetList<TelaInformacoes>();
        }

        public IEnumerable<TelaInformacoes> SelecionarRegistrosMontarPrevisao()
        {
            var telaInformacoes = session.Connection.GetListPaged<TelaInformacoes>(1, 3, "", "Id desc");
            telaInformacoes = telaInformacoes.OrderBy(t => t.Id);
            return telaInformacoes;
        }

        public TelaInformacoes SelectById(int Id)
        {
            return session.Connection.Get<TelaInformacoes>(Id);
        }
    }
}
