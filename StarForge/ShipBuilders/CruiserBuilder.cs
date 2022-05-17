using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using StarForge.ColorSelectors;
using StarForge.Segments;
using StarForge.Ships;

namespace StarForge.ShipBuilders
{
    class CruiserBuilder : ShipBuilder
    {

        public CruiserBuilder(bool symmetrical) : base(symmetrical)
        {
            this.shipType = typeof(Cruiser);
        }

        public override void colorSegments(List<Segment> segments, ColorSelector selector)
        {
            Color nacelleColor = selector.selectColor();
            Color innerHullColor = selector.selectColor();
            Color coreColor = selector.selectColor();

            segments[0].SetColor(nacelleColor);
            segments[1].SetColor(innerHullColor);
            segments[2].SetColor(coreColor);
            segments[3].SetColor(innerHullColor);
            segments[4].SetColor(nacelleColor);
        }

        public override List<Segment> createSegments()
        {
            List<Segment> segments = new List<Segment>();
            Nacelle portNacelle = new Nacelle();
            InnerHullSegment portInnerHull = new InnerHullSegment();
            CoreSegment core = new CoreSegment();
           
            InnerHullSegment starboardInnerHull;
            Nacelle starboardNacelle;

            if (this.symmetrical)
            {
                starboardInnerHull = portInnerHull; //refactor this later to ensure new object created
                starboardNacelle = portNacelle;
            }
            else
            {
                starboardInnerHull = new InnerHullSegment();
                starboardNacelle = new Nacelle();
            }
            segments.Add(portNacelle);
            segments.Add(portInnerHull);
            segments.Add(core);
            segments.Add(starboardInnerHull);
            segments.Add(starboardNacelle);

            return segments;
        }

        public override Ship constructShip(List<Segment> segments)
        {
            Ship ship = new Cruiser();
            for (int i = 0; i < segments.Count; i++)
            {
                ship.Segments.Add(segments[i]);
            }
            ship.AssembleShip();
            return ship;
        }

        //public override Ship buildShip(ColorSelector colorSelector)
        //{
        //    Ship cruiser = new Cruiser();

        //    Nacelle portNacelle = new Nacelle();
        //    portNacelle.SetColor(colorSelector.selectColor());

        //    InnerHullSegment portInnerHull = new InnerHullSegment();
        //    portInnerHull.SetColor(colorSelector.selectColor());

        //    CoreSegment core = new CoreSegment();
        //    core.SetColor(colorSelector.selectColor());

        //    InnerHullSegment starboardInnerHull;
        //    Nacelle starboardNacelle;

        //    if (this.symmetrical)
        //    {
        //        starboardInnerHull = portInnerHull;
        //        starboardNacelle = portNacelle;
        //    }
        //    else
        //    {
        //        starboardInnerHull = new InnerHullSegment();
        //        starboardInnerHull.SetColor(portInnerHull.Color);

        //        starboardNacelle = new Nacelle();
        //        starboardNacelle.SetColor(portNacelle.Color);
        //    }

        //    cruiser.Segments.Add(portNacelle);
        //    cruiser.Segments.Add(portInnerHull);
        //    cruiser.Segments.Add(core);
        //    cruiser.Segments.Add(starboardInnerHull);
        //    cruiser.Segments.Add(starboardNacelle);
        //    cruiser.AssembleShip();

        //    return cruiser;
        //}

    }// class
}
