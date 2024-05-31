using CommunityToolkit.Maui.Alerts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaBlazor
{
    public class MauiInterop
    {
        private readonly AppViewModel _appViewModel;

        public MauiInterop(AppViewModel appViewModel)
        {
            _appViewModel = appViewModel;
        }

        public void ShowLoader() => _appViewModel.ToggleIsBusy(true);
        public void HideLoader() => _appViewModel.ToggleIsBusy(false);

        public async Task ShowErrorAlertAsync(string message, string? title = "Ошибка") =>
            await App.Current.MainPage.DisplayAlert(title, message, "Ok");

        public async Task ShowSuccessAlertAsync(string message, string? title = "Успех") =>
            await App.Current.MainPage.DisplayAlert(title, message, "Ok");
        public bool IsAndroid => DeviceInfo.Current.Platform == DevicePlatform.Android;
        public bool IsIOS => DeviceInfo.Current.Platform == DevicePlatform.iOS;

        public async Task ShowToastAsync(string message) =>
            await Toast.Make(message, CommunityToolkit.Maui.Core.ToastDuration.Short).Show();
    }
}
