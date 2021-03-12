using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using TestDrive.Models;
using Xamarin.Forms;

namespace TestDrive.ViewModels
{
	public class SideMenuViewModel : BaseViewModel
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
		public string DataNascimento 
		{
			get
			{
				return _usuario.DataNascimento;
			}
			set
			{
				_usuario.DataNascimento = value;
			}
		}
		public string Telefone
		{
			get
			{
				return _usuario.Telefone;
			}
			set
			{
				_usuario.Telefone = value;
			}
		}
		private ImageSource foto = "perfil.png";
		public ImageSource CaminhoFotoPerfil
		{
			get { return foto; return _usuario.CaminhoFotoPerfil; }
			private set { foto = value; }
		}

		private bool _editando;
		public bool Editando 
		{
			get
			{
				return _editando;
			}
			private set
			{
				_editando = value;
				OnPropertyChanged(nameof(Editando));
			}
		}

		public ICommand IrParaEditarPerfil { get; private set; }
		public ICommand EditarPerfil { get; private set; }
		public ICommand SalvarPerfil { get; private set; }
		public ICommand TirarFoto { get; private set; }
		public ICommand EscolherFoto { get; private set; }

		public SideMenuViewModel(Usuario usuario)
		{
			_usuario = usuario;
			IrParaEditarPerfil = new Command(execute: () => 
			{
				MessagingCenter.Send<Usuario>(_usuario, "EditarPerfil");
			});
			EditarPerfil = new Command(execute: () =>
			{
				Editando = true;
			});
			SalvarPerfil = new Command(execute: () => 
			{
				Editando = false;
				MessagingCenter.Send<Usuario>(_usuario, "SalvarPerfil");
			});

		}
	}
}
