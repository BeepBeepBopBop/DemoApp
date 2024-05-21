using Mopups.Pages;
using Mopups.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLibrary
{
    public abstract class PopupBase : PopupPage
    {
        protected TaskCompletionSource<PopupResult>? _taskCompletionSource;

        protected PopupResult ReturnValue { get; set; } = new PopupResult();

        public Task<PopupResult> PopupDismissedTask => _taskCompletionSource != null ? _taskCompletionSource!.Task : new TaskCompletionSource<PopupResult>().Task;

        public PopupBase()
        {
            CloseWhenBackgroundIsClicked = false;
            BackgroundClicked += PopupBase_BackgroundClicked;
        }

        protected virtual async Task Dismiss(bool cancelled = false)
        {
            ReturnValue.Cancelled = cancelled;

            await MopupService.Instance.PopAsync();
        }

        private async void PopupBase_BackgroundClicked(object? sender, EventArgs e)
        {
            await Dismiss(true);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            _taskCompletionSource = new TaskCompletionSource<PopupResult>();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            if (_taskCompletionSource != null)
            {
                _taskCompletionSource!.SetResult(ReturnValue);
            }
        }

        public sealed class PopupResult
        {
            public object? ReturnValue { get; set; }

            public bool Cancelled { get; set; }
        }
    }

}
