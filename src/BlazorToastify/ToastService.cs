using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlazorToastify
{
    public class ToastService : IToastService
    {
        private List<Toast> _toasts;

        public List<Toast> Toasts
        { 
            get => _toasts;
            set => _toasts = value;
        }

        public event Action ToastsStateChanged;

        public ToastService() => _toasts = new List<Toast>();

        public async Task AddToastAsync(string message, string type = "default", string animation = "bounce", int autoClose = 3000)
        {
            var toast = new Toast(type, animation, message, autoClose);
            _toasts.Add(toast);
            NotifyToastsStateHasChanged();

            await Task.Delay(autoClose);

            toast.EnterAnimation = false;
            toast.ExitAnimation = true;
            NotifyToastsStateHasChanged();

            await Task.Delay(600);
            toast.Visible = false;
            NotifyToastsStateHasChanged();

            // Clear toasts if all are not visible
            ClearAllToasts();
        }

        public async Task RemoveToastAsync(Toast toast)
        {
            if (toast == null)
                return;

            toast.EnterAnimation = false;
            toast.ExitAnimation = true;
            NotifyToastsStateHasChanged();

            await Task.Delay(600);

            toast.Visible = false;
            NotifyToastsStateHasChanged();

            ClearAllToasts();
        }

        public void ClearAllToasts()
        {
            bool allToastsHidden = true;

            _toasts.ForEach(t =>
            {
                if (t.Visible)
                    allToastsHidden = false;
            });

            if (!allToastsHidden)
                return;

            _toasts.Clear();
            NotifyToastsStateHasChanged();
        }

        private void NotifyToastsStateHasChanged() => ToastsStateChanged?.Invoke();
    }
}
