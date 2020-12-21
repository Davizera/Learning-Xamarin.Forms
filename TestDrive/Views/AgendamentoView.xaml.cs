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

		private DateTime _dataAgendamento = DateTime.Today;
		private TimeSpan _horaAgedamento = DateTime.Now.TimeOfDay;
		public string Nome { get; set; }
		public string Telefone { get; set; }
		public string Email { get; set; }
		public DateTime DataAgendamento
		{
			get { return _dataAgendamento; }
			set { _dataAgendamento = value; }
		}
		public TimeSpan HoraAgendamento
		{
			get { return _horaAgedamento; }
			set { _horaAgedamento = value; }
		}
		public AgendamentoView(Veiculo veiculo)
		{
			InitializeComponent();
			this.Carro = veiculo;
			this.BindingContext = this;
		}

		private void Agendar(object sender, EventArgs e)
		{
			DisplayAlert("Agendamento",
				string.Format(
					@"Você, {0}, está agendando o carro, {1}.
	Seguem seus dados:
		Nome: {2},
		Telefone: {3},
		Email: {4},
		Dia Agendamento: {5}
		Hora Agendamento: {6}", Nome, Carro.Nome, Nome, Telefone, Email, DataAgendamento.ToString("dd/MM/yyyy"), HoraAgendamento.ToString(@"hh\:mm")), "Finalizar");
		}
	}
}