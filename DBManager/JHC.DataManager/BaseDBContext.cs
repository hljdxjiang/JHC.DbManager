using MySql.Data.MySqlClient;
using System.Data;
namespace DBManager.JHC.DataManager
{
	public class BaseDBContext
	{
		private string connectionString;

		public IDbConnection Connection
		{
			get;
			set;
		}

		protected BaseDBContext(DataBaseConfig settings)
		{
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_0023: Expected O, but got Unknown
			connectionString = settings.ConnectionString;
			Connection = (IDbConnection)new MySqlConnection(connectionString);
		}
	}

}
