using System.Collections.Generic;

using OxyPlot;

namespace LogarithmicGraph
{
    public class MainWindowViewModel
    {
        public IList<DataPoint> GraphData { get; set; } = new List<DataPoint>();

        public MainWindowViewModel()
        {
            GraphData.Add(new DataPoint(1.0, 1.0));
            GraphData.Add(new DataPoint(2.0, 1000.0));
            GraphData.Add(new DataPoint(3.0, 1000000.0));
        }
    }
}
