using System.ComponentModel;
using System.Windows;
using System.Linq;

namespace AccountingOrders.WPF.ViewsModels
{
    public delegate TViewModel CreateViewModel<TViewModel>() where TViewModel : ViewModelBase;

    public class ViewModelBase: INotifyPropertyChanged
    {
        public virtual void Dispose() { }

        public void CloseWindow() => Application.Current.Windows.Cast<Window>().FirstOrDefault(w => w.DataContext == this)?.Close();

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        
        #endregion
    }
}