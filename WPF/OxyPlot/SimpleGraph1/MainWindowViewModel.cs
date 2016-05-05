using System.Collections.Generic;

using OxyPlot;

namespace SimpleGraph1
{
    public class MainWindowViewModel
    {
        public IList<DataPoint> GraphData { get; set; } = new List<DataPoint>();

        public MainWindowViewModel()
        {
            GraphData.Add(new DataPoint(1.0, 1.0));
            GraphData.Add(new DataPoint(2.0, 3.0));
            GraphData.Add(new DataPoint(3.0, 2.0));
        }
    }
}
