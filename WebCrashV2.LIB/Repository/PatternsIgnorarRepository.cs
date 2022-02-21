using Dapper;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using WebCrashV2.LIB.Infraestrutura.Modelos;

namespace WebCrashV2.LIB.Repository.DB
{
    public class PatternsIgnorarRepository
    {
        private DBSession session;

        public PatternsIgnorarRepository(DBSession session)
        {
            this.session = session;
        }

        public int? Salvar(PatternsIgnorar entity)
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

        public IEnumerable<PatternsIgnorar> SelecionarTodos()
        {
            return session.Connection.GetList<PatternsIgnorar>();
        }

        public int? Apagar(PatternsIgnorar entity)
        {
            try
            {
                return session.Connection.Delete(entity);
            }
            catch (Exception ex)
            {
                Log.Warning($"Erro ao salvar: {entity} \n{ex.Message})");
            }
            return 0;
        }
    }
}
