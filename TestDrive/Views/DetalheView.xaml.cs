using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestDrive.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DetalheView : ContentPage
	{
		public Veiculo Veiculo { get; set; }
		public DetalheView(Veiculo veiculo)
		{
			InitializeComponent();
			this.Title = $"Detalhe {veiculo.Nome}";
			this.Veiculo = veiculo;
		}

		private void Next_Page(object sender, EventArgs e)
		{
			Navigation.PushAsync(new AgendamentoView(this.Veiculo));
		}
	}
}