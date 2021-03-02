using System;
using System.Collections.Generic;
using PocketAssistant.ViewModels.Base;
using Xamarin.Forms;

namespace PocketAssistant.Views.Base
{
    public partial class BaseView : ContentPage
    {
        public BaseView()
        {
            InitializeComponent();
        }


        protected override void OnAppearing()
        {
            base.OnAppearing();
            var viewModel = this.BindingContext as BaseViewModel;

            if (viewModel != null)
            {
                Device.InvokeOnMainThreadAsync(async () =>
                {
                    await viewModel.OnAppearing();
                });
            }
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            var viewModel = this.BindingContext as BaseViewModel;

            if (viewModel != null)
            {
                Device.InvokeOnMainThreadAsync(async () =>
                {
                    await viewModel.OnDisappearing();
                });
            }
        }
    }
}
