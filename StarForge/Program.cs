using System;
using Pastel;
using System.Drawing;
using StarForge.ShipBuilders;
using StarForge.ColorSelectors;
using System.Collections.Generic;
using StarForge.Ships;

/**
 * StarForge! is a console program that generates randomized ASCII starship designs.  
 * by: Ross Volkmann 05/16/2022
 * 
 * Acknowledgements:
 * This program uses silkfire's Pastel package to color console content. Note, console
 * color may not work on Mac OS.  https://github.com/silkfire/Pastel#readme
 * 
 * The premise for this program was inspired by Huw Millward's "Vortex" program
 */
namespace StarForge
{
    class Program
    {

        static void Main(string[] args)
        {
            //Create main locals
            Random r = new Random();
            string nextDesign = "\n\nAWAITING SCHEMATICS   AWAITING SCHEMATICS   AWAITING SCHEMATICS\n\n".Pastel(Color.OrangeRed);// placeholder
            bool symmetrical = true;
            bool cruiser = true;
            bool fighter = true;
            bool dread = true;
            bool curatedColor = true;

            //Create color selectors and add to tracking list
            ColorSelector curatedColorSelector = new CuratedColorSelector();
            ColorSelector randomColorSelector = new RandomColorSelector();
            List<ColorSelector> colorSelectors = new List<ColorSelector>();
            colorSelectors.Add(curatedColorSelector);
            colorSelectors.Add(randomColorSelector);
            ColorSelector currentColorSelector = curatedColorSelector;


            //Create shipbuilders and add to tracking lists
            List<ShipBuilder> activeBuilders = new List<ShipBuilder>();
            List<ShipBuilder> allBuilders = new List<ShipBuilder>();
            ShipBuilder cruiserBuilder = new CruiserBuilder(symmetrical);
            ShipBuilder fighterBuilder = new FighterBuilder(symmetrical);
            ShipBuilder dreadBuilder = new DreadnoughtBuilder(symmetrical);
            activeBuilders.Add(cruiserBuilder);
            activeBuilders.Add(fighterBuilder);
            activeBuilders.Add(dreadBuilder);
            allBuilders.Add(cruiserBuilder);
            allBuilders.Add(fighterBuilder);
            allBuilders.Add(dreadBuilder);

            ShipBuilder currentShipBuilder = cruiserBuilder; //by default 

            ////////////////////////   
            // Start of Execution //
            ////////////////////////
            displayLandingScreen();
            Console.Read();

            // main ship designer loop
            bool done = false;
            while (!done)
            {
                Console.Clear();
                displayMainInterface(nextDesign, symmetrical, cruiser, fighter, dread, curatedColor);

                string input = Console.ReadLine();

                switch (parseUserInput(input))
                {
                    case ('n'):
                        //select random builder
                        if(activeBuilders.Count == 0)
                        {
                            break;
                        }

                        int next = r.Next(activeBuilders.Count);
                        currentShipBuilder = activeBuilders[next];
                        Type shipType = currentShipBuilder.ShipType;
                        nextDesign = currentShipBuilder.buildShip(currentColorSelector).Design;
                        break;
                    case ('q'):
                        displayExitScreen();
                        done = true;
                        break;
                    case ('s'):
                        symmetrical = !symmetrical;
                        foreach(ShipBuilder sb in allBuilders)
                        {
                            sb.Symmetrical = symmetrical;
                        }
                        break;
                    case ('f'): //refactor - replace these with ternary operators later
                        fighter = !fighter;
                        if(fighter == false)
                        {
                            activeBuilders.Remove(fighterBuilder);
                        }
                        else
                        {
                            activeBuilders.Add(fighterBuilder);
                        }
                        break;
                    case ('c'):
                        cruiser = !cruiser;
                        if(cruiser == false)
                        {
                            activeBuilders.Remove(cruiserBuilder);
                        }
                        else
                        {
                            activeBuilders.Add(cruiserBuilder);
                        }
                        break;
                    case ('d'):
                        dread = !dread;
                        if(dread == false)
                        {
                            activeBuilders.Remove(dreadBuilder);
                        }
                        else
                        {
                            activeBuilders.Add(dreadBuilder);
                        }
                        break;
                    case ('x'):
                        curatedColor = !curatedColor;
                        if(curatedColor == true) {
                            currentColorSelector = curatedColorSelector;
                        }
                        else
                        {
                            currentColorSelector = randomColorSelector;
                        }
                        break;
                    default:
                        break;
                }

            }
            Console.Read();
        }



        // takes input string and converts it to a single lowercase character
        // guards against null or empty strings
        private static char parseUserInput(string input)
        {
            char val;
            if (String.IsNullOrEmpty(input))
            {
                val = ' ';// arbitrary placeholder value
            }
            else
            {
                val = input.ToLower()[0];
            }
            return val;
        }

        //
        public static void displayMainInterface(string shipDesign, bool symmetrical, bool cruiser, bool fighter, bool dread, bool curatedC)
        {
            string starforgeStatus;
            if(fighter == false && cruiser == false && dread == false)
            {
                starforgeStatus = "OFFLINE - WARNING: NO VALID SHIP PARAMETERS SELECTED".Pastel(Color.Maroon);
            }
            else
            {
                starforgeStatus = "OPERATIONAL".Pastel(Color.LightGreen);
            }


            Console.WriteLine("STARFORGE STATUS: " + starforgeStatus);
            Console.WriteLine("________________________________________________________________\n");// 64 characters wide
            Console.WriteLine(shipDesign);
            Console.WriteLine("________________________________________________________________\n");
            Console.WriteLine("          [N - Next Ship]              [Q - Quit]\n");
            Console.WriteLine(@"////////////////////////////////\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\");
            Console.WriteLine("Options:\n");
            Console.WriteLine(" [S - " + colorOption("SYMMETRICAL", symmetrical)+ "   " + colorOption("ASYMMETRICAL", !symmetrical) + "]\n");
            Console.WriteLine(" [F - " + colorOption("ALLOW FIGHTER", fighter)+ "] [C - " + colorOption("ALLOW CRUISER", cruiser) + "] [D - " + colorOption("ALLOW DREADNOUGHT", dread) + "]\n");
            Console.WriteLine(" [X - " + colorOption("STARFORGE COLORS", curatedC) + "   " + colorOption("RANDOM COLORS", !curatedC) + "]");

        }

        private static string colorOption(string option, bool active)
        {
            if (active)
            {
                option = option.PastelBg(Color.Green);
            }
            else
            {
                option = option.PastelBg(Color.Maroon);
            }
            return option;
        }

        //Credit to https://fsymbols.com/generators/carty/ for the logo
        public static void displayLandingScreen()
        {
            Console.WriteLine("╔═══╗╔╗──────╔═══╗──────────╔╗\n║╔═╗╠╝╚╗─────║╔══╝──────────║║\n║╚══╬╗╔╬══╦═╗║╚══╦══╦═╦══╦══╣║\n╚══╗║║║║╔╗║╔╝║╔══╣╔╗║╔╣╔╗║║═╬╝\n║╚═╝║║╚╣╔╗║║─║║──║╚╝║║║╚╝║║═╬╗\n╚═══╝╚═╩╝╚╩╝─╚╝──╚══╩╝╚═╗╠══╩╝\n──────────────────────╔═╝║\n──────────────────────╚══╝");
            Console.WriteLine("Press enter to continue...");
        }

        public static void displayExitScreen()
        {
            Console.Clear();
            Console.WriteLine("Thank you for playing!");
            Console.WriteLine("Press any enter to exit...");
        }
    }
}
