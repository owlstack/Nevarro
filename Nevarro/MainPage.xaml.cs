using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.DualScreen;

namespace Nevarro
{
    //Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            twoPaneView.TallModeConfiguration = Xamarin.Forms.DualScreen.TwoPaneViewTallModeConfiguration.TopBottom;
        }

        void OnNavigateToSample(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            switch (button.Text)
            {
                case "Two Page":
                    Navigation.PushAsync(new TwoPage());
                    break;
                case "Companion Pane":
                    Navigation.PushAsync(new CompanionPane());
                    break;
            }
        }
    }
}
