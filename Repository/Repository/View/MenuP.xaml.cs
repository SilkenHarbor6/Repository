using Repository.Model;
using Repository.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Repository.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MenuP 
	{
		public MenuP (Persona item)
		{
			InitializeComponent ();
            BindingContext = new MenuPViewModel(item);
		}
	}
}