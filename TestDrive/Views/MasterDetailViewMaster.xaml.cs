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
	public partial class MasterDetailViewMaster : ContentPage
	{
		public SideMenuViewModel SideMenuVM;

		public MasterDetailViewMaster()
		{
			InitializeComponent();
		}

		public MasterDetailViewMaster(Usuario usuario)
		{
			InitializeComponent();
			SideMenuVM = new SideMenuViewModel(usuario);
			BindingContext = SideMenuVM;
		}
	}
}