using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TestDrive.Models;
using TestDrive.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestDrive.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SideMenuView : TabbedPage
	{

		public SideMenuView()
		{
			InitializeComponent();
		}

		public SideMenuView(Usuario usuario)
		{
			InitializeComponent();
			BindingContext = new SideMenuViewModel(usuario);
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			MessagingCenter.Subscribe<Usuario>(this, "EditarPerfil", 
				(usuario)=> 
				{
					this.CurrentPage = this.Children[1];
				});
			MessagingCenter.Subscribe<Usuario>(this, "SalvarPerfil",
				(usuario) => 
				{
					this.CurrentPage = this.Children[0];
				});
		}

		protected override void OnDisappearing()
		{
			base.OnDisappearing();
			MessagingCenter.Unsubscribe<Usuario>(this, "EditarPerfil");
			MessagingCenter.Unsubscribe<Usuario>(this, "SalvarPerfil");
		}
	}
}