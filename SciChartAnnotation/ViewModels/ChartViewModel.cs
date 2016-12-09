using SciChart.Charting.Model.ChartSeries;
using SciChart.Charting.Model.DataSeries;
using SciChart.Charting.ViewportManagers;
using SciChart.Charting.Visuals;
using SciChart.Charting.Visuals.Annotations;
using SciChartAnnotation.Annotations;
using SciChartAnnotation.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SciChartAnnotation.ViewModels
{
    public class ChartViewModel : BaseViewModel
    {
        public virtual SciChartSurface Chart { get; set; }

        public IViewportManager ViewportManager { get; }

        public virtual ObservableCollection<IRenderableSeriesViewModel> RenderableSeriesViewModels { get; set; } = new ObservableCollection<IRenderableSeriesViewModel>();

        public virtual AnnotationCollection Annotations { get; } = new AnnotationCollection();


        public bool CanAddAnnotation { get; set; }


        public ChartViewModel()
        {
            ViewportManager = new DefaultViewportManager();

            var dataSeries = new XyDataSeries<float, float>();
            var x = new float[] { 1, 2, 4, 5, 6, 7 };
            var y = new float[] { 4, 2, 3, 1, 2, 3 };

            dataSeries.SeriesName = "Series 1";
            dataSeries.Append(x, y);

            var viewModel = new LineRenderableSeriesViewModel { DataSeries = dataSeries, StyleKey = "LineStyle" };

            RenderableSeriesViewModels.Add(viewModel);

            var annotation = new ExHorizontalLineAnnotation { Caption = "Annotation", Y1 = 2 };

            Annotations.Add(annotation);

            ViewportManager.ZoomExtents();
        }


        #region ClearAnnotationsCommand

        private ICommand _ClearAnnotationsCommand;
        public ICommand ClearAnnotationsCommand
        {
            get
            {
                if (_ClearAnnotationsCommand==null)
                {
                    _ClearAnnotationsCommand = new RelayCommand(p=>ClearAnnotations());
                }

                return _ClearAnnotationsCommand;
            }

        }

        #endregion

        public void ClearAnnotations()
        {
            Annotations.Clear();
        }
    }
}
