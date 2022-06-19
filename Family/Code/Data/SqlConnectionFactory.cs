namespace Family.Data;
using Basketcase;
using System.Data;

public class SqlConnectionFactory : IConnectionFactory {
   public IDbConnection Create() =>
      new System.Data.SqlClient.SqlConnection(
         "server=(LocalDb)\\MSSQLLocalDB; database=Family; trusted_connection=true;");
}