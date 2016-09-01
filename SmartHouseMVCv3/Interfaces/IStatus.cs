using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouseMVCv3.Interfaces
{
    public interface IStatus
    {
        void OnDevice();
        void OffDevice();
    }
}
