using System;
using System.Windows.Input;
using Tiled.Data;
using Tiled.Models;
using Xamarin.Forms;

namespace Tiled.ViewModels
{
    public class DetailViewModel : ViewModelBase
    {
        public event EventHandler<Action> BeforeFireworkChange;

        private Firework _firework;
        public Firework Firework
        {
            get
            {
                return _firework;
            }
            set
            {
                if (_firework != value)
                {
                    _firework = value;
                    OnPropertyChanged("Firework");
                }
            }
        }

        public ICommand NextCommand { get; private set; }

        public DetailViewModel()
        {
            Firework = FireworksDb.Next();
            NextCommand = new Command(Next);
        }

        private async void Next()
        {
            OnBeforeFireworkChange(() => {
                Firework = FireworksDb.Next();
            });
        }

        protected virtual void OnBeforeFireworkChange(Action e)
        {
            BeforeFireworkChange?.Invoke(this, e);
        }
    }
}
