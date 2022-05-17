using System;
using System.Collections.Generic;
using System.Text;

namespace StarForge.Segments
{
    public class FighterCore : Segment
    {
        public FighterCore()
        {
            this.setDesign();
        }


        public override void setDesign()
        {
            int rand = r.Next(Inventory.FighterCoreSegments.Count);
            this.design = LEFT_OFFSET_PADDING + randomPadding(3) + Inventory.FighterCoreSegments[rand];
        }
    }
}
