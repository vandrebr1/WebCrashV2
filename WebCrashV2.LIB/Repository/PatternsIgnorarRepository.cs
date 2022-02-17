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

        public IEnumerable<PatternsIgnorar> SelecionarByPatternJogarKey(PatternsJogar partternJogar)
        {
            return session.Connection.GetList<PatternsIgnorar>().Where(e => e.PatternJogarKey == partternJogar.Pattern);
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

        public int? Apagar(PatternsJogar partternJogar)
        {
            var patternsIgnorarApagar = SelecionarByPatternJogarKey(partternJogar);

            try
            {
                int itensExcluidos = 0;

                foreach (var patterIgnApagar in patternsIgnorarApagar)
                {
                    itensExcluidos += session.Connection.Delete(patterIgnApagar);
                }

                return itensExcluidos;
            }
            catch (Exception ex)
            {
                Log.Warning($"Erro ao apagar:{partternJogar} \n{ex.Message})");
            }
            return 0;
        }
    }
}
