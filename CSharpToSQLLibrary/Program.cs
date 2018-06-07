using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLLibrary;

namespace CSharpToSQLLibrary {
	class Program {
		static void Main(string[] args) {

			UsersController userCtrl = new UsersController(@"localhost\SQLEXPRESS", "prssql");

			IEnumerable<User> users = userCtrl.List();
			foreach(User user in users) {
				Console.WriteLine($"{user.Firstname} {user.Lastname}");
			}

			userCtrl.CloseConnection();

		}
	}
}
