using System;
using System.Collections.Generic;
using System.Text;

namespace StarForge.Segments
{
    public class Nacelle : Segment
    {

        public Nacelle()
        {
            this.setDesign();
        }


        public override void setDesign()
        {
            int rand = r.Next(Inventory.NacelleSegments.Count);
            this.design = LEFT_OFFSET_PADDING + randomPadding(5) + Inventory.NacelleSegments[rand];
        }
    }
}
