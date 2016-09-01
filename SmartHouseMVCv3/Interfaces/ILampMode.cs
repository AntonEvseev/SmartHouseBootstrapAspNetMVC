using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartHouseMVCv3.Enum;

namespace SmartHouseMVCv3.Interfaces
{
    public interface ILampMode
    {
        BrightnessLevel Level
        {
            get;
        }
        void SetLowBrightness();
        void SetMediumBrightness();
        void SetHighBrightness();
    }
}
