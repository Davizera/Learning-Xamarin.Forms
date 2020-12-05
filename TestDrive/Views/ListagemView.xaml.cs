using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TestDrive.Views
{
	public class Veiculo
	{
		public string Nome { get; set; }
		public decimal Preco { get; set; }
		public string PrecoFormatado { get { return string.Format("R$ {0}", Preco); }}
	}
	public partial class ListagemView : ContentPage
	{
		public List<Veiculo> Veiculos { get; set; }
		public ListagemView()
		{
			InitializeComponent();
			this.Veiculos = new List<Veiculo>
			{
				new Veiculo{Nome = "Azera V6", Preco=60000},
				new Veiculo{Nome = "Fiesta 2.0", Preco=35000},
				new Veiculo{Nome = "Bmw Monstra", Preco=150000},
				new Veiculo{Nome = "Uno Mille 2000", Preco=200000}
			};
			//ListViewVeiculos.ItemsSource = this.Veiculos;
			this.BindingContext = this;
		}

		private void ListViewVeiculos_ItemTapped(object sender, ItemTappedEventArgs e)
		{
			var veiculo = (Veiculo)e.Item;
			Navigation.PushAsync(new DetalheView(veiculo));
		}
	}
}
