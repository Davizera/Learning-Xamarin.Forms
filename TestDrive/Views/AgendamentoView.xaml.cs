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
	public partial class AgendamentoView : ContentPage
	{
		public Veiculo Carro { get; set; }
		public AgendamentoView(Veiculo veiculo)
		{
			InitializeComponent();
			this.Carro = veiculo;
			this.BindingContext = this;
		}

		private void Previous_Page(object sender, EventArgs e)
		{
			Navigation.PopAsync();
		}
	}
}