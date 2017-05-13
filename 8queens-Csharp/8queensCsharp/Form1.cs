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
        int numberOfQueens = 0;
      
   
      


        public Form1()
        {
            InitializeComponent();
        }

       
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            clearBoard();
        }
        // set up for New Game
        private void NewGame_Click(object sender, EventArgs e)
        {

            backgroundWorker3.RunWorkerAsync();
            // New Game dialogue


            MessageBox.Show("New Game /Put each of 8 queens (like a4 or g7) to safe place");        // New Game dialogue

            // remove queens from chessboard
            clearBoard();

        }

        //backgroundWorker code for sound accompanying "smile", "frown" and new game start
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

        //Congratulation message function
        void congrat(int QueenNumber) { if (QueenNumber == 8) MessageBox.Show(" Congratulations! All 8 queens are safe"); }

        // this function evaluates queens' positions on chessboard 
        void queenposition(int qX_shift, int qY_shift, String[,] Chess_Board)
        {
            for (int j = 1; j < 9; j++)
            {
                //horizontal fields "shot" by queens
                if (Chess_Board[qX_shift, j] != "Q") Chess_Board[qX_shift, j] = "q";

                //vertical fields "shot" by queens
                if (Chess_Board[j, qY_shift] != "Q") Chess_Board[j, qY_shift] = "q";
            }

            //diagonal fields "shot" by queens
            int xnew = qX_shift;
            int ynew = qY_shift;

            while ((xnew < 9) || (ynew < 9))
            {
                if ((xnew == 8) || (ynew == 8)) break;
                xnew = xnew + 1;
                ynew = ynew + 1;
                if (Chess_Board[xnew, ynew] != "Q") Chess_Board[xnew, ynew] = "q";
                if ((xnew == 8) || (ynew == 8)) break;
            }

            xnew = qX_shift;
            ynew = qY_shift;
            while ((xnew >= 1) || (ynew >= 1))
            {
                if ((xnew == 1) || (ynew == 1)) break;
                xnew = xnew - 1;
                ynew = ynew - 1;

                if (Chess_Board[xnew, ynew] != "Q") Chess_Board[xnew, ynew] = "q";
                if ((xnew == 1) || (ynew == 1)) break;
            };

            xnew = qX_shift;
            ynew = qY_shift;
            while ((xnew >= 1) || (ynew < 9))
            {
                if ((xnew == 1) || (ynew == 8)) break;
                xnew = xnew - 1;
                ynew = ynew + 1;

                if (Chess_Board[xnew, ynew] != "Q") Chess_Board[xnew, ynew] = "q";
                if ((xnew == 1) || (ynew == 8)) break;
            };

            xnew = qX_shift;
            ynew = qY_shift;
            while ((xnew < 9) || (ynew >= 1))
            {
                if ((xnew == 8) || (ynew == 1)) break;
                xnew = xnew + 1;
                ynew = ynew - 1;

                if (Chess_Board[xnew, ynew] != "Q") Chess_Board[xnew, ynew] = "q";
                if ((xnew == 8) || (ynew == 1)) break;
            };

            return;


        }


       
        private void clickButton(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            string position = clickedButton.Name.Substring(3);
            Control qPosition=this.Controls.Find(position, true)[0];
            PictureBox positionClicked = (PictureBox)qPosition;
            if (!positionClicked.Visible)
            {
                if (numberOfQueens < 8)
                {
                    next.Visible = false;
                    numberOfQueens++;
                    checkQueen(position);
                }
                else
                {
                    MessageBox.Show("Nuk mund të vendosen më shumë se 8 mbretëresha!");
                }
            }
            else
            {
                next.Visible = true;
                positionClicked.Visible = false;
                numberOfQueens--;
            }
        }
      

        private void listZgjidhjet_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listZgjidhjet.SelectedIndex != -1)
            {
                clearBoard();
                char[] zgjidhja = listZgjidhjet.SelectedItem.ToString().ToCharArray();
                for(int i = zgjidhja.Length; i > 0; i--)
                {
                    checkQueen(zgjidhja[i-1] + i.ToString());
                }

            }
        }

     

        private void checkQueen(string position)
        {

            int qXshift, qYshift, CurrentQX = 0, CurrentQY = 0;


            //set up ChessBoard array - used to calculate queens' "star" positions
            string[,] ChessBoard = new string[10, 10];


            //copying queens' star positions from GUI chessboard to ChessBoard array
            if (A1.Visible == true) ChessBoard[1, 1] = "Q";
            if (A2.Visible == true) ChessBoard[1, 2] = "Q";
            if (A3.Visible == true) ChessBoard[1, 3] = "Q";
            if (A4.Visible == true) ChessBoard[1, 4] = "Q";
            if (A5.Visible == true) ChessBoard[1, 5] = "Q";
            if (A6.Visible == true) ChessBoard[1, 6] = "Q";
            if (A7.Visible == true) ChessBoard[1, 7] = "Q";
            if (A8.Visible == true) ChessBoard[1, 8] = "Q";

            if (B1.Visible == true) ChessBoard[2, 1] = "Q";
            if (B2.Visible == true) ChessBoard[2, 2] = "Q";
            if (B3.Visible == true) ChessBoard[2, 3] = "Q";
            if (B4.Visible == true) ChessBoard[2, 4] = "Q";
            if (B5.Visible == true) ChessBoard[2, 5] = "Q";
            if (B6.Visible == true) ChessBoard[2, 6] = "Q";
            if (B7.Visible == true) ChessBoard[2, 7] = "Q";
            if (B8.Visible == true) ChessBoard[2, 8] = "Q";

            if (C1.Visible == true) ChessBoard[3, 1] = "Q";
            if (C2.Visible == true) ChessBoard[3, 2] = "Q";
            if (C3.Visible == true) ChessBoard[3, 3] = "Q";
            if (C4.Visible == true) ChessBoard[3, 4] = "Q";
            if (C5.Visible == true) ChessBoard[3, 5] = "Q";
            if (C6.Visible == true) ChessBoard[3, 6] = "Q";
            if (C7.Visible == true) ChessBoard[3, 7] = "Q";
            if (C8.Visible == true) ChessBoard[3, 8] = "Q";

            if (D1.Visible == true) ChessBoard[4, 1] = "Q";
            if (D2.Visible == true) ChessBoard[4, 2] = "Q";
            if (D3.Visible == true) ChessBoard[4, 3] = "Q";
            if (D4.Visible == true) ChessBoard[4, 4] = "Q";
            if (D5.Visible == true) ChessBoard[4, 5] = "Q";
            if (D6.Visible == true) ChessBoard[4, 6] = "Q";
            if (D7.Visible == true) ChessBoard[4, 7] = "Q";
            if (D8.Visible == true) ChessBoard[4, 8] = "Q";

            if (E1.Visible == true) ChessBoard[5, 1] = "Q";
            if (E2.Visible == true) ChessBoard[5, 2] = "Q";
            if (E3.Visible == true) ChessBoard[5, 3] = "Q";
            if (E4.Visible == true) ChessBoard[5, 4] = "Q";
            if (E5.Visible == true) ChessBoard[5, 5] = "Q";
            if (E6.Visible == true) ChessBoard[5, 6] = "Q";
            if (E7.Visible == true) ChessBoard[5, 7] = "Q";
            if (E8.Visible == true) ChessBoard[5, 8] = "Q";

            if (F1.Visible == true) ChessBoard[6, 1] = "Q";
            if (F2.Visible == true) ChessBoard[6, 2] = "Q";
            if (F3.Visible == true) ChessBoard[6, 3] = "Q";
            if (F4.Visible == true) ChessBoard[6, 4] = "Q";
            if (F5.Visible == true) ChessBoard[6, 5] = "Q";
            if (F6.Visible == true) ChessBoard[6, 6] = "Q";
            if (F7.Visible == true) ChessBoard[6, 7] = "Q";
            if (F8.Visible == true) ChessBoard[6, 8] = "Q";

            if (G1.Visible == true) ChessBoard[7, 1] = "Q";
            if (G2.Visible == true) ChessBoard[7, 2] = "Q";
            if (G3.Visible == true) ChessBoard[7, 3] = "Q";
            if (G4.Visible == true) ChessBoard[7, 4] = "Q";
            if (G5.Visible == true) ChessBoard[7, 5] = "Q";
            if (G6.Visible == true) ChessBoard[7, 6] = "Q";
            if (G7.Visible == true) ChessBoard[7, 7] = "Q";
            if (G8.Visible == true) ChessBoard[7, 8] = "Q";

            if (H1.Visible == true) ChessBoard[8, 1] = "Q";
            if (H2.Visible == true) ChessBoard[8, 2] = "Q";
            if (H3.Visible == true) ChessBoard[8, 3] = "Q";
            if (H4.Visible == true) ChessBoard[8, 4] = "Q";
            if (H5.Visible == true) ChessBoard[8, 5] = "Q";
            if (H6.Visible == true) ChessBoard[8, 6] = "Q";
            if (H7.Visible == true) ChessBoard[8, 7] = "Q";
            if (H8.Visible == true) ChessBoard[8, 8] = "Q";


            // assinment of "q" to ChessBoard fields fired by queens - queen's "stars"

            for (qXshift = 1; qXshift < 9; qXshift++)
            {
                for (qYshift = 1; qYshift < 9; qYshift++)
                {
                    if (ChessBoard[qXshift, qYshift] == "Q") queenposition(qXshift, qYshift, ChessBoard);
                }
            }

            //queen position input through GUI
            String QUEENinput = position.ToUpper();

            //making queens' pictures visible
            if (A1.Name == QUEENinput) A1.Visible = true;
            else if (A2.Name == QUEENinput) A2.Visible = true;
            else if (A3.Name == QUEENinput) A3.Visible = true;
            else if (A4.Name == QUEENinput) A4.Visible = true;
            else if (A5.Name == QUEENinput) A5.Visible = true;
            else if (A6.Name == QUEENinput) A6.Visible = true;
            else if (A7.Name == QUEENinput) A7.Visible = true;
            else if (A8.Name == QUEENinput) A8.Visible = true;
            else if (B1.Name == QUEENinput) B1.Visible = true;
            else if (B2.Name == QUEENinput) B2.Visible = true;
            else if (B3.Name == QUEENinput) B3.Visible = true;
            else if (B4.Name == QUEENinput) B4.Visible = true;
            else if (B5.Name == QUEENinput) B5.Visible = true;
            else if (B6.Name == QUEENinput) B6.Visible = true;
            else if (B7.Name == QUEENinput) B7.Visible = true;
            else if (B8.Name == QUEENinput) B8.Visible = true;
            else if (C1.Name == QUEENinput) C1.Visible = true;
            else if (C2.Name == QUEENinput) C2.Visible = true;
            else if (C3.Name == QUEENinput) C3.Visible = true;
            else if (C4.Name == QUEENinput) C4.Visible = true;
            else if (C5.Name == QUEENinput) C5.Visible = true;
            else if (C6.Name == QUEENinput) C6.Visible = true;
            else if (C7.Name == QUEENinput) C7.Visible = true;
            else if (C8.Name == QUEENinput) C8.Visible = true;
            else if (D1.Name == QUEENinput) D1.Visible = true;
            else if (D2.Name == QUEENinput) D2.Visible = true;
            else if (D3.Name == QUEENinput) D3.Visible = true;
            else if (D4.Name == QUEENinput) D4.Visible = true;
            else if (D5.Name == QUEENinput) D5.Visible = true;
            else if (D6.Name == QUEENinput) D6.Visible = true;
            else if (D7.Name == QUEENinput) D7.Visible = true;
            else if (D8.Name == QUEENinput) D8.Visible = true;
            else if (E1.Name == QUEENinput) E1.Visible = true;
            else if (E2.Name == QUEENinput) E2.Visible = true;
            else if (E3.Name == QUEENinput) E3.Visible = true;
            else if (E4.Name == QUEENinput) E4.Visible = true;
            else if (E5.Name == QUEENinput) E5.Visible = true;
            else if (E6.Name == QUEENinput) E6.Visible = true;
            else if (E7.Name == QUEENinput) E7.Visible = true;
            else if (E8.Name == QUEENinput) E8.Visible = true;
            else if (F1.Name == QUEENinput) F1.Visible = true;
            else if (F2.Name == QUEENinput) F2.Visible = true;
            else if (F3.Name == QUEENinput) F3.Visible = true;
            else if (F4.Name == QUEENinput) F4.Visible = true;
            else if (F5.Name == QUEENinput) F5.Visible = true;
            else if (F6.Name == QUEENinput) F6.Visible = true;
            else if (F7.Name == QUEENinput) F7.Visible = true;
            else if (F8.Name == QUEENinput) F8.Visible = true;
            else if (G1.Name == QUEENinput) G1.Visible = true;
            else if (G2.Name == QUEENinput) G2.Visible = true;
            else if (G3.Name == QUEENinput) G3.Visible = true;
            else if (G4.Name == QUEENinput) G4.Visible = true;
            else if (G5.Name == QUEENinput) G5.Visible = true;
            else if (G6.Name == QUEENinput) G6.Visible = true;
            else if (G7.Name == QUEENinput) G7.Visible = true;
            else if (G8.Name == QUEENinput) G8.Visible = true;
            else if (H1.Name == QUEENinput) H1.Visible = true;
            else if (H2.Name == QUEENinput) H2.Visible = true;
            else if (H3.Name == QUEENinput) H3.Visible = true;
            else if (H4.Name == QUEENinput) H4.Visible = true;
            else if (H5.Name == QUEENinput) H5.Visible = true;
            else if (H6.Name == QUEENinput) H6.Visible = true;
            else if (H7.Name == QUEENinput) H7.Visible = true;
            else if (H8.Name == QUEENinput) H8.Visible = true;
            else { MessageBox.Show("INPUT ACCEPTABILE RANGE is A1....H8"); goto next; }


            //conversion of current queen coordinates string^ to int

            if (QUEENinput.Substring(0, 1) == "A") CurrentQX = 1;
            if (QUEENinput.Substring(0, 1) == "B") CurrentQX = 2;
            if (QUEENinput.Substring(0, 1) == "C") CurrentQX = 3;
            if (QUEENinput.Substring(0, 1) == "D") CurrentQX = 4;
            if (QUEENinput.Substring(0, 1) == "E") CurrentQX = 5;
            if (QUEENinput.Substring(0, 1) == "F") CurrentQX = 6;
            if (QUEENinput.Substring(0, 1) == "G") CurrentQX = 7;
            if (QUEENinput.Substring(0, 1) == "H") CurrentQX = 8;

            if (QUEENinput.Substring(1, 1) == "1") CurrentQY = 1;
            if (QUEENinput.Substring(1, 1) == "2") CurrentQY = 2;
            if (QUEENinput.Substring(1, 1) == "3") CurrentQY = 3;
            if (QUEENinput.Substring(1, 1) == "4") CurrentQY = 4;
            if (QUEENinput.Substring(1, 1) == "5") CurrentQY = 5;
            if (QUEENinput.Substring(1, 1) == "6") CurrentQY = 6;
            if (QUEENinput.Substring(1, 1) == "7") CurrentQY = 7;
            if (QUEENinput.Substring(1, 1) == "8") CurrentQY = 8;



            //making "frown" if queen's position is bad or "smile" if  queen's position is good
            if (ChessBoard[CurrentQX, CurrentQY] == "q" || ChessBoard[CurrentQX, CurrentQY] == "Q")
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
                congrat(numberOfQueens);
            }



        next:;
        }
        private void clearBoard()
        {
            // remove queens from chessboard
            A1.Visible = false;     // remove queens from chessboard
            A2.Visible = false;     // remove queens from chessboard
            A3.Visible = false;     // remove queens from chessboard
            A4.Visible = false;     // remove queens from chessboard
            A5.Visible = false;     // remove queens from chessboard
            A6.Visible = false;     // remove queens from chessboard
            A7.Visible = false;     // remove queens from chessboard
            A8.Visible = false;     // remove queens from chessboard
                                    // remove queens from chessboard
            B1.Visible = false;     // remove queens from chessboard
            B2.Visible = false;     // remove queens from chessboard
            B3.Visible = false;     // remove queens from chessboard
            B4.Visible = false;     // remove queens from chessboard
            B5.Visible = false;     // remove queens from chessboard
            B6.Visible = false;     // remove queens from chessboard
            B7.Visible = false;     // remove queens from chessboard
            B8.Visible = false;     // remove queens from chessboard
                                    // remove queens from chessboard
            C1.Visible = false;     // remove queens from chessboard
            C2.Visible = false;     // remove queens from chessboard
            C3.Visible = false;     // remove queens from chessboard
            C4.Visible = false;     // remove queens from chessboard
            C5.Visible = false;     // remove queens from chessboard
            C6.Visible = false;     // remove queens from chessboard
            C7.Visible = false;     // remove queens from chessboard
            C8.Visible = false;     // remove queens from chessboard
                                    // remove queens from chessboard
            D1.Visible = false;     // remove queens from chessboard
            D2.Visible = false;     // remove queens from chessboard
            D3.Visible = false;     // remove queens from chessboard
            D4.Visible = false;     // remove queens from chessboard
            D5.Visible = false;     // remove queens from chessboard
            D6.Visible = false;     // remove queens from chessboard
            D7.Visible = false;     // remove queens from chessboard
            D8.Visible = false;     // remove queens from chessboard
                                    // remove queens from chessboard
            E1.Visible = false;     // remove queens from chessboard
            E2.Visible = false;     // remove queens from chessboard
            E3.Visible = false;     // remove queens from chessboard
            E4.Visible = false;     // remove queens from chessboard
            E5.Visible = false;     // remove queens from chessboard
            E6.Visible = false;     // remove queens from chessboard
            E7.Visible = false;     // remove queens from chessboard
            E8.Visible = false;     // remove queens from chessboard
                                    // remove queens from chessboard
            F1.Visible = false;     // remove queens from chessboard
            F2.Visible = false;     // remove queens from chessboard
            F3.Visible = false;     // remove queens from chessboard
            F4.Visible = false;     // remove queens from chessboard
            F5.Visible = false;     // remove queens from chessboard
            F6.Visible = false;     // remove queens from chessboard
            F7.Visible = false;     // remove queens from chessboard
            F8.Visible = false;     // remove queens from chessboard
                                    // remove queens from chessboard
            G1.Visible = false;     // remove queens from chessboard
            G2.Visible = false;     // remove queens from chessboard
            G3.Visible = false;     // remove queens from chessboard
            G4.Visible = false;     // remove queens from chessboard
            G5.Visible = false;     // remove queens from chessboard
            G6.Visible = false;     // remove queens from chessboard
            G7.Visible = false;     // remove queens from chessboard
            G8.Visible = false;     // remove queens from chessboard
                                    // remove queens from chessboard
            H1.Visible = false;     // remove queens from chessboard
            H2.Visible = false;     // remove queens from chessboard
            H3.Visible = false;     // remove queens from chessboard
            H4.Visible = false;     // remove queens from chessboard
            H5.Visible = false;     // remove queens from chessboard
            H6.Visible = false;     // remove queens from chessboard
            H7.Visible = false;     // remove queens from chessboard
            H8.Visible = false;     // remove queens from chessboard

            smile.Visible = false;      // remove smile
            frown.Visible = false;      // remove frown
            next.Visible = true;

            numberOfQueens = 0;      //remove safe queens

        }

        private void btnTreeAlgorithm_Click(object sender, EventArgs e)
        {
            string userName = Environment.UserName;
            
            // the code that you want to measure comes here

            new Position(0, -1, null).WalkThroughTree();
            for(int i = 0; i < Position.Solutions.Count; i++)
            {

                listZgjidhjet.Items.Add(Position.Solutions[i].ToUpper());
            }
            label5.Text= Position.NumberOfAttempts.ToString("#,##0");
            label6.Text = Position.NumberOfSolutions.ToString("#,##0");
           

        }
    }
}      
