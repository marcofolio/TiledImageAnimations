using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tiled.ViewModels;
using Xamarin.Forms;

namespace Tiled.Views
{
    public class TiledImageView : Grid
    {
        private int _size;
        private int _tileSize;
        List<TileView> _tiles = new List<TileView>();

        public TiledImageView(int size, int tileSize, ImageSource source)
        {
            _size = size;
            _tileSize = tileSize;

            for (var i = 0; i < _size; i++)
            {
                this.RowDefinitions.Add(new RowDefinition { Height = new GridLength(tileSize) });
                this.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(tileSize) });
            }

            for (var x = 0; x < size; x++)
            {
                for (var y = 0; y < size; y++)
                {
                    var tile = AddTile(x, y, source);
                    _tiles.Add(tile);
                    this.Children.Add(tile, x, y);
                }
            }
        }

        private TileView AddTile(int xPos, int yPos, ImageSource source)
        {
            return new TileView(xPos, yPos, _size, _tileSize)
            {
                Source = source
            };
        }

        public async Task Explode()
        {
            var animations = new List<Task>();
            foreach (var tile in _tiles)
            {
                animations.Add(tile.TranslateTo(RandomPosition(), RandomPosition(), 800, Easing.SpringOut));
                animations.Add(tile.FadeTo(0, 600, Easing.Linear));
            }
            await Task.WhenAll(animations);
        }

        public async Task Implode()
        {
            var animations = new List<Task>();
            foreach (var tile in _tiles)
            {
                animations.Add(tile.ScaleTo(0, 800, Easing.CubicOut));
            }
            await Task.WhenAll(animations);
        }

        public async Task Flip()
        {
            var animations = new List<Task>();
            foreach (var tile in _tiles)
            {
                var random = _random.Next(2);
                if(random == 0)
                {
                    animations.Add(tile.RotateXTo(RandomRotation(), 800, Easing.CubicOut));
                }
                else
                {
                    animations.Add(tile.RotateYTo(RandomRotation(), 800, Easing.CubicOut));
                }
            }
            await Task.WhenAll(animations);
        }

        public async Task Spin()
        {
            var animations = new List<Task>();
            foreach (var tile in _tiles)
            {
                animations.Add(tile.RotateTo(RandomSpin(), 1000, Easing.CubicIn));
                animations.Add(tile.FadeTo(0, 800, Easing.Linear));
            }
            await Task.WhenAll(animations);
        }

        Random _random = new Random();
        private int RandomPosition()
        {
            var position = _random.Next(2);
            var factor = _random.Next(1, 3);

            switch (position)
            {
                case 0: return _tileSize * factor;
                case 1: return -_tileSize * factor;
            }

            return 0;
        }

        private int RandomRotation()
        {
            var random = _random.Next(2);

            switch (random)
            {
                case 0: return -90;
                case 1: return 90;
            }

            return 0;
        }

        private int RandomSpin()
        {
            var random = _random.Next(2);

            switch (random)
            {
                case 0: return -360;
                case 1: return 360;
            }

            return 0;
        }
    }
}
