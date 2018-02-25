using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.RouteImage
{
    public interface IObservableUrlGenerator
    {
        Uri GenerateFullUrl();
    }
}
