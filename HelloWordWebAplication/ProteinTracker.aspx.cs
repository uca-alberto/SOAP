using HelloWordWebAplication.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HelloWordWebAplication
{
	public partial class ProteinTracker : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

		[WebMethod]
		public static int AddProtein(int amount,int userID)
		{
			UserRepository userRepository = new UserRepository();
			var user = userRepository.GetById(userID);
			if (user==null)
				return -1;
			user.Total += amount;
			userRepository.Save(user);
			return user.Total;
		}

		[WebMethod]
		public static int AddUser(string name, int goal)
		{
			UserRepository userRepository = new UserRepository();
			var user = new User { Goal=goal,Name=name,Total=0 };
			userRepository.ADD(user);
			return user.UserId;
		}
		[WebMethod]
		public static List<User> ListUsers()
		{
			UserRepository userRepository = new UserRepository();
			return new List<User>(userRepository.GetAll());
		}
	}
}