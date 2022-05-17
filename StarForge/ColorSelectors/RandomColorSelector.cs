using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using StarForge.Segments;

namespace StarForge.ColorSelectors
{
    //Creates a random color from all possible colors in the Color class
    public class RandomColorSelector : ColorSelector
    {
        Random r = new Random();

        public Color selectColor()
        {
            return Color.FromArgb(r.Next(256),r.Next(256),r.Next(256));
        }
    }
}
