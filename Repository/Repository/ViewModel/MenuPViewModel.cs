using Android.Widget;
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
    public class MenuPViewModel
    {
        #region Propiedades
        private Persona _persona;
        DialogService _dialogService;
        public ICommand Delete
        {
            get
            {
                return new RelayCommand(Eliminar);
            }
        }
        public ICommand Update
        {
            get
            {
                return new RelayCommand(Actualizar);
            }
        }
        #endregion
        #region Constructor
        public MenuPViewModel(Persona item)
        {
            _persona = item;
            _dialogService = new DialogService();
        }
        #endregion
        #region Metodos
        public async void Eliminar()
        {
            if (await _dialogService.Message("Confirmacion", "¿Desea eliminar este registro?", "Aceptar", "Cancelar"))
            {
                if (SingletonRepository.Instancia.Repository.Delete(_persona))
                {
                    await PopupNavigation.PopAllAsync();
                    App.Current.MainPage = new NavigationPage(new mp2());
                }
            }
            else
            {
                Toast.MakeText(Android.App.Application.Context,"Operacion Cancelada",ToastLength.Long).Show();
            }
        }
        public async void Actualizar()
        {
            await PopupNavigation.PopAsync();
            await PopupNavigation.PushAsync(new EditPage(_persona));
        }
        #endregion
    }
}
