using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MonkeyFinder.ViewModel;

public class BaseViewModel : INotifyPropertyChanged
{
    private bool isBusy;
    private string title;

    public bool IsBusy
    {
        get => isBusy;
        set
        {
            if(isBusy == value)
                return;
            isBusy = value;
            OnPropertyChanged("IsBusy");
        }
    }
    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(string Name)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(Name));
    }

    // protected bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
    // {
    //     if (EqualityComparer<T>.Default.Equals(field, value)) return false;
    //     field = value;
    //     OnPropertyChanged(propertyName);
    //     return true;
    // }
}