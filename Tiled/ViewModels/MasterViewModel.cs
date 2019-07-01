using System;
using Tiled.Models;
using Xamarin.Forms;

namespace Tiled.ViewModels
{
    public class MasterViewModel : ViewModelBase
    {
        private int _tileSizeValue;
        public int TileSizeValue
        {
            get
            {
                return _tileSizeValue;
            }
            set
            {
                if (_tileSizeValue != value)
                {
                    _tileSizeValue = value;
                    OnPropertyChanged("TileSizeValue");
                    TileSizeDescription = $"Tile size: {_tileSizeValue}";
                    MessagingCenter.Send<MasterViewModel, int>(this, Constants.MC_TOPIC_TILE_SIZE_UPDATED, _tileSizeValue);
                }
            }
        }

        private string _tileSizeDescription;
        public string TileSizeDescription
        {
            get
            {
                return _tileSizeDescription;
            }
            set
            {
                if (_tileSizeDescription != value)
                {
                    _tileSizeDescription = value;
                    OnPropertyChanged("TileSizeDescription");
                }
            }
        }

        private int _tileCountValue;
        public int TileCountValue
        {
            get
            {
                return _tileCountValue;
            }
            set
            {
                if (_tileCountValue != value)
                {
                    _tileCountValue = value;
                    OnPropertyChanged("TileCountValue");
                    TileCountDescription = $"Tile count: {_tileCountValue}";
                    MessagingCenter.Send<MasterViewModel, int>(this, Constants.MC_TOPIC_TILE_COUNT_UPDATED, _tileCountValue);
                }
            }
        }

        private string _tileCountDescription;
        public string TileCountDescription
        {
            get
            {
                return _tileCountDescription;
            }
            set
            {
                if (_tileCountDescription != value)
                {
                    _tileCountDescription = value;
                    OnPropertyChanged("TileCountDescription");
                }
            }
        }

        private AnimationStyle _selectedAnimationStyle;
        public AnimationStyle SelectedAnimationStyle
        {
            set
            {
                _selectedAnimationStyle = value;
                MessagingCenter.Send<MasterViewModel, AnimationStyle>(this, Constants.MC_TOPIC_ANIMATION_STYLE_UPDATED, _selectedAnimationStyle);
            }
        }

        public MasterViewModel()
        {
            TileSizeValue = Constants.DEFAULT_TILE_SIZE;
            TileCountValue = Constants.DEFAULT_TILE_COUNT;
        }
    }
}
