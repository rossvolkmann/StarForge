using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using StarForge.ColorSelectors;
using Pastel;

namespace StarForge.Segments
{
    public abstract class Segment
    {
        protected string design;
        protected Color color;
        protected Random r = new Random();
        protected const string LEFT_OFFSET_PADDING = "     ";

        public Segment()
        {
            this.design = "";
            this.color = Color.White;
        }

        // alternate constructor for copying mirror components
        public Segment(Segment cloneSegment)
        {
            this.design = cloneSegment.Design;
            this.color = Color.White;
        }

        public abstract void setDesign();

        public string Design { get => design; }

        public Color Color { get => this.color; }

        public void SetColor(Color color)
        {
            this.color = color;
            this.design = this.design.Pastel(this.color);
        }

        //Adds a random number of spaces at the beginning of a segment up to maxPadLength
        public virtual string randomPadding(int maxPadLength)
        {
            int pad = r.Next(maxPadLength);
            string val = "";
            for(int i = 0; i < pad; i++)
            {
                val += " ";
            }
            return val;
        }
        
    }
}
