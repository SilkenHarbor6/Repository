namespace Repository.ViewModel
{
    using GalaSoft.MvvmLight.Command;
    using Repository.Model;
    using Repository.Patterns;
    using Repository.Services;
    using Repository.View;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class NewPageViewModel : BaseViewModel
    {
        #region Atributos
        private DialogService _dialogService;
        private string _nombre;
        private string _apellido;
        private string _direccion;
        private int _edad;
        #endregion
        #region Propiedades
        public string Nombre
        {
            get { return this._nombre; }
            set { _nombre = value;OnPropertyChanged(); }
        }
        public string Apellido
        {
            get { return this._apellido; }
            set { _apellido = value; OnPropertyChanged(); }
        }
        public string Direccion
        {
            get { return this._direccion; }
            set { _direccion = value; OnPropertyChanged(); }
        }
        public int Edad
        {
            get { return this._edad; }
            set { _edad = value; OnPropertyChanged(); }
        }
        public ICommand Add
        {
            get
            {
                return new RelayCommand(AddNewPerson);
            }
        }

        #endregion
        #region Constructor
        public NewPageViewModel()
        {
            _dialogService = new DialogService();
        }
        #endregion
        #region Metodos
        private async void AddNewPerson()
        {
            if (string.IsNullOrEmpty(Nombre))
            {
                await _dialogService.Message("Error", "El nombre es requerido");
                return;
            }
            if (string.IsNullOrEmpty(Apellido))
            {
                await _dialogService.Message("Error", "El apellido es requerido");
                return;
            }
            if (string.IsNullOrEmpty(Direccion))
            {
                await _dialogService.Message("Error", "La direccion es requerida");
                return;
            }
            if (Edad<=0)
            {
                await _dialogService.Message("Error", "La edad debe ser mayor que 0");
                return;
            }
            if (Edad>=110)
            {
                await _dialogService.Message("Error", "La edad debe ser menor a 110");
                return;
            }

            Persona persona = new Persona
            {
                nombre = this.Nombre,
                apellido = this.Apellido,
                direccion = this.Direccion,
                edad = this.Edad
            };
            var ob = SingletonRepository.Instancia.Repository.Save(persona);
            if (ob==false)
            {
                await _dialogService.Message("Error al guardar", "No ha sido poible guardar el registro");
                return;
            }
            await _dialogService.Message("Ud es exitoso", "El registro ha sido guardado");
            Application.Current.MainPage = new NavigationPage(new mp2());
            //await _dialogService.Message("Test","Esta es una prueba");
            //return;
        }
        #endregion
    }
}
