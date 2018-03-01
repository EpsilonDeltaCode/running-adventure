using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Base;

namespace Backend.RouteImage
{
    public interface IObservableUrlGenerator
    {
        IList<IGeoCoordinate> Coordinates { get; set; }
        Uri GenerateFullUrl();
    }
}
