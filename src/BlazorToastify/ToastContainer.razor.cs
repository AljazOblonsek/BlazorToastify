using Microsoft.AspNetCore.Components;

namespace BlazorToastify
{
    public partial class ToastContainer : ComponentBase
    {
        [Inject]
        public IToastService ToastService { get; set; }

        protected override void OnInitialized()
        {
            ToastService.ToastsStateChanged += StateHasChanged;
        }
    }
}
