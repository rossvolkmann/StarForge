using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace StarForge.ColorSelectors
{
    //Chooses randomly from a preset list of colors chosen by the designer
    public class CuratedColorSelector : ColorSelector
    {
        List<Color> colors;
        Random r = new Random();
        public CuratedColorSelector()
        {
            colors = new List<Color>();
            colors.Add(Color.Lime);
            colors.Add(Color.OrangeRed);
            colors.Add(Color.DarkViolet);
            colors.Add(Color.Gold);
            colors.Add(Color.Firebrick);
            colors.Add(Color.CornflowerBlue);
            colors.Add(Color.Cyan);
            colors.Add(Color.Snow);
            colors.Add(Color.Thistle);
            colors.Add(Color.Fuchsia);
        }

        public Color selectColor()
        {
            int next = r.Next(colors.Count);
            return colors[next];
        }
    }
}
