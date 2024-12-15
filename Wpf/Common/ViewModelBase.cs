using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MultiLanguageSearch.Wpf.Common
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public virtual void Remove()
        {
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected void SetValue<TValue>(ref TValue value, TValue newValue, [CallerMemberName] string propertyName = null)
        {
            this.SetValue(ref value, newValue, null, propertyName);
        }

        protected void SetValue<TValue>(ref TValue value, TValue newValue, Action action, [CallerMemberName] string propertyName = null)
        {
            if (value is ValueType ? !value.Equals(newValue) : (value != null || newValue != null) && (value == null || !value.Equals(newValue)))
            {
                value = newValue;

                this.OnPropertyChanged(propertyName);

                action?.Invoke();
            }
        }

        protected void SetValue<TValue>(Func<TValue> getValue, Action<TValue> setValue, TValue newValue, [CallerMemberName] string propertyName = null)
        {
            var value = getValue();

            if (value is ValueType ? !value.Equals(newValue) : (value != null || newValue != null) && (value == null || !value.Equals(newValue)))
            {
                setValue(newValue);
                this.OnPropertyChanged(propertyName);
            }
        }
    }
}
