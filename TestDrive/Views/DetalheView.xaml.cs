using System;
using System.Collections.Generic;
using System.Globalization;
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
		private const int FREIO_ABS = 800;
		private const int AR_CONDICIONADO = 1000;
		private const int MP3_PLAYER = 500;
		public string TextoFreioABS
		{
			get
			{
				return string.Format("Freio ABS - {0}", FREIO_ABS.ToString("C", CultureInfo.GetCultureInfo("pt-BR")));
			}
		}

		public string TextoArCondicionado
		{
			get
			{
				return string.Format("Ar Condicionado - {0}", AR_CONDICIONADO.ToString("C", CultureInfo.GetCultureInfo("pt-BR")));
			}
		}

		public string TextoMP3Player
		{
			get
			{
				return string.Format("MP3 Player - {0}", MP3_PLAYER.ToString("C", CultureInfo.GetCultureInfo("pt-BR")));
			}
		}

		private bool _temFreioABS;
		public bool TemFreioABS
		{
			get { return _temFreioABS; }
			set
			{
				_temFreioABS = value;
				if (_temFreioABS)
					DisplayAlert("Freio ABS", "Incluído", "Fechar");
				else
					DisplayAlert("Freio ABS", "Removido", "Fechar");

				OnPropertyChanged();
				OnPropertyChanged(nameof(ValorTotal));
			}
		}

		private bool _temArCondicionado;
		public bool TemArCondicionado
		{
			get { return _temArCondicionado; }
			set
			{
				_temArCondicionado = value;
				if (_temArCondicionado)
					DisplayAlert("Ar Condicionado", "Incluído", "Fechar");
				else
					DisplayAlert("Ar Condicionado", "Removido", "Fechar");

				OnPropertyChanged();
				OnPropertyChanged(nameof(ValorTotal));
			}
		}

		private bool _temMP3Player;
		public bool TemMP3Player
		{
			get { return _temMP3Player; }
			set
			{
				_temMP3Player = value;
				if (_temMP3Player)
					DisplayAlert("MP3 Player", "Incluído", "Fechar");
				else
					DisplayAlert("MP3 Player", "Removido", "Fechar");

				OnPropertyChanged();
				OnPropertyChanged(nameof(ValorTotal));
			}
		}

		public string ValorTotal
		{
			get
			{
				return string.Format("Valor total: {0}",
					(Veiculo.Preco
						+ (_temFreioABS ? FREIO_ABS : 0)
						+ (_temArCondicionado ? AR_CONDICIONADO : 0)
						+ (_temMP3Player ? MP3_PLAYER : 0)
						).ToString("C", CultureInfo.GetCultureInfo("pt-BR")));
			}
		}
		public DetalheView(Veiculo veiculo)
		{
			InitializeComponent();
			this.Veiculo = veiculo;
			this.BindingContext = this;
		}

		private void Next_Page(object sender, EventArgs e)
		{
			Navigation.PushAsync(new AgendamentoView(this.Veiculo));
		}
	}
}