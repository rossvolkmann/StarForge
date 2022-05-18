using System;
using System.Collections.Generic;
using System.Text;
using StarForge.ColorSelectors;
using StarForge.Segments;
using StarForge.Ships;
using System.Drawing;

namespace StarForge.ShipBuilders
{
    class DreadnoughtBuilder : ShipBuilder
    {
        public DreadnoughtBuilder()
        {
            this.shipType = typeof(Dreadnought);
        }

        public override List<Segment> createSegments(bool symmetrical)
        {
            List<Segment> segments = new List<Segment>();

            Nacelle portNacelle = new Nacelle();
            InnerHullSegment portInnerHull = new InnerHullSegment();
            InnerHullSegment portInnerHull2 = new InnerHullSegment();
            CoreSegment portCore = new CoreSegment();
            CoreSegment centralCore = new CoreSegment();

            CoreSegment starboardCore;
            InnerHullSegment starboardInnerHull;
            InnerHullSegment starboardInnerHull2;
            Nacelle starboardNacelle;

            if (symmetrical)
            {
                starboardCore = portCore;
                starboardInnerHull = portInnerHull;
                starboardInnerHull2 = portInnerHull2;
                starboardNacelle = portNacelle;
            }
            else
            {
                starboardCore = new CoreSegment();
                starboardInnerHull = new InnerHullSegment();
                starboardInnerHull2 = new InnerHullSegment();
                starboardNacelle = new Nacelle();
                
            }

            segments.Add(portNacelle);
            segments.Add(portInnerHull);
            segments.Add(portInnerHull2);
            segments.Add(portCore);
            segments.Add(centralCore);
            segments.Add(starboardCore);
            segments.Add(starboardInnerHull2);
            segments.Add(starboardInnerHull);
            segments.Add(starboardNacelle);

            return segments;
        }

        public override void colorSegments(List<Segment> segments, ColorSelector selector)
        {
            Color nacelleColor = selector.selectColor();
            Color innerHullColor = selector.selectColor();
            Color coreColor = selector.selectColor();

            segments[0].SetColor(nacelleColor);
            segments[1].SetColor(innerHullColor);
            segments[2].SetColor(innerHullColor);
            segments[3].SetColor(coreColor);
            segments[4].SetColor(coreColor);
            segments[5].SetColor(coreColor);
            segments[6].SetColor(innerHullColor);
            segments[7].SetColor(innerHullColor);
            segments[8].SetColor(nacelleColor);
        }

        public override Ship constructShip(List<Segment> segments)
        {
            Ship dread = new Dreadnought();
            dread.Segments.AddRange(segments);
            dread.AssembleShip();

            return dread;
        }

        //public override Ship buildShip(ColorSelector colorSelector)
        //{
        //    Ship dread = new Dreadnought();

        //    Color nacelleColor = colorSelector.selectColor();
        //    Color innerHullColor = colorSelector.selectColor();
        //    Color coreColor = colorSelector.selectColor();


        //    Nacelle portNacelle = new Nacelle();
        //    portNacelle.SetColor(nacelleColor);

        //    InnerHullSegment portInnerHull = new InnerHullSegment();
        //    portInnerHull.SetColor(innerHullColor);
        //    InnerHullSegment portInnerHull2 = new InnerHullSegment();
        //    portInnerHull2.SetColor(innerHullColor);


        //    CoreSegment portCore = new CoreSegment();
        //    portCore.SetColor(coreColor);
        //    CoreSegment centralCore = new CoreSegment();
        //    centralCore.SetColor(coreColor);
        //    CoreSegment starboardCore;

        //    InnerHullSegment starboardInnerHull;
        //    InnerHullSegment starboardInnerHull2;
        //    Nacelle starboardNacelle;

        //    if (this.symmetrical)
        //    {
        //        starboardCore = portCore;
        //        starboardInnerHull = portInnerHull;
        //        starboardInnerHull2 = portInnerHull2;
        //        starboardNacelle = portNacelle;
        //    }
        //    else
        //    {
        //        starboardCore = new CoreSegment();
        //        starboardCore.SetColor(coreColor);
        //        starboardInnerHull = new InnerHullSegment();
        //        starboardInnerHull.SetColor(innerHullColor);
        //        starboardInnerHull2 = new InnerHullSegment();
        //        starboardInnerHull2.SetColor(innerHullColor);

        //        starboardNacelle = new Nacelle();
        //        starboardNacelle.SetColor(nacelleColor);
        //    }

        //    dread.Segments.Add(portNacelle);
        //    dread.Segments.Add(portInnerHull);
        //    dread.Segments.Add(portInnerHull2);
        //    dread.Segments.Add(portCore);
        //    dread.Segments.Add(centralCore);
        //    dread.Segments.Add(starboardCore);
        //    dread.Segments.Add(starboardInnerHull2);
        //    dread.Segments.Add(starboardInnerHull);
        //    dread.Segments.Add(starboardNacelle);
        //    dread.AssembleShip();

        //    return dread;
        //}

    }
}
