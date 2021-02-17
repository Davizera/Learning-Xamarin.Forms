using System;
using TestDrive.Models;
using TestDrive.ViewModels;
using Xamarin.Forms;

namespace TestDrive.Views
{
	public partial class ListagemView : ContentPage
  {
    public ListagemViewModel ListagemVM { get; set; }

    public ListagemView()
    {
      InitializeComponent();
      this.ListagemVM = new ListagemViewModel();
      this.BindingContext = this.ListagemVM;
    }

    protected async override void OnAppearing()
    {
      base.OnAppearing();
      
      MessagingCenter.Subscribe<Veiculo>(this, "VeiculoSelecionado",
          (msg) =>
          {
            Navigation.PushAsync(new DetalheView(msg));
          });

      MessagingCenter.Subscribe<Exception>(this, "FalhaListagem",
          (msg) =>
          {
            DisplayAlert("Erro", "Ocorreu um erro ao obter a listagem de veículos. Por favor tente novamente mais tarde.", "Ok");
          });

      await this.ListagemVM.GetVeiculos();
    }

    protected override void OnDisappearing()
    {
      base.OnDisappearing();

      MessagingCenter.Unsubscribe<Veiculo>(this, "VeiculoSelecionado");
      MessagingCenter.Unsubscribe<Exception>(this, "FalhaListagem");
    }
  }
}
