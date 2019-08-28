namespace Repository.Services
{
    using System;
    using System.Threading.Tasks;
    public class DialogService
    {
        #region Metodos
        public async Task Message(String titulo, String msg)
        {
            await App.Current.MainPage.DisplayAlert(titulo, msg, "Aceptar");
        }
        public async Task<bool> Message(String titulo, String msg,String ok,String no)
        {
            var rs = await App.Current.MainPage.DisplayAlert(titulo, msg, ok,no);
            if (!rs)
            {
                return false;
            }
            return true;
        }
        #endregion

    }
}
