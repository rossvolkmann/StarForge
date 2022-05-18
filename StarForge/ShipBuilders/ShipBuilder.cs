using System;
using System.Collections.Generic;
using System.Text;
using StarForge.ColorSelectors;
using StarForge.Segments;
using StarForge.Ships;

namespace StarForge.ShipBuilders
{
    public abstract class ShipBuilder
    {
        protected Type shipType;

        public ShipBuilder()
        {
            this.shipType = typeof(Ship);
        }

        public Type ShipType { get => this.shipType; }

        //public abstract Ship buildShip(ColorSelector selector);

        public virtual Ship buildShip(ColorSelector selector, bool symmetry) 
        {
            List<Segment> segments = createSegments(symmetry);
            colorSegments(segments, selector);
            return constructShip(segments);
        }

        public abstract List<Segment> createSegments(bool symmetry);
        public abstract void colorSegments(List<Segment> segments, ColorSelector selector);
        public abstract Ship constructShip(List<Segment> segments);

    }
}
