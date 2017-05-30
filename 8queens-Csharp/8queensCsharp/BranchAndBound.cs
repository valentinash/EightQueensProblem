using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    public class BranchAndBound
    {
        public static int NumriTentimeve, NumriNyjeve, NumriZgjidhjeve, NumriMbretereshave = 8;
        public static List <string> Zgjidhjet = new List<string>();
        public static string Zgjidhja = "";



        public BranchAndBound()
        {
            NumriZgjidhjeve = 0;
            NumriTentimeve = 0;    
        }

        //Metode per te llogaritur se a mund te pozicionohet mbreteresha ne poziten [rreshti,kolona]
        bool vendosjeSigurte(int rreshti, int kolona, int[,] diagonalja1,
                    int[,] backdiagonalja1, bool[] perplasjeRreshti,
                    bool[] perplasjeDiagonale1, bool[] backperplasjeDiagonale1 )
        {
            if (perplasjeDiagonale1[diagonalja1[rreshti,kolona]] ||
                backperplasjeDiagonale1[backdiagonalja1[rreshti,kolona]] ||
                perplasjeRreshti[rreshti])
                return false;

            return true;
        }

        //Metode rekursive e zgjidhjes se problemit te 8 mbretereshave
        bool zgjedh8Mbretereshat(int[,] tabela, int kolona,
            int[,] diagonalja1, int[,] diagonalja2, bool[] perplasjeRreshti,
            bool[] perplasjeDiagonale1, bool[] perplasjeDiagonale2 )
        {
            
            //Nese te gjitha mbretereshat jane pozicionuar, regjistroje zgjidhjen e gjetur
            if (kolona >= 8)
            {
                Zgjidhjet.Add(Zgjidhja);
                return true;
            }

            //Provojme te vendosim mbretereshen ne secilin rresht te kolones qe po shqyrtohet
            for (int i = 0; i < 8; i++)
            {
                NumriTentimeve++;
                //Kontrollojme a eshte e sigurte pozita aktuale
                if (vendosjeSigurte(i, kolona, diagonalja1, diagonalja2, perplasjeRreshti,
                            perplasjeDiagonale1, perplasjeDiagonale2))
                {
                    //Vendosim mbretereshen ne poziten e gjetur
                    perplasjeRreshti[i] = true;
                    perplasjeDiagonale1[diagonalja1[i, kolona]] = true;
                    perplasjeDiagonale2[diagonalja2[i, kolona]] = true;
                    Zgjidhja += (((char)('a' + i)).ToString());

                    //Me rekurence vendosim mbretereshat tjera
                    zgjedh8Mbretereshat(tabela, kolona + 1, diagonalja1, diagonalja2,
                            perplasjeRreshti, perplasjeDiagonale1, perplasjeDiagonale2);




                    //Nese pozita aktuale nuk na mundeson vendosjen e te gjitha mbretereshave,
                    //kthehemi nje hap prapa (backtrack hapi)

                       if(Zgjidhja.Length!=0)
                       Zgjidhja = Zgjidhja.Substring(0, Zgjidhja.Length - 1);
                       
                        perplasjeRreshti[i] = false;
                        perplasjeDiagonale1[diagonalja1[i, kolona]] = false;
                        perplasjeDiagonale2[diagonalja2[i, kolona]] = false;
                    
                }
            }
            return false;
        }
        public void zgjidh8Mbretereshat()
        {
            int[,] tabela=new int[8,8];

        //matricat ndihmese
        int[,] diagonalja1=new int[8,8];
        int[,] diagonalja2=new int[8,8];

            // vargu qe tregon cilet rreshta jane zene
            bool[] perplasjeRreshti = Enumerable.Repeat(false, 8).ToArray();

            //vargjet qe tregojne cilat diagonale jane te zena
            bool[] perplasjeDiagonale1 = Enumerable.Repeat(false,15).ToArray();
            
            bool[] perplasjeDiagonale2 = Enumerable.Repeat(false, 15).ToArray();


            //inicializojme matricat ndihmese
            for (int r = 0; r < 8; r++)
                for (int c = 0; c < 8; c++)
                {
                    diagonalja1[r, c] = r + c;
                    diagonalja2[r, c] = r - c + 7;
                }

            zgjedh8Mbretereshat(tabela, 0, diagonalja1,diagonalja2,
                  perplasjeRreshti, perplasjeDiagonale1, perplasjeDiagonale2);
            


        }
    }
}
