using System;
using TestDrive.Models;
using TestDrive.ViewModels;
using Xamarin.Forms;

namespace TestDrive.Views
{
	public partial class AgendamentoView : ContentPage
  {
    public AgendamentoViewModel AgendamentoVM { get; set; }

    public AgendamentoView(Veiculo veiculo)
    {
      InitializeComponent();
      this.AgendamentoVM = new AgendamentoViewModel(veiculo);
      this.BindingContext = this.AgendamentoVM;
    }

    protected override void OnAppearing()
    {
      base.OnAppearing();
      MessagingCenter.Subscribe<Agendamento>(this, "Agendamento",
          async (msg) =>
          {
            var confirma = await DisplayAlert("Salvar Agendamento",
                  "Deseja mesmo enviar o agendamento?",
                  "Sim", "Não");

            if (confirma)
            {
              this.AgendamentoVM.SalvarAgendamento();
            }
          });

      MessagingCenter.Subscribe<Agendamento>(this, "SucessoAgendamento",
          (msg) =>
          {
            DisplayAlert("Agendamento", "Agendamento salvo com sucesso!", "Ok");
          });

      MessagingCenter.Subscribe<Exception>(this, "FalhaAgendamento",
          (msg) =>
          {
            DisplayAlert("Agendamento", "Falha ao agendar o test drive! Verifique os dados e tente novamente mais tarde!", "Ok");
          });
    }

    protected override void OnDisappearing()
    {
      base.OnDisappearing();
      MessagingCenter.Unsubscribe<Agendamento>(this, "Agendamento");
      MessagingCenter.Unsubscribe<Agendamento>(this, "SucessoAgendamento");
      MessagingCenter.Unsubscribe<Exception>(this, "FalhaAgendamento");
    }
  }
}
