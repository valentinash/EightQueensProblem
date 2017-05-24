using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace WindowsFormsApplication1
{
    public class Position
    {
        public static long LlogaritKohen = 0;
        public static int NumriTentimeve, NumriNyjeve, NumriZgjidhjeve, NumriMbretereshave = 8; // n queens
        public static string TeGjithaZgjidhjet = "";
        public static List<string> Zgjidhjet = new List<string>();
        private static Position MbretereshaMbi;
        private int line, Rresht;
        private Position Prindi;

        public Position(int Line, int rresht, Position prind)
        {
            line = Line;
            Rresht = rresht;
            Prindi = prind;
            NumriNyjeve++;
        }

        public void EcniNeperPeme()
        {
            Stopwatch sw = Stopwatch.StartNew();
            if (line == NumriMbretereshave) // linja e fundit (= NumriMbretereshave) arrihet: zgjidhja
            {
                //NumriZgjidhjeve++; // veteme i numeron
                PrintojZgjidhjet(this); // shtyp zgjidhjet
                LlogaritKohen = sw.ElapsedMilliseconds;
                sw.Stop();
                return;
            }
            for (var r = 0; r < NumriMbretereshave; r++) // provoi te gjithe rreshtat ne linjen e ardhshem
            {
                NumriTentimeve++;
                MbretereshaMbi = this;
                while (MbretereshaMbi.Rresht >= 0 && r != MbretereshaMbi.Rresht // kercenimi vertikal?
                        && r - MbretereshaMbi.Rresht != line + 1 - MbretereshaMbi.line // kercenimi diagonal majtas?
                        && MbretereshaMbi.Rresht - r != line + 1 - MbretereshaMbi.line) // kercenimi diagonal djathtas?
                    MbretereshaMbi = MbretereshaMbi.Prindi; // Përsëris kontrollimin për të gjitha mbretëreshat në linjat e mëparshme
                if (MbretereshaMbi.line == 0) // asnje kercenim nuk u gjet
                    new Position(line + 1, r, this).EcniNeperPeme(); // vendose mbretereshen ne vijen tjeter
            }
        }
        private static void PrintojZgjidhjet(Position Nyja)
        {
            NumriZgjidhjeve++;
            string Zgjidhja="";
            
            while (Nyja.Rresht >= 0)
            {
            
                TeGjithaZgjidhjet += (((char)('a' + Nyja.Rresht)).ToString());
                Zgjidhja += ((char)('a' + Nyja.Rresht)).ToString();
                
                Nyja = Nyja.Prindi;
            }
            Zgjidhjet.Add(Zgjidhja);
            TeGjithaZgjidhjet += Environment.NewLine;
        }
    }
}
