using System.Collections.Generic;
using TestDrive.Models;

namespace TestDrive.Data
{
	public class ListagemVeiculos
	{
		public static readonly List<Veiculo> Veiculos = new List<Veiculo>
			{
				new Veiculo{Nome = "Azera V6", Preco=60000},
				new Veiculo{Nome = "Fiesta 2.0", Preco=35000},
				new Veiculo { Nome = "Bmw Monstra", Preco = 150000 },
				new Veiculo { Nome = "Uno Mille 2000", Preco = 200000 }
			};
	}
}
