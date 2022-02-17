using Dapper;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using WebCrashV2.LIB.Infraestrutura.Modelos;

namespace WebCrashV2.LIB.Repository.DB
{
    public class PatternsJogarRepository
    {
        private DBSession session;

        public PatternsJogarRepository(DBSession session)
        {
            this.session = session;
        }

        public int? Salvar(PatternsJogar entity)
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

        public IEnumerable<PatternsJogar> SelecionarTodos()
        {
            return session.Connection.GetList<PatternsJogar>().Where(e => e.Ativo = true).OrderBy(e => e.Id);
        }

        public int? Apagar(PatternsJogar entity)
        {
            try
            {
                var patternsIgnorar = new PatternsIgnorarRepository(session).Apagar(entity);
                var totalExcluido = session.Connection.Delete(entity);
            }
            catch (Exception ex)
            {
                Log.Warning($"Erro ao salvar: {entity} \n{ex.Message})");
            }
            return 0;
        }
    }
}
