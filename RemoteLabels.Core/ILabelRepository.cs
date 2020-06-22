using System;
using System.Collections.Generic;
using System.Text;

namespace RemoteLabels.Core
{
    public interface ILabelRepository
    {
        void UpdateLabel(string newLabel);
        string GetCurrentLabel();
    }
}
