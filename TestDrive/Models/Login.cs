using System;

namespace TestDrive.Models
{
	public class Login
	{
		public string email { get; private set; }
		public string senha { get; private set; }

		public Login(string email, string senha)
		{
			this.email = email;
			this.senha = senha;
		}
	}

	public class LoginException : Exception
	{
		public LoginException(string message) :  base(message){}
	}
}
