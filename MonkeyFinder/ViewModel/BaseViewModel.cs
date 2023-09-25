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
            OnPropertyChanged();
        }
    }

    public string Title
    {
        get => title;
        set
        {
            if(title == value)
                return;
            title = value;
            OnPropertyChanged();
        }
    }
    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName]string Name = null)
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