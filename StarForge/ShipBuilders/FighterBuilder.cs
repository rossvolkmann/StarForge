using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using StarForge.ColorSelectors;
using StarForge.Segments;
using StarForge.Ships;

namespace StarForge.ShipBuilders
{
    public class FighterBuilder : ShipBuilder
    {
        public FighterBuilder() 
        {
            this.shipType = typeof(Fighter);
        }

        public override List<Segment> createSegments(bool symmetrical)
        {
            List<Segment> segments = new List<Segment>();
            
            FighterWing portWing = new FighterWing();
            FighterCore core = new FighterCore();
            
            FighterWing starboardWing;
            if (symmetrical)
            {
                starboardWing = portWing;
            }
            else
            {
                starboardWing = new FighterWing();
            }

            segments.Add(portWing);
            segments.Add(core);
            segments.Add(starboardWing);

            return segments;
        }

        public override void colorSegments(List<Segment> segments, ColorSelector selector)
        {
            Color wingColor = selector.selectColor();
            Color coreColor = selector.selectColor();

            segments[0].SetColor(wingColor);
            segments[1].SetColor(coreColor);
            segments[2].SetColor(wingColor);
        }

        public override Ship constructShip(List<Segment> segments)
        {
            Ship fighter = new Fighter();
            fighter.Segments.AddRange(segments);
            fighter.AssembleShip();

            return fighter;
        }

        //public override Ship buildShip(ColorSelector colorSelector)
        //{
        //    Ship fighter = new Fighter();

        //    FighterWing portWing = new FighterWing();
        //    portWing.SetColor(colorSelector.selectColor());

        //    FighterCore core = new FighterCore();
        //    core.SetColor(colorSelector.selectColor());

        //    FighterWing starboardWing;
        //    if (symmetrical)
        //    {
        //        starboardWing = portWing;
        //    }
        //    else
        //    {

        //        starboardWing = new FighterWing();
        //        starboardWing.SetColor(portWing.Color);
        //    }

        //    fighter.Segments.Add(portWing);
        //    fighter.Segments.Add(core);
        //    fighter.Segments.Add(starboardWing);
        //    fighter.AssembleShip();

        //    return fighter;
        //}


    }
}
