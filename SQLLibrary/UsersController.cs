using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace SQLLibrary {

	public class UsersController {

		SqlConnection conn = null;
		SqlCommand cmd = new SqlCommand();

		public IEnumerable<User> List() {
			string sql = "select * from [user]";
			cmd.Connection = conn;
			cmd.CommandText = sql;
			SqlDataReader reader = cmd.ExecuteReader();
			List<User> users = new List<User>();
			while (reader.Read()) {
				users.Add(new User(reader));
			}
			return users;
		}

		public User Get(int id) {
			return null;
		}

		public bool Create(User user) {
			return false;
		}

		public bool Change(User user) {
			return false;
		}

		public bool Remove(User user) {
			return false;
		}

		private SqlConnection CreateAndOpenConnection(string server, string database) {
			string connStr = $"server={server};database={database};Trusted_connection=true;";
			SqlConnection conn = new SqlConnection(connStr);
			conn.Open();
			if (conn.State != ConnectionState.Open) {
				throw new ApplicationException("Connection did not open");
			}
			return conn;
		}

		public void CloseConnection() {
			if (conn != null && conn.State == ConnectionState.Closed) {
				conn.Close();
			}
		}

		public UsersController(string server, string database) {
			conn = CreateAndOpenConnection(server, database);
		}

		public UsersController() {

		}
	}
}
