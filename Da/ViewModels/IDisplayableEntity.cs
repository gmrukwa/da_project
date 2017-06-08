using Spectre.Mvvm.Base;

namespace Da.ViewModels
{
    public interface IDisplayableEntity
    {
        object Entity { get; }
        RelayCommand Edit { get; }
    }
}