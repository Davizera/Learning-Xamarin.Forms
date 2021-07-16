using System;

namespace TestDrive.Models
{
	public class Login
	{
		public string email { get; private set; }
		public string senha { get; private set; }

		public Login(string email, string senha)
		{
			this.email = "joao@alura.com.br";
			this.senha = "alura123";
		}
	}

	public class LoginException : Exception
	{
		public LoginException(string message) :  base(message){}
	}
}
