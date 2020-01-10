using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorToastify
{
    public interface IToastService
    {
        List<Toast> Toasts { get; set; }
        event Action ToastsStateChanged;

        Task AddToastAsync(string message, string type = "default", string animation = "bounce", int autoClose = 3000);
        Task RemoveToastAsync(Toast toast);
        void ClearAllToasts();
    }
}
