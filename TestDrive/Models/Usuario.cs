using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace TestDrive.Models
{
	public class Usuario
	{
		public int Id { get; set; }
		public string Nome { get; set; }
		public string Email { get; set; }
		public string DataNascimento { get; set; }
		public string Telefone { get; set; }
		public ImageSource CaminhoFotoPerfil { get; set; } = "perfil.png";
	}
}
