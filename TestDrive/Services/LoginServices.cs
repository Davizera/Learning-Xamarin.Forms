using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TestDrive.Models;
using Xamarin.Forms;

namespace TestDrive.Services
{
	public class LoginServices
	{
		public async Task FazerLogin(Login login)
		{
			using (var cliente = new HttpClient())
			{
				var form = new FormUrlEncodedContent(new[]
				{
					new KeyValuePair<string, string>("email", login.email),
					new KeyValuePair<string, string>("senha", login.senha)
				});

				cliente.BaseAddress = new Uri("https://aluracar.herokuapp.com");
				var response = await cliente.PostAsync("/login", form);
				if (response.IsSuccessStatusCode)
					MessagingCenter.Send<Usuario>(new Usuario(), "SucessoLogin");
				else
					MessagingCenter.Send<LoginException>(new LoginException("Falha ao tentar efetuar login"), "FalhaLogin");
			}
		}
	}
}
