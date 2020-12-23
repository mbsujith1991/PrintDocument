using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PrintDoc
{
    public partial class MainPage : ContentPage
    {
        MainPageViewModel _viewModel;
        public MainPage()
        {
            InitializeComponent();
            _viewModel = new MainPageViewModel();
            this.BindingContext = _viewModel;
        }
    }
}
