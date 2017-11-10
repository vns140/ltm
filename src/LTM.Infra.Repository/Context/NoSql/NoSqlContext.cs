using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTM.Infra.Repository
{
    public abstract class NoSqlContext
    {
        #region properties
        public string Configuration { get; private set; }
        public string Database { get; private set; }
        #endregion

        #region constructors
        /// <summary>
        /// Captura as informações da connection string passada no web.config para NoSql.
        /// Está busca é por AppSettings Key.
        /// </summary>
        /// <param name="connectionString">Chave que representa a connectionString</param>
        public NoSqlContext(string connectionString, string database)
        {  
            Configuration = System.Configuration.ConfigurationManager.AppSettings[connectionString];
            Database = System.Configuration.ConfigurationManager.AppSettings[database];
        }
        #endregion

        #region methods
        public abstract void OnModelCreating();
        #endregion
    }
}
