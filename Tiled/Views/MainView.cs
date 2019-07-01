using System;
using Xamarin.Forms;
using Tiled.ViewModels;

namespace Tiled.Views
{
    public class MainView : MasterDetailPage
    {
        public MainView()
        {
            this.Master = new MasterView();
            this.Detail = new DetailView();
        }
    }
}
