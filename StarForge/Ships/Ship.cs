using System;
using System.Collections.Generic;
using System.Text;
using StarForge.Segments;

namespace StarForge.Ships
{
    public abstract class Ship
    {
        protected List<Segment> segments;
        protected string design;

        public Ship()
        {
            this.segments = new List<Segment>();
            this.design = "";
        }

        public List<Segment> Segments { get => segments;}

        public String Design { get => design; }


        public void AssembleShip()
        {
            string value = "";
            foreach(Segment s in segments)
            {
                value += s.Design + "\n";
            }
            this.design = value;
        }
    }
}
