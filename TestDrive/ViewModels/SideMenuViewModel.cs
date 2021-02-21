using System;
using System.Collections.Generic;
using System.Text;
using TestDrive.Models;

namespace TestDrive.ViewModels
{
	public class SideMenuViewModel
	{
		private readonly Usuario _usuario;
		public string Nome 
		{
			get
			{
				return _usuario.Nome;
			}
			
			set
			{
				_usuario.Nome = value;
			}
		}
		public string Email 
		{
			get
			{
				return _usuario.Email;
			}
			
			set
			{
				_usuario.Email = value;
			}
		}

		public SideMenuViewModel(Usuario usuario)
		{
			_usuario = usuario;
		}
	}
}
