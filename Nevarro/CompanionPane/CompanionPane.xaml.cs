using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using Nevarro.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Nevarro
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CompanionPane : ContentPage, INotifyPropertyChanged
    {
        List<string> _dataSource;
        private ObservableCollection<Uri> imagesList;
        public CompanionPane()
        {
            InitializeComponent();

            _dataSource =
                Enumerable.Range(1, 1000)
                    .Select(i => $"{i}")
                    .ToList();

            twoPaneView.TallModeConfiguration = Xamarin.Forms.DualScreen.TwoPaneViewTallModeConfiguration.TopBottom;
            cv.ItemsSource = _dataSource;

            indicators.SelectedItem = _dataSource[0];

            cv.PositionChanged += OnCarouselViewPositionChanged;
            indicators.SelectionChanged += OnIndicatorsSelectionChanged;
        }

        protected override async void OnAppearing()
        {
            var images = await FetchMediaService.CallImagesEndpoint();
            ImagesList = images;
            cv.ItemsSource = ImagesList;

        }

        public ObservableCollection<Uri> ImagesList
        {
            get => imagesList;
            set
            {
                if (imagesList == value)
                    return;

                imagesList = value;
                OnPropertyChanged(nameof(ImagesList));
            }
        }

        void OnIndicatorsSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (indicators.SelectedItem == null)
                return;

            if (ImagesList.Contains(indicators.SelectedItem))
            {
                int index = ImagesList.IndexOf((Uri)indicators.SelectedItem);
                cv.Position = _dataSource.IndexOf((index + 1).ToString());
            }
            else
            {
                cv.Position = _dataSource.IndexOf((string)indicators.SelectedItem);
            }
        }

        void OnCarouselViewPositionChanged(object sender, PositionChangedEventArgs e)
        {
            indicators.SelectedItem = _dataSource[e.CurrentPosition];
            indicators.ScrollTo(e.CurrentPosition);
        }
    }
}
