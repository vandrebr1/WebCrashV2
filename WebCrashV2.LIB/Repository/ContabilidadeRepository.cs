using Dapper;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using WebCrashV2.LIB.Infraestrutura.Modelos;

namespace WebCrashV2.LIB.Repository.DB
{
    public class ContabilidadeRepository
    {
        private readonly DBSession session;

        public ContabilidadeRepository(DBSession session)
        {
            this.session = session;
        }

        public int? Salvar(Contabilidade entity)
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

        public IEnumerable<Contabilidade> SelecionarTodos()
        {
            return session.Connection.GetList<Contabilidade>();
        }

        public Contabilidade SelectById(int Id)
        {
            return session.Connection.Get<Contabilidade>(Id);
        }
    }
}
