using System;
using System.Threading.Tasks;
using Prism.Mvvm;
using Prism.Navigation;

namespace PocketAssistant.ViewModels.Base
{
    public class BaseViewModel : BindableBase
    {
        protected INavigationService _navigationService { get; }

        public BaseViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }


        public virtual Task OnAppearing()
        {
            return Task.FromResult(false);
        }

        public virtual Task OnDisappearing()
        {
            return Task.FromResult(false);
        }



    }
}
