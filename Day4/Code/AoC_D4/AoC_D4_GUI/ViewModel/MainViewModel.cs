using AoC_D4;
using AoC_D4_GUI.Core;
using AoC_D4_GUI.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AoC_D4_GUI.ViewModel
{
    internal class MainViewModel : INotifyPropertyChanged
    {
        #region Interface
        public event PropertyChangedEventHandler PropertyChanged;

        protected bool SetProperty<T>(ref T field, T newValue, [CallerMemberName] string propertyName = null)
        {
            if (!Equals(field, newValue))
            {
                field = newValue;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
                return true;
            }

            return false;
        }
        #endregion

        private string filename = "";
        public string Filename { get => filename; set => SetProperty(ref filename, value); }

        private List<ICard> cards = new List<ICard>();
        public List<ICard> Cards { get => cards; set => SetProperty(ref cards, value); }

        public ulong PointSum => CardUtil.SumPointValues(Cards);

        public MainViewModel()
        {
            PropertyChanged += MainViewModel_PropertyChanged;

            cards = new CardFactory().GetCards(ExampleInput.all_input);
        }

        private void MainViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch(e.PropertyName)
            {
                case "Cards":
                    PropertyChanged?.Invoke(sender, new PropertyChangedEventArgs("PointSum"));
                    break;
            }
        }

    }
}
