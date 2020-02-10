﻿using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Nevarro
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CompanionPane : DuoPage
    {
        List<string> _dataSource;
        public CompanionPane()
        {
            InitializeComponent();

            _dataSource =
                Enumerable.Range(1, 1000)
                    .Select(i => $"{i}")
                    .ToList();

            twoPaneView.TallModeConfiguration = TwoPaneViewTallModeConfiguration.TopBottom;
            cv.ItemsSource = _dataSource;

            indicators.SelectedItem = _dataSource[0];

            cv.PositionChanged += OnCarouselViewPositionChanged;
            indicators.SelectionChanged += OnIndicatorsSelectionChanged;
        }

        void OnIndicatorsSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (indicators.SelectedItem == null)
                return;

            cv.Position = _dataSource.IndexOf((string)indicators.SelectedItem);
        }

        void OnCarouselViewPositionChanged(object sender, PositionChangedEventArgs e)
        {
            indicators.SelectedItem = _dataSource[e.CurrentPosition];
            indicators.ScrollTo(e.CurrentPosition);
        }
    }
}
