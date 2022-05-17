using System;
using System.Collections.Generic;
using System.Text;

namespace StarForge.Segments
{
    public class InnerHullSegment : Segment
    {

        public InnerHullSegment()
        {
            this.setDesign();
        }


        public override void setDesign()
        {
            int rand = r.Next(Inventory.InnerHullSegments.Count);
            this.design = LEFT_OFFSET_PADDING + randomPadding(5) + Inventory.InnerHullSegments[rand];
        }

    }
}
