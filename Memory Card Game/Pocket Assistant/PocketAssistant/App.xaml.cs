using PocketAssistant.ViewModels.Base;
using PocketAssistant.ViewModels.Card;
using PocketAssistant.Views.Base;
using PocketAssistant.Views.Cards;
using Prism.Ioc;
using Xamarin.Forms;

[assembly: ExportFont("Ubuntu-Light.ttf", Alias = "UbuntuLight")]
[assembly: ExportFont("Ubuntu-Regular.ttf", Alias = "UbuntuRegular")]
[assembly: ExportFont("Ubuntu-Bold.ttf", Alias = "UbuntuBold")]

namespace PocketAssistant
{
    public partial class App
    {


        public App()
        {

        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            //Here we have to register all the pages/View with ViewName and ViewModel as parameter.
            containerRegistry.RegisterForNavigation<NavigationPage>(); //This line should remain same in all the projects.

            //Now Register the Views with their ViewModels.
            containerRegistry.RegisterForNavigation<BaseView, BaseViewModel>();
            containerRegistry.RegisterForNavigation<CardsView, CardViewModel>();

        }

        protected override async void OnInitialized()
        {
            InitializeComponent();
            var result = await NavigationService.NavigateAsync("NavigationPage/CardsView"); //Set the default page
            if (!result.Success)
            {
                System.Diagnostics.Debugger.Break();
            }


        }
    }
}
