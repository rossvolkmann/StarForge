using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using StarForge.ColorSelectors;

namespace StarForge.Segments
{
    public class CoreSegment : Segment
    {

        public CoreSegment()
        {
            this.setDesign();
        }


        public override void setDesign()
        {
            int rand = r.Next(Inventory.CoreSegments.Count);
            this.design = LEFT_OFFSET_PADDING + randomPadding(5) + Inventory.CoreSegments[rand];
        }
    }
}
