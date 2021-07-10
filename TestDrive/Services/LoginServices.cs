using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TestDrive.Models;
using Xamarin.Forms;

namespace TestDrive.Services
{
	//emai: joao@alura.com.br
	//senha: alura123

	public class LoginServices
	{
		public async Task<HttpResponseMessage> FazerLogin(Login login)
		{
			using (var cliente = new HttpClient())
			{
				var form = new FormUrlEncodedContent(new[]
				{
					new KeyValuePair<string, string>("email", login.email),
					new KeyValuePair<string, string>("senha", login.senha)
				});

				HttpResponseMessage response;
				cliente.BaseAddress = new Uri("https://aluracar.herokuapp.com");
				response = await cliente.PostAsync("/login", form);
		
				return response;	
			}

		}
	}
}
