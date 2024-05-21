using DemoLibrary;
using Mopups.Interfaces;
using Mopups.Services;

namespace MauiApp1
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }


        private async void Button_Clicked(object sender, EventArgs e)
        {
            var popup = new DemoPopup();

            await DisplayPopup(popup);
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            var popup = new LibDemoPopup();

            await DisplayPopup(popup);

        }

        public async Task<PopupBase.PopupResult> DisplayPopup(PopupBase popup)
        {
            await MopupService.Instance.PushAsync(popup);
            var result = await popup.PopupDismissedTask;
            return result;
        }
    }

}
