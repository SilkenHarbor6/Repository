namespace Repository.ViewModel
{
    using GalaSoft.MvvmLight.Command;
    using Repository.Model;
    using Repository.Patterns;
    using Repository.Services;
    using Repository.View;
    using Rg.Plugins.Popup.Services;
    using System.Collections.ObjectModel;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class MainPageViewModel:BaseViewModel
    {
        #region Propiedades
        public DialogService _dialogService;
        private Persona _persona;
        public Persona Persona
        {
            get
            {
                return this._persona;
            }
            set
            {
                _persona = value as Persona;OnPropertyChanged("Persona"); Prueba();
            }
        }
        public ObservableCollection<Persona> Personas { get; set; }
        public ListView lista
        {
            set
            {
            }
        }
        public ICommand newPerson
        {
            get
            {
                return new RelayCommand(newPage);
            }
        }
        public ICommand Close
        {
            get
            {
                return new RelayCommand(Cerrar);
            }
        }
        
        #endregion

        #region Constructor
        public MainPageViewModel()
        {
            GetPersons();
            _dialogService = new DialogService();
        }
        #endregion

        #region Metodos
        public async void Prueba()
        {
            //await App.Current.MainPage.Navigation.PushAsync(new EditPage(Persona));
            await PopupNavigation.PushAsync(new MenuP(Persona));
        }
        public void GetPersons()
        {
            Personas = new ObservableCollection<Persona>(SingletonRepository.Instancia.Repository.GetAll());
        }
        private void newPage()
        {
            Application.Current.MainPage.Navigation.PushAsync(new NewPage());
        }
        private void Cerrar()
        {
            Android.OS.Process.KillProcess(Android.OS.Process.MyPid());
        }
        
        #endregion
    }
}
