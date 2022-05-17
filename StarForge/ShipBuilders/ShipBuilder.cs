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
        protected bool symmetrical;
        protected Type shipType;

        public ShipBuilder(bool symmetrical)
        {
            this.symmetrical = symmetrical;
            this.shipType = typeof(Ship);
        }

        public bool Symmetrical { get => symmetrical; set => symmetrical = value; }
        public Type ShipType { get => this.shipType; }

        //public abstract Ship buildShip(ColorSelector selector);

        public virtual Ship buildShip(ColorSelector selector) 
        {
            List<Segment> segments = createSegments();
            colorSegments(segments, selector);
            return constructShip(segments);
        }

        public abstract List<Segment> createSegments();
        public abstract void colorSegments(List<Segment> segments, ColorSelector selector);
        public abstract Ship constructShip(List<Segment> segments);

    }
}
