using GalaSoft.MvvmLight.Command;
using Repository.Model;
using Repository.Patterns;
using Repository.Services;
using Repository.View;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Repository.ViewModel
{
    public class EditPageViewModel:BaseViewModel
    {
        #region Atributos
        private DialogService _dialogService;
        private string _nombre;
        private string _apellido;
        private string _direccion;
        private int _edad;
        #endregion

        #region Propiedades
        public Persona persona;
        public Persona nueva;
        public string Nombre
        {
            get { return this._nombre; }
            set { _nombre = value; OnPropertyChanged(); }
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
        public ICommand Close
        {
            get
            {
                return new RelayCommand(Cerrar);
            }
        }
        public ICommand Edit
        {
            get
            {
                return new RelayCommand(update);
            }
        }
        #endregion

        #region Constructor
        public EditPageViewModel(Persona item)
        {
            this.persona = item;
            _dialogService = new DialogService();
            Nombre = item.nombre;
            Apellido = item.apellido;
            Direccion = item.direccion;
            Edad = item.edad;
        }
        #endregion

        #region Metodos
        public async void update()
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
            if (Edad <= 0)
            {
                await _dialogService.Message("Error", "La edad debe ser mayor que 0");
                return;
            }
            if (Edad >= 110)
            {
                await _dialogService.Message("Error", "La edad debe ser menor a 110");
                return;
            }
            nueva = new Persona();
            nueva.nombre = Nombre;
            nueva.apellido = Apellido;
            nueva.direccion = Direccion;
            nueva.edad = Edad;
            if (SingletonRepository.Instancia.Repository.Update(persona, nueva))
            {
                await _dialogService.Message("Exito", "el registro ha sido modificado exitosamente");
                await PopupNavigation.PopAllAsync();
                App.Current.MainPage = new NavigationPage(new mp2());
            }
            else
            {
                await _dialogService.Message("Error", "El registro no se ha podido modificar");
            }
        }
        public void Cerrar()
        {
            PopupNavigation.PopAllAsync();
        }
        #endregion
    }
}
