namespace Repository.View
{
    using Repository.ViewModel;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class mp2 : ContentPage
	{
		public mp2 ()
		{
			InitializeComponent ();
            BindingContext = new MainPageViewModel();
		}
	}
}