namespace Api.Infrastructure.Data.Repositories
{
    /// <summary>
    /// MongoDB Setting
    /// </summary>
    public class MongoDBSettings
    {
        /// <summary>
        /// String de Conexao
        /// </summary>
        public string ConnectionString { get; set; }
        /// <summary>
        /// Nome do Banco de Dados
        /// </summary>
        public string DatabaseName { get; set; }
    }
}
