using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using phirSOFT.Applications.GeantStudio.GeantWrapper.Annotations;

namespace phirSOFT.Applications.GeantStudio.GeantWrapper
{
    public abstract class SupportInitializeBase : ISupportInitialize, INotifyPropertyChanged
    {
        private bool _initializing;

        protected SupportInitializeBase()
        {
            _initializing = false;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void BeginInit()
        {
            _initializing = true;
        }

        public void EndInit()
        {
            _initializing = false;
        }

        protected void Set<T>(ref T field, T value)
        {
            Set(ref field, value, null);
        }

        protected void Set<T>(ref T field, T value, Predicate<T> validationCallback)
        {
            if (field.Equals(value)) return;

            if (!_initializing)
                throw new InvalidOperationException("Tried to modify locked property after initialization ended.");

            if (!(validationCallback?.Invoke(value) ?? true)) return;

            field = value;
            OnPropertyChanged();
        }


        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
