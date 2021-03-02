using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PocketAssistant.Helper.Alert
{
    public class AlertHelper
    {
        public async static Task ShowAlert(string title, string msg, string OK = "OK")
        {
            await Application.Current.MainPage.DisplayAlert(title, msg, OK);
        }
    }
}
