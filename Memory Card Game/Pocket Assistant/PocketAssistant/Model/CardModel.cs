using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PocketAssistant.Model
{
    public class CardModel : INotifyPropertyChanged
    {
        private string _images;
        public string Images
        {
            get
            {
                return _images;
            }
            set
            {
                _images = value;
                NotifyPropertyChanged(nameof(Images));

            }
        }

        private string _tabId;
        public string TabId
        {
            get
            {
                return _tabId;
            }
            set
            {
                _tabId = value;
                NotifyPropertyChanged(nameof(TabId));

            }
        }

        private bool _isFlipped;
        public bool IsFlipped
        {
            get
            {
                return _isFlipped;
            }
            set
            {
                _isFlipped = value;
                NotifyPropertyChanged(nameof(IsFlipped));
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertName));
        }
    }
}
