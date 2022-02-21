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
            return session.Connection.GetList<TelaInformacoes>().OrderBy(e => e.HorarioCaptura);
        }

        public IEnumerable<TelaInformacoes> SelecionarTodosByDtDeDtAte(DateTime dtDe, DateTime dtAte)
        {
            return session.Connection.GetList<TelaInformacoes>()
                .Where(e => e.HorarioCaptura >= dtDe && e.HorarioCaptura <= dtAte)
                .OrderBy(e => e.HorarioCaptura);
        }

        public List<TelaInformacoes> GetUltimosResultadosPattern(int patternLength)
        {
            var telaInformacoes = session.Connection.GetListPaged<TelaInformacoes>(1, patternLength, "", "Id desc");
            var telaInformacoesOrdenado = telaInformacoes.OrderBy(t => t.Id).ToList();

            return telaInformacoesOrdenado;
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
