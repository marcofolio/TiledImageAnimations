using System;
using System.ComponentModel;
using System.Threading.Tasks;
using Tiled.Models;
using Tiled.ViewModels;
using Xamarin.Forms;

namespace Tiled.Views
{
    public class DetailView : ContentPage
    {
        int _gridsize = Constants.DEFAULT_TILE_COUNT;
        int _tileSize = Constants.DEFAULT_TILE_SIZE;
        Label _description;
        Label _title;
        TiledImageView _tiledImageView;
        DetailViewModel _vm;
        StackLayout _layout;
        AnimationStyle _selectedAnimation;

        public DetailView()
        {
            this.Title = "Firework";

            MessagingCenter.Subscribe<MasterViewModel, int>(this, Constants.MC_TOPIC_TILE_COUNT_UPDATED, (sender, arg) => {
                _gridsize = arg;
            });
            MessagingCenter.Subscribe<MasterViewModel, int>(this, Constants.MC_TOPIC_TILE_SIZE_UPDATED, (sender, arg) => {
                _tileSize = arg;
            });
            MessagingCenter.Subscribe<MasterViewModel, AnimationStyle>(this, Constants.MC_TOPIC_ANIMATION_STYLE_UPDATED, (sender, arg) => {
                _selectedAnimation = arg;
            });

            _vm = new DetailViewModel();
            _vm.BeforeFireworkChange += OnBeforeFireworkChange;
            _vm.PropertyChanged += VMPropertyChanged;
            this.BindingContext = _vm;

            _layout = new StackLayout()
            {
                Orientation = StackOrientation.Vertical,
                BackgroundColor = Color.DarkSlateGray
            };

            _title = new Label()
            {
                HorizontalOptions = LayoutOptions.Center,
                Margin = new Thickness(0, 100, 0, 0),
                FontSize = 22,
                FontAttributes = FontAttributes.Bold,
                TextColor = Color.White
            };
            _title.SetBinding(Label.TextProperty, "Firework.Name");
            _layout.Children.Add(_title);

            RepaintTiledImageView();

            _description = new Label()
            {
                HorizontalOptions = LayoutOptions.Center,
                Margin = new Thickness(25),
                FontSize = 14,
                TextColor = Color.WhiteSmoke
            };
            _description.SetBinding(Label.TextProperty, "Firework.Description");
            _layout.Children.Add(_description);

            var nextButton = new Button()
            {
                Text = "Next",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.EndAndExpand,
                Margin = new Thickness(0, 0, 0, 25),
                TextColor = Color.White
            };
            nextButton.SetBinding(Button.CommandProperty, "NextCommand");
            _layout.Children.Add(nextButton);

            var scrollview = new ScrollView();
            scrollview.Content = _layout;

            Content = scrollview;
        }

        private void RepaintTiledImageView()
        {
            if(_tiledImageView != null)
            {
                _layout.Children.Remove(_tiledImageView);
            }
            _tiledImageView = new TiledImageView(_gridsize, _tileSize, _vm.Firework.Image)
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Start,
                RowSpacing = 0,
                ColumnSpacing = 0,
                Margin = new Thickness(0, 25, 0, 0)
            };
            _layout.Children.Insert(1, _tiledImageView);
        }

        private void VMPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName.Equals("Firework"))
            {
                DisplayTitleAndDescription();
                RepaintTiledImageView();
            }
        }

        private async void OnBeforeFireworkChange(object sender, Action e)
        {
            Task tiledAnimationMethod;
            switch(_selectedAnimation)
            {
                case AnimationStyle.Flip:
                    tiledAnimationMethod = _tiledImageView.Flip();
                    break;
                case AnimationStyle.Implode:
                    tiledAnimationMethod = _tiledImageView.Implode();
                    break;
                case AnimationStyle.Spin:
                    tiledAnimationMethod = _tiledImageView.Spin();
                    break;
                case AnimationStyle.Explode:
                default:
                    tiledAnimationMethod = _tiledImageView.Explode();
                    break;
            }

            await Task.WhenAll(
                    _title.FadeTo(0),
                    _description.TranslateTo(0, 50, easing: Easing.CubicIn),
                    _description.FadeTo(0),
                    tiledAnimationMethod
                );
            e.Invoke();
        }

        private async void DisplayTitleAndDescription()
        {
            await Task.WhenAll(
                _title.FadeTo(1),
                _description.TranslateTo(0, 0, easing: Easing.CubicOut),
                _description.FadeTo(1));
        }
    }
}
