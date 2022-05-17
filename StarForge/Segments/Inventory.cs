using System;
using System.Collections.Generic;
using System.Text;

namespace StarForge.Segments
{
    //A static library of stock segment designs.  
    public static class Inventory
    {
        private static List<string> coreSegments = new List<string> { 
            "[-] <><><>=]===[++-", 
            "-}(X-X-X)><(X-X-X)",
            "<>==<>==<>(-B-)<>==<>",
            "->>:-:-:-:():-:-:-:-:>=--",
            "-(=)((+)(-)(+)(<=>){-B-})}",
            "-:   :   :-",
            "#][    {-D-}=->",
            ":::::::}"
        };

        public static List<string> CoreSegments { get => coreSegments; }

        private static List<string> innerHullSegments = new List<string> {
            "X=X->>",
            "000><<+",
            "==>",
            "XX:}<==",
            "<00(+)00>>-",
            ">--<",
            "-<<::(+):>->--",
            ">(-(+)-)=(-(+)-)<"
        };

        public static List<string>InnerHullSegments { get => innerHullSegments; }

        private static List<string> nacelleSegments = new List<string> {
            "<[=]>>>",
            ">>----",
            "(=====)",
            "0=0>-",
            "-><000><-",
            ">0-0<<-",
            "<<<<<<>>>>>",
            ":--"
        };
            
        public static List<string> NacelleSegments { get => nacelleSegments; }

        private static List<string> fighterCoreSegments = new List<string>
        {
            "<<)-))-",
            ">------>",
            "-}::{}=-]",
            "->>",
            "-}>",
            "-0]",
            ">={-D}",
            ":--"
        };

        public static List<string> FighterCoreSegments { get => fighterCoreSegments; }

        private static List<string> fighterWingSegments = new List<string>
        {
            "<>-",
            "==>",
            ")>",
            "(--",
            ">-",
            "<-",
            "(-",
            "K(+)-"
        };

        public static List<string> FighterWingSegments { get => fighterWingSegments; }
    }
}
