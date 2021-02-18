using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Windows.Input;
using TestDrive.Models;
using TestDrive.Services;
using Xamarin.Forms;

namespace TestDrive.ViewModels
{
	public class LoginViewModel :  BaseViewModel
	{
		private string _usuario;

		public string Usuario
		{
			get { return _usuario; }
			set { _usuario = value; ((Command)EntrarCommand).ChangeCanExecute(); }
		}

		private string _senha;

		public string Senha
		{
			get { return _senha; }
			set { _senha = value; ((Command)EntrarCommand).ChangeCanExecute(); }
		}

		public ICommand EntrarCommand { get; private set; }

		private bool _fazendoLogin;

		public bool FazendoLogin
		{
			get { return _fazendoLogin; }
			set { _fazendoLogin = value; OnPropertyChanged(); }
		}


		public LoginViewModel()
		{
			EntrarCommand = new Command(
				execute: async() =>
				{
					FazendoLogin = true;
					var loginServices = new LoginServices();
					await loginServices.FazerLogin(new Login(_usuario, _senha));
					FazendoLogin = false;
				},
				canExecute: () => 
				{
					return !string.IsNullOrEmpty(_senha) && !string.IsNullOrEmpty(_usuario);
				});
		}
	}
}
