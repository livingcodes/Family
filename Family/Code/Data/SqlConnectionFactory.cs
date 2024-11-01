namespace Family.Data;
using Basketcase;
using System.Data;

public class SqlConnectionFactory : IConFct {
   public IDbConnection Crt() =>
      new Microsoft.Data.SqlClient.SqlConnection(
         "server=(LocalDb)\\MSSQLLocalDB; database=Family; trusted_connection=true;");
}