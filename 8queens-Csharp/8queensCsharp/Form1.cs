using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;
using System.IO;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace WindowsFormsApplication1
{

    public partial class Form1 : Form
    {
        //global counter of safe queens
        int NumriMbretereshave = 0;
      
        public Form1()
        {
            InitializeComponent();
        }

       
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Fshirja_e_Tabeles();
        }
        // Fshije te gjitha mbretereshat the fillo nje loje te re
        private void NewGame_Click(object sender, EventArgs e)
        {

            backgroundWorker3.RunWorkerAsync();

            MessageBox.Show("Loje e re /Vendosi cdo njeren prej 8 Mbretereshave (si p.sh. a4 ose g7) ne vend te sigurt");     //Loje e re

            // largoji Mbretereshat nga tabela e shahut
            Fshirja_e_Tabeles();

        }

        //backgroundWorker kodi per muzike lidhur me "smile", "frown" face dhe  startimin e nje loje te re
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

            SoundPlayer player = new SoundPlayer();
            player.SoundLocation = "c:\\windows\\media\\chimes.wav";
            player.Load();
            player.PlaySync();

        }
        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {

            SoundPlayer player = new SoundPlayer();
            player.SoundLocation = "c:\\windows\\media\\tada.wav";
            player.Load();
            player.PlaySync();
        }
        private void backgroundWorker3_DoWork(object sender, DoWorkEventArgs e)
        {

            SoundPlayer player = new SoundPlayer();
            player.SoundLocation = "c:\\windows\\media\\ringout.wav";
            player.Load();
            player.PlaySync();
        }

        //Funksioni per mesazhin urues
        void congrat(int NumriMbretereshave) { if (NumriMbretereshave == 8) MessageBox.Show("Urime! Te gjitha, 8 Mbretereshat jane te sigurta!"); }

        // Ky funksion llogarit posicionin e mbretereshave ne tabelen e shahut
        void PozicioniIMbretereshes(int qX_shift, int qY_shift, String[,] Tabela_Shahut)
        {
            for (int j = 1; j < 9; j++)
            {
                //horizontal fields "shot" by queens
                if (Tabela_Shahut[qX_shift, j] != "Q") Tabela_Shahut[qX_shift, j] = "q";

                //vertical fields "shot" by queens
                if (Tabela_Shahut[j, qY_shift] != "Q") Tabela_Shahut[j, qY_shift] = "q";
            }

            //Fushat diagonale te "shtena" nga mbretereshat (fushat ku mbreteresha e ardhshme nuk ben te vendoset)
            int X_ri = qX_shift;
            int Y_ri = qY_shift;

            while ((X_ri < 9) || (Y_ri < 9))
            {
                if ((X_ri == 8) || (Y_ri == 8)) break;
                X_ri = X_ri + 1;
                Y_ri = Y_ri + 1;
                if (Tabela_Shahut[X_ri, Y_ri] != "Q") Tabela_Shahut[X_ri, Y_ri] = "q";
                if ((X_ri == 8) || (Y_ri == 8)) break;
            }

            X_ri = qX_shift;
            Y_ri = qY_shift;
            while ((X_ri >= 1) || (Y_ri >= 1))
            {
                if ((X_ri == 1) || (Y_ri == 1)) break;
                X_ri = X_ri - 1;
                Y_ri = Y_ri - 1;

                if (Tabela_Shahut[X_ri, Y_ri] != "Q") Tabela_Shahut[X_ri, Y_ri] = "q";
                if ((X_ri == 1) || (Y_ri == 1)) break;
            };

            X_ri = qX_shift;
            Y_ri = qY_shift;
            while ((X_ri >= 1) || (Y_ri < 9))
            {
                if ((X_ri == 1) || (Y_ri == 8)) break;
                X_ri = X_ri - 1;
                Y_ri = Y_ri + 1;

                if (Tabela_Shahut[X_ri, Y_ri] != "Q") Tabela_Shahut[X_ri, Y_ri] = "q";
                if ((X_ri == 1) || (Y_ri == 8)) break;
            };

            X_ri = qX_shift;
            Y_ri = qY_shift;
            while ((X_ri < 9) || (Y_ri >= 1))
            {
                if ((X_ri == 8) || (Y_ri == 1)) break;
                X_ri = X_ri + 1;
                Y_ri = Y_ri - 1;

                if (Tabela_Shahut[X_ri, Y_ri] != "Q") Tabela_Shahut[X_ri, Y_ri] = "q";
                if ((X_ri == 8) || (Y_ri == 1)) break;
            };

            return;


        }


       
        private void clickButton(object sender, EventArgs e)
        {
            Button Butoni_i_Klikuar = (Button)sender;
            string pozicioni = Butoni_i_Klikuar.Name.Substring(3);
            Control Pozicioni_i_Mbretereshes=this.Controls.Find(pozicioni, true)[0];
            PictureBox Pozicioni_i_Klikuar = (PictureBox)Pozicioni_i_Mbretereshes;
            if (!Pozicioni_i_Klikuar.Visible)
            {
                if (NumriMbretereshave < 8)
                {
                    next.Visible = false;
                    NumriMbretereshave++;
                    Kontrollo_Mbretereshen(pozicioni);
                }
                else
                {
                    MessageBox.Show("Nuk mund të vendosen më shumë se 8 mbretëresha!");
                }
            }
            else
            {
                next.Visible = true;
                Pozicioni_i_Klikuar.Visible = false;
                NumriMbretereshave--;
            }
        }
      

        private void listZgjidhjet_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listZgjidhjet.SelectedIndex != -1)
            {
                Fshirja_e_Tabeles();
                char[] zgjidhja = listZgjidhjet.SelectedItem.ToString().ToCharArray();
                for(int i = zgjidhja.Length; i > 0; i--)
                {
                    Kontrollo_Mbretereshen(zgjidhja[i-1] + i.ToString());
                }

            }
        }

     

        private void Kontrollo_Mbretereshen(string position)
        {

            int qXshift, qYshift, VendiAktual_QX = 0, VendiAktual_QY = 0;


            //Vendosja e tabeles se Shahut ne nje array - perdoret per te i llogaritur Mbretereshat
            string[,] Tabela_e_Shahut = new string[10, 10];


            //Kopijimi i mbretereshave, pozicionet e tyre nga GUI tabela e shahut ne ne array-in e tabeles se shahut
            if (A1.Visible == true) Tabela_e_Shahut[1, 1] = "Q";
            if (A2.Visible == true) Tabela_e_Shahut[1, 2] = "Q";
            if (A3.Visible == true) Tabela_e_Shahut[1, 3] = "Q";
            if (A4.Visible == true) Tabela_e_Shahut[1, 4] = "Q";
            if (A5.Visible == true) Tabela_e_Shahut[1, 5] = "Q";
            if (A6.Visible == true) Tabela_e_Shahut[1, 6] = "Q";
            if (A7.Visible == true) Tabela_e_Shahut[1, 7] = "Q";
            if (A8.Visible == true) Tabela_e_Shahut[1, 8] = "Q";

            if (B1.Visible == true) Tabela_e_Shahut[2, 1] = "Q";
            if (B2.Visible == true) Tabela_e_Shahut[2, 2] = "Q";
            if (B3.Visible == true) Tabela_e_Shahut[2, 3] = "Q";
            if (B4.Visible == true) Tabela_e_Shahut[2, 4] = "Q";
            if (B5.Visible == true) Tabela_e_Shahut[2, 5] = "Q";
            if (B6.Visible == true) Tabela_e_Shahut[2, 6] = "Q";
            if (B7.Visible == true) Tabela_e_Shahut[2, 7] = "Q";
            if (B8.Visible == true) Tabela_e_Shahut[2, 8] = "Q";

            if (C1.Visible == true) Tabela_e_Shahut[3, 1] = "Q";
            if (C2.Visible == true) Tabela_e_Shahut[3, 2] = "Q";
            if (C3.Visible == true) Tabela_e_Shahut[3, 3] = "Q";
            if (C4.Visible == true) Tabela_e_Shahut[3, 4] = "Q";
            if (C5.Visible == true) Tabela_e_Shahut[3, 5] = "Q";
            if (C6.Visible == true) Tabela_e_Shahut[3, 6] = "Q";
            if (C7.Visible == true) Tabela_e_Shahut[3, 7] = "Q";
            if (C8.Visible == true) Tabela_e_Shahut[3, 8] = "Q";

            if (D1.Visible == true) Tabela_e_Shahut[4, 1] = "Q";
            if (D2.Visible == true) Tabela_e_Shahut[4, 2] = "Q";
            if (D3.Visible == true) Tabela_e_Shahut[4, 3] = "Q";
            if (D4.Visible == true) Tabela_e_Shahut[4, 4] = "Q";
            if (D5.Visible == true) Tabela_e_Shahut[4, 5] = "Q";
            if (D6.Visible == true) Tabela_e_Shahut[4, 6] = "Q";
            if (D7.Visible == true) Tabela_e_Shahut[4, 7] = "Q";
            if (D8.Visible == true) Tabela_e_Shahut[4, 8] = "Q";

            if (E1.Visible == true) Tabela_e_Shahut[5, 1] = "Q";
            if (E2.Visible == true) Tabela_e_Shahut[5, 2] = "Q";
            if (E3.Visible == true) Tabela_e_Shahut[5, 3] = "Q";
            if (E4.Visible == true) Tabela_e_Shahut[5, 4] = "Q";
            if (E5.Visible == true) Tabela_e_Shahut[5, 5] = "Q";
            if (E6.Visible == true) Tabela_e_Shahut[5, 6] = "Q";
            if (E7.Visible == true) Tabela_e_Shahut[5, 7] = "Q";
            if (E8.Visible == true) Tabela_e_Shahut[5, 8] = "Q";

            if (F1.Visible == true) Tabela_e_Shahut[6, 1] = "Q";
            if (F2.Visible == true) Tabela_e_Shahut[6, 2] = "Q";
            if (F3.Visible == true) Tabela_e_Shahut[6, 3] = "Q";
            if (F4.Visible == true) Tabela_e_Shahut[6, 4] = "Q";
            if (F5.Visible == true) Tabela_e_Shahut[6, 5] = "Q";
            if (F6.Visible == true) Tabela_e_Shahut[6, 6] = "Q";
            if (F7.Visible == true) Tabela_e_Shahut[6, 7] = "Q";
            if (F8.Visible == true) Tabela_e_Shahut[6, 8] = "Q";

            if (G1.Visible == true) Tabela_e_Shahut[7, 1] = "Q";
            if (G2.Visible == true) Tabela_e_Shahut[7, 2] = "Q";
            if (G3.Visible == true) Tabela_e_Shahut[7, 3] = "Q";
            if (G4.Visible == true) Tabela_e_Shahut[7, 4] = "Q";
            if (G5.Visible == true) Tabela_e_Shahut[7, 5] = "Q";
            if (G6.Visible == true) Tabela_e_Shahut[7, 6] = "Q";
            if (G7.Visible == true) Tabela_e_Shahut[7, 7] = "Q";
            if (G8.Visible == true) Tabela_e_Shahut[7, 8] = "Q";

            if (H1.Visible == true) Tabela_e_Shahut[8, 1] = "Q";
            if (H2.Visible == true) Tabela_e_Shahut[8, 2] = "Q";
            if (H3.Visible == true) Tabela_e_Shahut[8, 3] = "Q";
            if (H4.Visible == true) Tabela_e_Shahut[8, 4] = "Q";
            if (H5.Visible == true) Tabela_e_Shahut[8, 5] = "Q";
            if (H6.Visible == true) Tabela_e_Shahut[8, 6] = "Q";
            if (H7.Visible == true) Tabela_e_Shahut[8, 7] = "Q";
            if (H8.Visible == true) Tabela_e_Shahut[8, 8] = "Q";


            //caktimi i "q" ne fushat e tabeles se shahut te vendosura nga mbretereshat - nga vendosja e mbretereshes ne tabelen e shahut

            for (qXshift = 1; qXshift < 9; qXshift++)
            {
                for (qYshift = 1; qYshift < 9; qYshift++)
                {
                    if (Tabela_e_Shahut[qXshift, qYshift] == "Q") PozicioniIMbretereshes(qXshift, qYshift, Tabela_e_Shahut);
                }
            }

            //Pozicioni i Mbretereshes e dhene nga hyrja permes GUI
            String Mbreteresha_Hyrese = position.ToUpper();

            //making queens' pictures visible
            if (A1.Name == Mbreteresha_Hyrese) A1.Visible = true;
            else if (A2.Name == Mbreteresha_Hyrese) A2.Visible = true;
            else if (A3.Name == Mbreteresha_Hyrese) A3.Visible = true;
            else if (A4.Name == Mbreteresha_Hyrese) A4.Visible = true;
            else if (A5.Name == Mbreteresha_Hyrese) A5.Visible = true;
            else if (A6.Name == Mbreteresha_Hyrese) A6.Visible = true;
            else if (A7.Name == Mbreteresha_Hyrese) A7.Visible = true;
            else if (A8.Name == Mbreteresha_Hyrese) A8.Visible = true;
            else if (B1.Name == Mbreteresha_Hyrese) B1.Visible = true;
            else if (B2.Name == Mbreteresha_Hyrese) B2.Visible = true;
            else if (B3.Name == Mbreteresha_Hyrese) B3.Visible = true;
            else if (B4.Name == Mbreteresha_Hyrese) B4.Visible = true;
            else if (B5.Name == Mbreteresha_Hyrese) B5.Visible = true;
            else if (B6.Name == Mbreteresha_Hyrese) B6.Visible = true;
            else if (B7.Name == Mbreteresha_Hyrese) B7.Visible = true;
            else if (B8.Name == Mbreteresha_Hyrese) B8.Visible = true;
            else if (C1.Name == Mbreteresha_Hyrese) C1.Visible = true;
            else if (C2.Name == Mbreteresha_Hyrese) C2.Visible = true;
            else if (C3.Name == Mbreteresha_Hyrese) C3.Visible = true;
            else if (C4.Name == Mbreteresha_Hyrese) C4.Visible = true;
            else if (C5.Name == Mbreteresha_Hyrese) C5.Visible = true;
            else if (C6.Name == Mbreteresha_Hyrese) C6.Visible = true;
            else if (C7.Name == Mbreteresha_Hyrese) C7.Visible = true;
            else if (C8.Name == Mbreteresha_Hyrese) C8.Visible = true;
            else if (D1.Name == Mbreteresha_Hyrese) D1.Visible = true;
            else if (D2.Name == Mbreteresha_Hyrese) D2.Visible = true;
            else if (D3.Name == Mbreteresha_Hyrese) D3.Visible = true;
            else if (D4.Name == Mbreteresha_Hyrese) D4.Visible = true;
            else if (D5.Name == Mbreteresha_Hyrese) D5.Visible = true;
            else if (D6.Name == Mbreteresha_Hyrese) D6.Visible = true;
            else if (D7.Name == Mbreteresha_Hyrese) D7.Visible = true;
            else if (D8.Name == Mbreteresha_Hyrese) D8.Visible = true;
            else if (E1.Name == Mbreteresha_Hyrese) E1.Visible = true;
            else if (E2.Name == Mbreteresha_Hyrese) E2.Visible = true;
            else if (E3.Name == Mbreteresha_Hyrese) E3.Visible = true;
            else if (E4.Name == Mbreteresha_Hyrese) E4.Visible = true;
            else if (E5.Name == Mbreteresha_Hyrese) E5.Visible = true;
            else if (E6.Name == Mbreteresha_Hyrese) E6.Visible = true;
            else if (E7.Name == Mbreteresha_Hyrese) E7.Visible = true;
            else if (E8.Name == Mbreteresha_Hyrese) E8.Visible = true;
            else if (F1.Name == Mbreteresha_Hyrese) F1.Visible = true;
            else if (F2.Name == Mbreteresha_Hyrese) F2.Visible = true;
            else if (F3.Name == Mbreteresha_Hyrese) F3.Visible = true;
            else if (F4.Name == Mbreteresha_Hyrese) F4.Visible = true;
            else if (F5.Name == Mbreteresha_Hyrese) F5.Visible = true;
            else if (F6.Name == Mbreteresha_Hyrese) F6.Visible = true;
            else if (F7.Name == Mbreteresha_Hyrese) F7.Visible = true;
            else if (F8.Name == Mbreteresha_Hyrese) F8.Visible = true;
            else if (G1.Name == Mbreteresha_Hyrese) G1.Visible = true;
            else if (G2.Name == Mbreteresha_Hyrese) G2.Visible = true;
            else if (G3.Name == Mbreteresha_Hyrese) G3.Visible = true;
            else if (G4.Name == Mbreteresha_Hyrese) G4.Visible = true;
            else if (G5.Name == Mbreteresha_Hyrese) G5.Visible = true;
            else if (G6.Name == Mbreteresha_Hyrese) G6.Visible = true;
            else if (G7.Name == Mbreteresha_Hyrese) G7.Visible = true;
            else if (G8.Name == Mbreteresha_Hyrese) G8.Visible = true;
            else if (H1.Name == Mbreteresha_Hyrese) H1.Visible = true;
            else if (H2.Name == Mbreteresha_Hyrese) H2.Visible = true;
            else if (H3.Name == Mbreteresha_Hyrese) H3.Visible = true;
            else if (H4.Name == Mbreteresha_Hyrese) H4.Visible = true;
            else if (H5.Name == Mbreteresha_Hyrese) H5.Visible = true;
            else if (H6.Name == Mbreteresha_Hyrese) H6.Visible = true;
            else if (H7.Name == Mbreteresha_Hyrese) H7.Visible = true;
            else if (H8.Name == Mbreteresha_Hyrese) H8.Visible = true;
            else { MessageBox.Show("HYRJA PRANOHET VETEM EN RANGUN A1....H8"); goto next; }


            //Konvertimi i koordinates aktuale te Mbretereshes ne string to int

            if (Mbreteresha_Hyrese.Substring(0, 1) == "A") VendiAktual_QX = 1;
            if (Mbreteresha_Hyrese.Substring(0, 1) == "B") VendiAktual_QX = 2;
            if (Mbreteresha_Hyrese.Substring(0, 1) == "C") VendiAktual_QX = 3;
            if (Mbreteresha_Hyrese.Substring(0, 1) == "D") VendiAktual_QX = 4;
            if (Mbreteresha_Hyrese.Substring(0, 1) == "E") VendiAktual_QX = 5;
            if (Mbreteresha_Hyrese.Substring(0, 1) == "F") VendiAktual_QX = 6;
            if (Mbreteresha_Hyrese.Substring(0, 1) == "G") VendiAktual_QX = 7;
            if (Mbreteresha_Hyrese.Substring(0, 1) == "H") VendiAktual_QX = 8;

            if (Mbreteresha_Hyrese.Substring(1, 1) == "1") VendiAktual_QY = 1;
            if (Mbreteresha_Hyrese.Substring(1, 1) == "2") VendiAktual_QY = 2;
            if (Mbreteresha_Hyrese.Substring(1, 1) == "3") VendiAktual_QY = 3;
            if (Mbreteresha_Hyrese.Substring(1, 1) == "4") VendiAktual_QY = 4;
            if (Mbreteresha_Hyrese.Substring(1, 1) == "5") VendiAktual_QY = 5;
            if (Mbreteresha_Hyrese.Substring(1, 1) == "6") VendiAktual_QY = 6;
            if (Mbreteresha_Hyrese.Substring(1, 1) == "7") VendiAktual_QY = 7;
            if (Mbreteresha_Hyrese.Substring(1, 1) == "8") VendiAktual_QY = 8;



            //Vendosja e fytyres "frown" nese Mbreteresha eshte ne pozicion te gabuar ose te fytyres "smile" nese Mbreteresha eshte ne pozicion te duhur
            if (Tabela_e_Shahut[VendiAktual_QX, VendiAktual_QY] == "q" || Tabela_e_Shahut[VendiAktual_QX, VendiAktual_QY] == "Q")
            {
                smile.Visible = false;
                frown.Visible = true;
                //backgroundWorker1.RunWorkerAsync();
            }
            else
            {
                smile.Visible = true;
                frown.Visible = false;
               // backgroundWorker2.RunWorkerAsync();
                congrat(NumriMbretereshave);
            }



        next:;
        }
        private void Fshirja_e_Tabeles()
        {
            // largoji mbretereshat ne tabelea e shahut
            A1.Visible = false;     // largoji mbretereshat ne tabelea e shahut
            A2.Visible = false;     // largoji mbretereshat ne tabelea e shahut
            A3.Visible = false;     // largoji mbretereshat ne tabelea e shahut
            A4.Visible = false;     // largoji mbretereshat ne tabelea e shahut
            A5.Visible = false;     // largoji mbretereshat ne tabelea e shahut
            A6.Visible = false;     // largoji mbretereshat ne tabelea e shahut
            A7.Visible = false;     // largoji mbretereshat ne tabelea e shahut
            A8.Visible = false;     // largoji mbretereshat ne tabelea e shahut
            
            B1.Visible = false;     // largoji mbretereshat ne tabelea e shahut
            B2.Visible = false;     // largoji mbretereshat ne tabelea e shahut
            B3.Visible = false;     // largoji mbretereshat ne tabelea e shahut
            B4.Visible = false;     // largoji mbretereshat ne tabelea e shahut
            B5.Visible = false;     // largoji mbretereshat ne tabelea e shahut
            B6.Visible = false;     // largoji mbretereshat ne tabelea e shahut
            B7.Visible = false;     // largoji mbretereshat ne tabelea e shahut
            B8.Visible = false;     // largoji mbretereshat ne tabelea e shahut
            
            C1.Visible = false;     // largoji mbretereshat ne tabelea e shahut
            C2.Visible = false;     // largoji mbretereshat ne tabelea e shahut
            C3.Visible = false;     // largoji mbretereshat ne tabelea e shahut
            C4.Visible = false;     // largoji mbretereshat ne tabelea e shahut
            C5.Visible = false;     // largoji mbretereshat ne tabelea e shahut
            C6.Visible = false;     // largoji mbretereshat ne tabelea e shahut
            C7.Visible = false;     // largoji mbretereshat ne tabelea e shahut
            C8.Visible = false;     // largoji mbretereshat ne tabelea e shahut
            
            D1.Visible = false;     // largoji mbretereshat ne tabelea e shahut
            D2.Visible = false;     // largoji mbretereshat ne tabelea e shahut
            D3.Visible = false;     // largoji mbretereshat ne tabelea e shahut
            D4.Visible = false;     // largoji mbretereshat ne tabelea e shahut
            D5.Visible = false;     // largoji mbretereshat ne tabelea e shahut
            D6.Visible = false;     // largoji mbretereshat ne tabelea e shahut
            D7.Visible = false;     // largoji mbretereshat ne tabelea e shahut
            D8.Visible = false;     // largoji mbretereshat ne tabelea e shahut
            
            E1.Visible = false;     // largoji mbretereshat ne tabelea e shahut
            E2.Visible = false;     // largoji mbretereshat ne tabelea e shahut
            E3.Visible = false;     // largoji mbretereshat ne tabelea e shahut
            E4.Visible = false;     // largoji mbretereshat ne tabelea e shahut
            E5.Visible = false;     // largoji mbretereshat ne tabelea e shahut
            E6.Visible = false;     // largoji mbretereshat ne tabelea e shahut
            E7.Visible = false;     // largoji mbretereshat ne tabelea e shahut
            E8.Visible = false;     // largoji mbretereshat ne tabelea e shahut
            
            F1.Visible = false;     // largoji mbretereshat ne tabelea e shahut
            F2.Visible = false;     // largoji mbretereshat ne tabelea e shahut
            F3.Visible = false;     // largoji mbretereshat ne tabelea e shahut
            F4.Visible = false;     // largoji mbretereshat ne tabelea e shahut
            F5.Visible = false;     // largoji mbretereshat ne tabelea e shahut
            F6.Visible = false;     // largoji mbretereshat ne tabelea e shahut
            F7.Visible = false;     // largoji mbretereshat ne tabelea e shahut
            F8.Visible = false;     // largoji mbretereshat ne tabelea e shahut
            
            G1.Visible = false;     // largoji mbretereshat ne tabelea e shahut
            G2.Visible = false;     // largoji mbretereshat ne tabelea e shahut
            G3.Visible = false;     // largoji mbretereshat ne tabelea e shahut
            G4.Visible = false;     // largoji mbretereshat ne tabelea e shahut
            G5.Visible = false;     // largoji mbretereshat ne tabelea e shahut
            G6.Visible = false;     // largoji mbretereshat ne tabelea e shahut
            G7.Visible = false;     // largoji mbretereshat ne tabelea e shahut
            G8.Visible = false;     // largoji mbretereshat ne tabelea e shahut

            H1.Visible = false;     // largoji mbretereshat ne tabelea e shahut
            H2.Visible = false;     // largoji mbretereshat ne tabelea e shahut
            H3.Visible = false;     // largoji mbretereshat ne tabelea e shahut
            H4.Visible = false;     // largoji mbretereshat ne tabelea e shahut
            H5.Visible = false;     // largoji mbretereshat ne tabelea e shahut
            H6.Visible = false;     // largoji mbretereshat ne tabelea e shahut
            H7.Visible = false;     // largoji mbretereshat ne tabelea e shahut
            H8.Visible = false;     // largoji mbretereshat ne tabelea e shahut

            smile.Visible = false;      // largoje "smile" face
            frown.Visible = false;      // largoje "frown" face
            next.Visible = true;

            NumriMbretereshave = 0;      //Ktheje numri e Mbretereshave ne tabelen e shahut ne 0
        }

        private void btnTreeAlgorithm_Click(object sender, EventArgs e)
        {
            string userName = Environment.UserName;
            
            // Kodi qe deshironi per ta matur vjen ketu

            new Position(0, -1, null).EcniNeperPeme();
            for(int i = 0; i < Position.Zgjidhjet.Count; i++)
            {

                listZgjidhjet.Items.Add(Position.Zgjidhjet[i].ToUpper());
            }
            label5.Text= Position.NumriTentimeve.ToString("#,##0");
            label6.Text = Position.NumriZgjidhjeve.ToString("#,##0");
           

        }
    }
}      
