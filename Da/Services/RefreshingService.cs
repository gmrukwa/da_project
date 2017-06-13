using System;
using Da.ViewModels;

namespace Da.Services
{
    class RefreshingService
    {
        public RefreshingService(MainWindowVm mainWindowVm)
        {
            _vm = mainWindowVm;
        }

        public void Refresh()
        {
            _vm.RefreshCommand.Execute(null);
            OnRefresh?.Invoke(this, EventArgs.Empty);
        }

        public EventHandler OnRefresh;

        private readonly MainWindowVm _vm;
    }
}
