using System;
using System.Collections.Generic;
using System.Text;

namespace StarForge.Segments
{
    public class FighterWing : Segment
    {

        public FighterWing ()
        {
            this.setDesign();
        }


        public override void setDesign()
        {
            int rand = r.Next(Inventory.FighterWingSegments.Count);
            this.design = LEFT_OFFSET_PADDING + randomPadding(3) + Inventory.FighterWingSegments[rand];
        }
    }
}
