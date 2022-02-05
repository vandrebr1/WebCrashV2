using Dapper;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using WebCrashV2.LIB.Infraestrutura.Modelos;

namespace WebCrashV2.LIB.Repository.DB
{
    public class AnalisesRepository
    {
        private readonly DBSession session;

        public AnalisesRepository(DBSession session)
        {
            this.session = session;
        }

        public int? Salvar(Analise entity)
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

        public IEnumerable<Analise> SelecionarTodos()
        {
            return session.Connection.GetList<Analise>();
        }

        public Analise SelectById(int Id)
        {
            return session.Connection.Get<Analise>(Id);
        }
    }
}
