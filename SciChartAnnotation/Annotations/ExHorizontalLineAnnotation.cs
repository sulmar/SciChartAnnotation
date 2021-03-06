﻿using SciChart.Charting.Visuals.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace SciChartAnnotation.Annotations
{
    public class ExHorizontalLineAnnotation : HorizontalLineAnnotation
    {
        public static readonly DependencyProperty CaptionProperty =
          DependencyProperty.Register(nameof(Caption), typeof(string), typeof(ExHorizontalLineAnnotation));


        private readonly DependencyPropertyDescriptor pd = DependencyPropertyDescriptor.FromProperty(X1Property,
            typeof(ExHorizontalLineAnnotation));

        public string Caption
        {
            get { return (string)GetValue(CaptionProperty); }
            set { SetValue(CaptionProperty, value); }
        }


        protected override void OnAnnotationLoaded(object sender, RoutedEventArgs e)
        {

            var annotationLabel = new AnnotationLabel
            {
                LabelPlacement = LabelPlacement.Top,
                CanEditText = true
            };
            CaptionBinding(annotationLabel);
            AnnotationLabels.Add(annotationLabel);

            X1 = null;
            
            Y1Binding();

            pd.AddValueChanged(this, OnValueChanged);

            base.OnAnnotationLoaded(sender, e);
        }

        private void OnValueChanged(object sender, EventArgs e)
        {
            X1 = null;
            OnPropertyChanged(nameof(Y1));
        }

        private void CaptionBinding(AnnotationLabel annotationLabel)
        {
            var binding = new Binding(nameof(Caption))
            {
                Source = this,
                Mode = BindingMode.TwoWay
            };
            annotationLabel.SetBinding(AnnotationLabel.TextProperty, binding);
        }

        private void Y1Binding()
        {
            var binding = new Binding("Y1") { Source = this };
            SetBinding(LabelValueProperty, binding);
        }

    }
}
