using SciChart.Charting.Visuals;
using SciChart.Core.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SciChartAnnotation.ViewModels
{
    public static class Injector
    {
        public static readonly DependencyProperty PassSurfaceToViewModelProperty = DependencyProperty.RegisterAttached(
           "PassSurfaceToViewModel", typeof(bool), typeof(Injector), new PropertyMetadata(default(bool), OnPassSurfaceToViewModelPropertyChanged));

        private static void OnPassSurfaceToViewModelPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var scs = d as SciChartSurface;
            if (scs == null || ((bool)e.NewValue) == false) return;

            scs.DataContextChanged += (s, arg) => UpdateProperty(scs, scs.DataContext as ChartViewModel);

            UpdateProperty(scs, scs.DataContext as ChartViewModel);

        }

        private static void UpdateProperty(SciChartSurface scs, ChartViewModel vm)
        {
            if (vm == null) return;
            vm.Chart = scs;

        }


        public static void SetPassSurfaceToViewModel(DependencyObject element, ISuspendable value)
        {
            element.SetValue(PassSurfaceToViewModelProperty, value);
        }

        public static bool GetPassSurfaceToViewModel(DependencyObject element)
        {
            return (bool)element.GetValue(PassSurfaceToViewModelProperty);
        }
    }
}
