using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace StarForge.ColorSelectors
{
    public class NoColorSelector : ColorSelector
    {
        public Color selectColor()
        {
            return Color.White;
        }
    }
}
