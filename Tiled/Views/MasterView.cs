using System;
using Tiled.Models;
using Tiled.ViewModels;
using Xamarin.Forms;
using System.Linq;
using System.Collections.Generic;

namespace Tiled.Views
{
    public class MasterView : ContentPage
    {
        public MasterView()
        {
            this.Title = "Settings";
            this.BindingContext = new MasterViewModel();
            this.BackgroundColor = Color.DarkGray;

            var layout = new StackLayout()
            {
                Orientation = StackOrientation.Vertical
            };

            var title = new Label()
            {
                Margin = new Thickness(0, 50, 0, 0),
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                FontSize = 20,
                FontAttributes = FontAttributes.Bold,
                Text = "Tiled Animation Settings",
                TextColor = Color.White
            };
            layout.Children.Add(title);

            var tileSizeSlider = new Slider()
            {
                Margin = new Thickness(10, 50, 10, 0),
                Maximum = Constants.MAX_TILE_SIZE,
                Minimum = Constants.MIN_TILE_SIZE,
            };
            tileSizeSlider.SetBinding(Slider.ValueProperty, "TileSizeValue");
            layout.Children.Add(tileSizeSlider);

            var tileSizeDescription = new Label()
            {
                Margin = new Thickness(10, 10, 10, 0),
                HorizontalOptions = LayoutOptions.Start,
                FontSize = 14,
                TextColor = Color.White
            };
            tileSizeDescription.SetBinding(Label.TextProperty, "TileSizeDescription");
            layout.Children.Add(tileSizeDescription);

            var tileCountSlider = new Slider()
            {
                Margin = new Thickness(10, 50, 10, 0),
                Maximum = Constants.MAX_TILE_COUNT,
                Minimum = Constants.MIN_TILE_COUNT,
            };
            tileCountSlider.SetBinding(Slider.ValueProperty, "TileCountValue");
            layout.Children.Add(tileCountSlider);

            var tileCountDescription = new Label()
            {
                Margin = new Thickness(10, 10, 10, 0),
                HorizontalOptions = LayoutOptions.Start,
                FontSize = 14,
                TextColor = Color.White
            };
            tileCountDescription.SetBinding(Label.TextProperty, "TileCountDescription");
            layout.Children.Add(tileCountDescription);

            var animationStyleTitle = new Label()
            {
                Margin = new Thickness(10, 50, 10, 0),
                HorizontalOptions = LayoutOptions.Start,
                Text = "Animation style",
                FontSize = 14,
                TextColor = Color.White
            };
            layout.Children.Add(animationStyleTitle);

            var animationStyles = (AnimationStyle[])Enum.GetValues(typeof(AnimationStyle));
            var animationStyle = new Picker()
            {
                Margin = new Thickness(10, 10, 10, 0),
                ItemsSource = new List<AnimationStyle>(animationStyles)
            };
            animationStyle.SetBinding(Picker.SelectedItemProperty, "SelectedAnimationStyle");
            layout.Children.Add(animationStyle);

            Content = layout;
        }
    }
}
