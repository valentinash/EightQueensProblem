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
        int A1int = 0, A2int = 0, A3int = 0, A4int = 0, A5int = 0, A6int = 0, A7int = 0, A8int = 0;
        int B1int = 0, B2int = 0, B3int = 0, B4int = 0, B5int = 0, B6int = 0, B7int = 0, B8int = 0;
        int C1int = 0, C2int = 0, C3int = 0, C4int = 0, C5int = 0, C6int = 0, C7int = 0, C8int = 0;
        int D1int = 0, D2int = 0, D3int = 0, D4int = 0, D5int = 0, D6int = 0, D7int = 0, D8int = 0;
        int E1int = 0, E2int = 0, E3int = 0, E4int = 0, E5int = 0, E6int = 0, E7int = 0, E8int = 0;
        int F1int = 0, F2int = 0, F3int = 0, F4int = 0, F5int = 0, F6int = 0, F7int = 0, F8int = 0;
        int G1int = 0, G2int = 0, G3int = 0, G4int = 0, G5int = 0, G6int = 0, G7int = 0, G8int = 0;
        int H1int = 0, H2int = 0, H3int = 0, H4int = 0, H5int = 0, H6int = 0, H7int = 0, H8int = 0;




        public Form1()
        {
            InitializeComponent();
        }


        private void EnterQueen_Click(object sender, EventArgs e)
        {
            FindQueens();
            FindQueensMarcus();
        }

        static void FindQueensMarcus()
        {
            var finder = new checkCorrect();
            finder.Find();
        }
        static void FindQueens()
        {
            string userName = Environment.UserName;
            Stopwatch sw = Stopwatch.StartNew();
            // the code that you want to measure comes here

            Func<int[], string> getA1addresses = columnList => string.Concat(columnList.Select((col, i) => " " + (char)('a' + col) + (i + 1)));
            List<int[]> columnLists = Find8Queens.FindAll();
            string s = string.Join("\n", columnLists.Select(getA1addresses));

            var input = s;
            var regex = new Regex(@".{24}");
            string result = regex.Replace(input, "$&" + Environment.NewLine);
            string path = @"C:\Users\" + userName + @"\Desktop\BacktrackingAlgorithm.txt";
            File.WriteAllText(@"C:\Users\" + userName + @"\Desktop\BacktrackingAlgorithm.txt", String.Empty);
            if (!File.Exists(path))
            {
                File.Create(path);
                StreamWriter tw = new StreamWriter(path);
                tw.WriteLine(" All the unique solution of the 8 Queen Problem!");
                tw.WriteLine(result);
                string TimeItTakesToSaveTheFile = sw.ElapsedMilliseconds + "ms";
                sw.Stop();
                tw.WriteLine(TimeItTakesToSaveTheFile);
                tw.Close();
            }
            else if (File.Exists(path))
            {
                using (var tw = new StreamWriter(path, true))
                {
                    tw.WriteLine("All the unique solution of the 8 Queen Problem");
                    tw.WriteLine(result);
                    tw.WriteLine(columnLists.Count.ToString() + " Results");
                    string TimeItTakesToSaveTheFile = sw.ElapsedMilliseconds + "ms";
                    sw.Stop();
                    tw.WriteLine(TimeItTakesToSaveTheFile);
                    tw.Close();
                }
            }
        }



        // set up for New Game

        private void NewGame_Click(object sender, EventArgs e)
        {

            backgroundWorker3.RunWorkerAsync();
            // New Game dialogue

            A1int = 0; A2int = 0; A3int = 0; A4int = 0; A5int = 0; A6int = 0; A7int = 0; A8int = 0;
            B1int = 0; B2int = 0; B3int = 0; B4int = 0; B5int = 0; B6int = 0; B7int = 0; B8int = 0;
            C1int = 0; C2int = 0; C3int = 0; C4int = 0; C5int = 0; C6int = 0; C7int = 0; C8int = 0;
            D1int = 0; D2int = 0; D3int = 0; D4int = 0; D5int = 0; D6int = 0; D7int = 0; D8int = 0;
            E1int = 0; E2int = 0; E3int = 0; E4int = 0; E5int = 0; E6int = 0; E7int = 0; E8int = 0;
            F1int = 0; F2int = 0; F3int = 0; F4int = 0; F5int = 0; F6int = 0; F7int = 0; F8int = 0;
            G1int = 0; G2int = 0; G3int = 0; G4int = 0; G5int = 0; G6int = 0; G7int = 0; G8int = 0;
            H1int = 0; H2int = 0; H3int = 0; H4int = 0; H5int = 0; H6int = 0; H7int = 0; H8int = 0;


            MessageBox.Show("New Game /Put each of 8 queens (like a4 or g7) to safe place");        // New Game dialogue

            // remove queens from chessboard
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
            next.Visible = false;

            numberOfQueens = 0;      //remove safe queens

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
        string queenposition(int qX_shift, int qY_shift, String[,] Chess_Board)
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

            return "0";


        }


        private void btnA1_Click(object sender, EventArgs e)
        {
            if (A1int == 0)
            {
                if (numberOfQueens < 8)
                {
                    next.Visible = false;
                    numberOfQueens++;
                    A1int++;
                    checkQueen("a1");
                }
                else
                {
                    MessageBox.Show("The number of Queen is more than 8, you can put just 8 Queen in the table!");
                }
            }
            else
            {
                next.Visible = true;
                A1.Visible = false;
                A1int = 0;
                numberOfQueens--;
            }
        }
        private void btnA2_Click(object sender, EventArgs e)
        {
            if (A2int == 0)
            {
                if (numberOfQueens < 8)
                {
                    next.Visible = false;
                    numberOfQueens++;
                    A2int++;
                    checkQueen("a2");
                }
                else
                {
                    MessageBox.Show("The number of Queen is more than 8, you can put just 8 Queen in the table!");
                }
            }
            else
            {
                next.Visible = true;
                A2.Visible = false;
                A2int = 0;
                numberOfQueens--;
                //checkQueen2("a2");
            }
        }
        private void btnA3_Click(object sender, EventArgs e)
        {
            if (A3int == 0)
            {
                if (numberOfQueens < 8)
                {
                    next.Visible = false;
                    numberOfQueens++;
                    A3int++;
                    checkQueen("a3");
                }
                else
                {
                    MessageBox.Show("The number of Queen is more than 8, you can put just 8 Queen in the table!");
                }
            }
            else
            {
                next.Visible = true;
                A3.Visible = false;
                A3int = 0;
                numberOfQueens--;
            }
        }
        private void btnA4_Click(object sender, EventArgs e)
        {
            if (A4int == 0)
            {
                if (numberOfQueens < 8)
                {
                    next.Visible = false;
                    A4int++;
                    checkQueen("a4");
                    numberOfQueens++;
                }
                else
                {
                    MessageBox.Show("The number of Queen is more than 8, you can put just 8 Queen in the table!");
                }
            }
            else
            {
                next.Visible = true;
                A4.Visible = false;
                A4int = 0;
                numberOfQueens--;
            }
        }
        private void btnA5_Click(object sender, EventArgs e)
        {
            if (A5int == 0)
            {
                if (numberOfQueens < 8)
                {
                    next.Visible = false;
                    A5int++;
                    checkQueen("a5");
                    numberOfQueens++;
                }
                else
                {
                    MessageBox.Show("The number of Queen is more than 8, you can put just 8 Queen in the table!");
                }
            }
            else
            {
                next.Visible = true;
                A5.Visible = false;
                A5int = 0;
                numberOfQueens--;
            }
        }
        private void btnA6_Click(object sender, EventArgs e)
        {
            if (A6int == 0)
            {
                if (numberOfQueens < 8)
                {
                    next.Visible = false;
                    A6int++;
                    checkQueen("a6");
                    numberOfQueens++;
                }
                else
                {
                    MessageBox.Show("The number of Queen is more than 8, you can put just 8 Queen in the table!");
                }
            }
            else
            {
                next.Visible = true;
                A6.Visible = false;
                A6int = 0;
                numberOfQueens--;
            }
        }
        private void btnA7_Click(object sender, EventArgs e)
        {
            if (A7int == 0)
            {
                if (numberOfQueens < 8)
                {
                    next.Visible = false;
                    A7int++;
                    checkQueen("a7");
                    numberOfQueens++;
                }
                else
                {
                    MessageBox.Show("The number of Queen is more than 8, you can put just 8 Queen in the table!");
                }
            }
            else
            {
                next.Visible = true;
                A7.Visible = false;
                A7int = 0;
                numberOfQueens--;
            }
        }
        private void btnA8_Click(object sender, EventArgs e)
        {
            if (A8int == 0)
            {
                if (numberOfQueens < 8)
                {
                    next.Visible = false;
                    A8int++;
                    checkQueen("a8");
                    numberOfQueens++;
                }
                else
                {
                    MessageBox.Show("The number of Queen is more than 8, you can put just 8 Queen in the table!");
                }
            }
            else
            {
                next.Visible = true;
                A8.Visible = false;
                A8int = 0;
                numberOfQueens--;
            }
        }

        private void btnB1_Click(object sender, EventArgs e)
        {
            if (B1int == 0)
            {
                if (numberOfQueens < 8)
                {
                    next.Visible = false;
                    B1int++;
                    checkQueen("b1");
                    numberOfQueens++;
                }
                else
                {
                    MessageBox.Show("The number of Queen is more than 8, you can put just 8 Queen in the table!");
                }
            }
            else
            {
                next.Visible = true;
                B1.Visible = false;
                B1int = 0;
                numberOfQueens--;
            }
        }
        private void btnB2_Click(object sender, EventArgs e)
        {
            if (B2int == 0)
            {
                if (numberOfQueens < 8)
                {
                    next.Visible = false;
                    B2int++;
                    checkQueen("b2");
                    numberOfQueens++;
                }
                else
                {
                    MessageBox.Show("The number of Queen is more than 8, you can put just 8 Queen in the table!");
                }
            }
            else
            {
                next.Visible = true;
                B2.Visible = false;
                B2int = 0;
                numberOfQueens--;
            }
        }
        private void btnB3_Click(object sender, EventArgs e)
        {
            if (B3int == 0)
            {
                if (numberOfQueens < 8)
                {
                    next.Visible = false;
                    B3int++;
                    checkQueen("b3");
                    numberOfQueens++;
                }
                else
                {
                    MessageBox.Show("The number of Queen is more than 8, you can put just 8 Queen in the table!");
                }
            }
            else
            {
                next.Visible = true;
                B3.Visible = false;
                B3int = 0;
                numberOfQueens--;
            }
        }
        private void btnB4_Click(object sender, EventArgs e)
        {
            if (B4int == 0)
            {
                if (numberOfQueens < 8)
                {
                    next.Visible = false;
                    B4int++;
                    checkQueen("b4");
                    numberOfQueens++;
                }
                else
                {
                    MessageBox.Show("The number of Queen is more than 8, you can put just 8 Queen in the table!");
                }
            }
            else
            {
                next.Visible = true;
                B4.Visible = false;
                B4int = 0;
                numberOfQueens--;
            }
        }
        private void btnB5_Click(object sender, EventArgs e)
        {
            if (B5int == 0)
            {
                if (numberOfQueens < 8)
                {
                    next.Visible = false;
                    B5int++;
                    checkQueen("b5");
                    numberOfQueens++;
                }
                else
                {
                    MessageBox.Show("The number of Queen is more than 8, you can put just 8 Queen in the table!");
                }
            }
            else
            {
                next.Visible = true;
                B5.Visible = false;
                B5int = 0;
                numberOfQueens--;
            }
        }
        private void btnB6_Click(object sender, EventArgs e)
        {
            if (B6int == 0)
            {
                if (numberOfQueens < 8)
                {
                    next.Visible = false;
                    B6int++;
                    checkQueen("b6");
                    numberOfQueens++;
                }
                else
                {
                    MessageBox.Show("The number of Queen is more than 8, you can put just 8 Queen in the table!");
                }
            }
            else
            {
                next.Visible = true;
                B6.Visible = false;
                B6int = 0;
                numberOfQueens--;
            }
        }
        private void btnB7_Click(object sender, EventArgs e)
        {
            if (B7int == 0)
            {
                if (numberOfQueens < 8)
                {
                    next.Visible = false;
                    B7int++;
                    checkQueen("b7");
                    numberOfQueens++;
                }
                else
                {
                    MessageBox.Show("The number of Queen is more than 8, you can put just 8 Queen in the table!");
                }
            }
            else
            {
                next.Visible = true;
                B7.Visible = false;
                B7int = 0;
                numberOfQueens--;
            }
        }
        private void btnB8_Click(object sender, EventArgs e)
        {
            if (B8int == 0)
            {
                if (numberOfQueens < 8)
                {
                    next.Visible = false;
                    B8int++;
                    checkQueen("b8");
                    numberOfQueens++;
                }
                else
                {
                    MessageBox.Show("The number of Queen is more than 8, you can put just 8 Queen in the table!");
                }
            }
            else
            {
                next.Visible = true;
                B8.Visible = false;
                B8int = 0;
                numberOfQueens--;
            }
        }

        private void btnC1_Click(object sender, EventArgs e)
        {
            if (C1int == 0)
            {
                if (numberOfQueens < 8)
                {
                    next.Visible = false;
                    C1int++;
                    checkQueen("c1");
                    numberOfQueens++;
                }
                else
                {
                    MessageBox.Show("The number of Queen is more than 8, you can put just 8 Queen in the table!");
                }
            }
            else
            {
                next.Visible = true;
                C1.Visible = false;
                C1int = 0;
                numberOfQueens--;
            }
        }
        private void btnC2_Click(object sender, EventArgs e)
        {
            if (C2int == 0)
            {
                if (numberOfQueens < 8)
                {
                    next.Visible = false;
                    C2int++;
                    checkQueen("c2");
                    numberOfQueens++;
                }
                else
                {
                    MessageBox.Show("The number of Queen is more than 8, you can put just 8 Queen in the table!");
                }
            }
            else
            {
                next.Visible = true;
                C2.Visible = false;
                C2int = 0;
                numberOfQueens--;
            }
        }
        private void btnC3_Click(object sender, EventArgs e)
        {
            if (C3int == 0)
            {
                if (numberOfQueens < 8)
                {
                    next.Visible = false;
                    C3int++;
                    checkQueen("c3");
                    numberOfQueens++;
                }
                else
                {
                    MessageBox.Show("The number of Queen is more than 8, you can put just 8 Queen in the table!");
                }
            }
            else
            {
                next.Visible = true;
                C3.Visible = false;
                C3int = 0;
                numberOfQueens--;
            }
        }
        private void btnC4_Click(object sender, EventArgs e)
        {
            if (C4int == 0)
            {
                if (numberOfQueens < 8)
                {
                    next.Visible = false;
                    C4int++;
                    checkQueen("c4");
                    numberOfQueens++;
                }
                else
                {
                    MessageBox.Show("The number of Queen is more than 8, you can put just 8 Queen in the table!");
                }
            }
            else
            {
                next.Visible = true;
                C4.Visible = false;
                C4int = 0;
                numberOfQueens--;
            }
        }
        private void btnC5_Click(object sender, EventArgs e)
        {
            if (C5int == 0)
            {
                if (numberOfQueens < 8)
                {
                    next.Visible = false;
                    C5int++;
                    checkQueen("c5");
                    numberOfQueens++;
                }
                else
                {
                    MessageBox.Show("The number of Queen is more than 8, you can put just 8 Queen in the table!");
                }
            }
            else
            {
                next.Visible = true;
                C5.Visible = false;
                C5int = 0;
                numberOfQueens--;
            }
        }
        private void btnC6_Click(object sender, EventArgs e)
        {
            if (C6int == 0)
            {
                if (numberOfQueens < 8)
                {
                    next.Visible = false;
                    C6int++;
                    checkQueen("c6");
                    numberOfQueens++;
                }
                else
                {
                    MessageBox.Show("The number of Queen is more than 8, you can put just 8 Queen in the table!");
                }
            }
            else
            {
                next.Visible = true;
                C6.Visible = false;
                C6int = 0;
                numberOfQueens--;
            }
        }
        private void btnC7_Click(object sender, EventArgs e)
        {
            if (C7int == 0)
            {
                if (numberOfQueens < 8)
                {
                    next.Visible = false;
                    C7int++;
                    checkQueen("c7");
                    numberOfQueens++;
                }
                else
                {
                    MessageBox.Show("The number of Queen is more than 8, you can put just 8 Queen in the table!");
                }
            }
            else
            {
                next.Visible = true;
                C7.Visible = false;
                C7int = 0;
                numberOfQueens--;
            }
        }
        private void btnC8_Click(object sender, EventArgs e)
        {
            if (C8int == 0)
            {
                if (numberOfQueens < 8)
                {
                    next.Visible = false;
                    C8int++;
                    checkQueen("c8");
                    numberOfQueens++;
                }
                else
                {
                    MessageBox.Show("The number of Queen is more than 8, you can put just 8 Queen in the table!");
                }
            }
            else
            {
                next.Visible = true;
                C8.Visible = false;
                C8int = 0;
                numberOfQueens--;
            }

        }

        private void btnD1_Click(object sender, EventArgs e)
        {
            if (D1int == 0)
            {
                if (numberOfQueens < 8)
                {
                    next.Visible = false;
                    D1int++;
                    checkQueen("d1");
                    numberOfQueens++;
                }
                else
                {
                    MessageBox.Show("The number of Queen is more than 8, you can put just 8 Queen in the table!");
                }
            }
            else
            {
                next.Visible = true;
                D1.Visible = false;
                D1int = 0;
                numberOfQueens--;
            }
        }
        private void btnD2_Click(object sender, EventArgs e)
        {
            if (D2int == 0)
            {
                if (numberOfQueens < 8)
                {
                    next.Visible = false;
                    D2int++;
                    checkQueen("d2");
                    numberOfQueens++;
                }
                else
                {
                    MessageBox.Show("The number of Queen is more than 8, you can put just 8 Queen in the table!");
                }
            }
            else
            {
                next.Visible = true;
                D2.Visible = false;
                D2int = 0;
                numberOfQueens--;
            }
        }
        private void btnD3_Click(object sender, EventArgs e)
        {
            if (D3int == 0)
            {
                if (numberOfQueens < 8)
                {
                    next.Visible = false;
                    D3int++;
                    checkQueen("d3");
                    numberOfQueens++;
                }
                else
                {
                    MessageBox.Show("The number of Queen is more than 8, you can put just 8 Queen in the table!");
                }
            }
            else
            {
                D3.Visible = false;
                D3int = 0;
                numberOfQueens--;
                next.Visible = true;
            }
        }
        private void btnD4_Click(object sender, EventArgs e)
        {
            if (D4int == 0)
            {
                if (numberOfQueens < 8)
                {
                    next.Visible = false;
                    D4int++;
                    checkQueen("d4");
                    numberOfQueens++;
                }
                else
                {
                    MessageBox.Show("The number of Queen is more than 8, you can put just 8 Queen in the table!");
                }
            }
            else
            {
                D4.Visible = false;
                D4int = 0;
                numberOfQueens--;
                next.Visible = true;
            }
        }
        private void btnD5_Click(object sender, EventArgs e)
        {
            if (D5int == 0)
            {
                if (numberOfQueens < 8)
                {
                    next.Visible = false;
                    D5int++;
                    checkQueen("d5");
                    numberOfQueens++;
                }
                else
                {
                    MessageBox.Show("The number of Queen is more than 8, you can put just 8 Queen in the table!");
                }
            }
            else
            {
                D5.Visible = false;
                D5int = 0;
                numberOfQueens--;
                next.Visible = true;
            }
        }
        private void btnD6_Click(object sender, EventArgs e)
        {
            if (D6int == 0)
            {
                if (numberOfQueens < 8)
                {
                    next.Visible = false;
                    D6int++;
                    checkQueen("d6");
                    numberOfQueens++;
                }
                else
                {
                    MessageBox.Show("The number of Queen is more than 8, you can put just 8 Queen in the table!");
                }
            }
            else
            {
                D6.Visible = false;
                D6int = 0;
                numberOfQueens--;
                next.Visible = true;
            }
        }
        private void btnD7_Click(object sender, EventArgs e)
        {
            if (D7int == 0)
            {
                if (numberOfQueens < 8)
                {
                    next.Visible = false;
                    D7int++;
                    checkQueen("d7");
                    numberOfQueens++;
                }
                else
                {
                    MessageBox.Show("The number of Queen is more than 8, you can put just 8 Queen in the table!");
                }
            }
            else
            {
                D7.Visible = false;
                D7int = 0;
                numberOfQueens--;
                next.Visible = true;
            }
        }
        private void btnD8_Click(object sender, EventArgs e)
        {
            if (D8int == 0)
            {
                if (numberOfQueens < 8)
                {
                    next.Visible = false;
                    D8int++;
                    checkQueen("d8");
                    numberOfQueens++;
                }
                else
                {
                    MessageBox.Show("The number of Queen is more than 8, you can put just 8 Queen in the table!");
                }
            }
            else
            {
                D8.Visible = false;
                D8int = 0;
                numberOfQueens--;
                next.Visible = true;
            }
        }

        private void btnE1_Click(object sender, EventArgs e)
        {
            if (E1int == 0)
            {
                if (numberOfQueens < 8)
                {
                    next.Visible = false;
                    E1int++;
                    checkQueen("e1");
                    numberOfQueens++;
                }
                else
                {
                    MessageBox.Show("The number of Queen is more than 8, you can put just 8 Queen in the table!");
                }
            }
            else
            {
                E1.Visible = false;
                E1int = 0;
                numberOfQueens--;
                next.Visible = true;
            }
        }
        private void btnE2_Click(object sender, EventArgs e)
        {
            if (E2int == 0)
            {
                if (numberOfQueens < 8)
                {
                    next.Visible = false;
                    E2int++;
                    checkQueen("e2");
                    numberOfQueens++;
                }
                else
                {
                    MessageBox.Show("The number of Queen is more than 8, you can put just 8 Queen in the table!");
                }
            }
            else
            {
                E2.Visible = false;
                E2int = 0;
                numberOfQueens--;
                next.Visible = true;
            }
        }
        private void btnE3_Click(object sender, EventArgs e)
        {
            if (E3int == 0)
            {
                if (numberOfQueens < 8)
                {
                    next.Visible = false;
                    E3int++;
                    checkQueen("e3");
                    numberOfQueens++;
                }
                else
                {
                    MessageBox.Show("The number of Queen is more than 8, you can put just 8 Queen in the table!");
                }
            }
            else
            {
                E3.Visible = false;
                E3int = 0;
                numberOfQueens--;
                next.Visible = true;
            }
        }
        private void btnE4_Click(object sender, EventArgs e)
        {
            if (E4int == 0)
            {
                if (numberOfQueens < 8)
                {
                    next.Visible = false;
                    E4int++;
                    checkQueen("e4");
                    numberOfQueens++;
                }
                else
                {
                    MessageBox.Show("The number of Queen is more than 8, you can put just 8 Queen in the table!");
                }
            }
            else
            {
                E4.Visible = false;
                E4int = 0;
                numberOfQueens--;
                next.Visible = true;
            }
        }
        private void btnE5_Click(object sender, EventArgs e)
        {
            if (E5int == 0)
            {
                if (numberOfQueens < 8)
                {
                    next.Visible = false;
                    E5int++;
                    checkQueen("e5");
                    numberOfQueens++;
                }
                else
                {
                    MessageBox.Show("The number of Queen is more than 8, you can put just 8 Queen in the table!");
                }
            }
            else
            {
                E5.Visible = false;
                E5int = 0;
                numberOfQueens--;
                next.Visible = true;
            }
        }
        private void btnE6_Click(object sender, EventArgs e)
        {
            if (E6int == 0)
            {
                if (numberOfQueens < 8)
                {
                    next.Visible = false;
                    E6int++;
                    checkQueen("e6");
                    numberOfQueens++;
                }
                else
                {
                    MessageBox.Show("The number of Queen is more than 8, you can put just 8 Queen in the table!");
                }
            }
            else
            {
                E6.Visible = false;
                E6int = 0;
                numberOfQueens--;
                next.Visible = true;
            }
        }
        private void btnE7_Click(object sender, EventArgs e)
        {
            if (E7int == 0)
            {
                if (numberOfQueens < 8)
                {
                    next.Visible = false;
                    E7int++;
                    checkQueen("e7");
                    numberOfQueens++;
                }
                else
                {
                    MessageBox.Show("The number of Queen is more than 8, you can put just 8 Queen in the table!");
                }
            }
            else
            {
                E7.Visible = false;
                E7int = 0;
                numberOfQueens--;
                next.Visible = true;
            }
        }
        private void btnE8_Click(object sender, EventArgs e)
        {
            if (E8int == 0)
            {
                if (numberOfQueens < 8)
                {
                    next.Visible = false;
                    E8int++;
                    checkQueen("e8");
                    numberOfQueens++;
                }
                else
                {
                    MessageBox.Show("The number of Queen is more than 8, you can put just 8 Queen in the table!");
                }
            }
            else
            {
                E8.Visible = false;
                E8int = 0;
                numberOfQueens--;
                next.Visible = true;
            }
        }

        private void btnF1_Click(object sender, EventArgs e)
        {
            if (F1int == 0)
            {
                if (numberOfQueens < 8)
                {
                    next.Visible = false;
                    F1int++;
                    checkQueen("f1");
                    numberOfQueens++;
                }
                else
                {
                    MessageBox.Show("The number of Queen is more than 8, you can put just 8 Queen in the table!");
                }
            }
            else
            {
                F1.Visible = false;
                F1int = 0;
                numberOfQueens--;
                next.Visible = true;
            }
        }
        private void btnF2_Click(object sender, EventArgs e)
        {
            if (F2int == 0)
            {
                if (numberOfQueens < 8)
                {
                    next.Visible = false;
                    F2int++;
                    checkQueen("f2");
                    numberOfQueens++;
                }
                else
                {
                    MessageBox.Show("The number of Queen is more than 8, you can put just 8 Queen in the table!");
                }
            }
            else
            {
                F2.Visible = false;
                F2int = 0;
                numberOfQueens--;
                next.Visible = true;
            }
        }
        private void btnF3_Click(object sender, EventArgs e)
        {
            if (F3int == 0)
            {
                if (numberOfQueens < 8)
                {
                    next.Visible = false;
                    F3int++;
                    checkQueen("f3");
                    numberOfQueens++;
                }
                else
                {
                    MessageBox.Show("The number of Queen is more than 8, you can put just 8 Queen in the table!");
                }
            }
            else
            {
                F3.Visible = false;
                F3int = 0;
                numberOfQueens--;
                next.Visible = true;
            }
        }
        private void btnF4_Click(object sender, EventArgs e)
        {
            if (F4int == 0)
            {
                if (numberOfQueens < 8)
                {
                    next.Visible = false;
                    F4int++;
                    checkQueen("f4");
                    numberOfQueens++;
                }
                else
                {
                    MessageBox.Show("The number of Queen is more than 8, you can put just 8 Queen in the table!");
                }
            }
            else
            {
                F4.Visible = false;
                F4int = 0;
                numberOfQueens--;
                next.Visible = true;
            }
        }
        private void btnF5_Click(object sender, EventArgs e)
        {
            if (F5int == 0)
            {
                if (numberOfQueens < 8)
                {
                    next.Visible = false;
                    F5int++;
                    checkQueen("f5");
                    numberOfQueens++;
                }
                else
                {
                    MessageBox.Show("The number of Queen is more than 8, you can put just 8 Queen in the table!");
                }
            }
            else
            {
                F5.Visible = false;
                F5int = 0;
                numberOfQueens--;
                next.Visible = true;
            }
        }
        private void btnF6_Click(object sender, EventArgs e)
        {
            if (F6int == 0)
            {
                if (numberOfQueens < 8)
                {
                    next.Visible = false;
                    F6int++;
                    checkQueen("f6");
                    numberOfQueens++;
                }
                else
                {
                    MessageBox.Show("The number of Queen is more than 8, you can put just 8 Queen in the table!");
                }
            }
            else
            {
                F6.Visible = false;
                F6int = 0;
                numberOfQueens--;
                next.Visible = true;
            }
        }
        private void btnF7_Click(object sender, EventArgs e)
        {
            if (F7int == 0)
            {
                if (numberOfQueens < 8)
                {
                    next.Visible = false;
                    F7int++;
                    checkQueen("f7");
                    numberOfQueens++;
                }
                else
                {
                    MessageBox.Show("The number of Queen is more than 8, you can put just 8 Queen in the table!");
                }
            }
            else
            {
                F7.Visible = false;
                F7int = 0;
                numberOfQueens--;
                next.Visible = true;
            }
        }
        private void btnF8_Click(object sender, EventArgs e)
        {
            if (F8int == 0)
            {
                if (numberOfQueens < 8)
                {
                    next.Visible = false;
                    F8int++;
                    checkQueen("f8");
                    numberOfQueens++;
                }
                else
                {
                    MessageBox.Show("The number of Queen is more than 8, you can put just 8 Queen in the table!");
                }
            }
            else
            {
                F8.Visible = false;
                F8int = 0;
                numberOfQueens--;
                next.Visible = true;
            }
        }

        private void btnG1_Click(object sender, EventArgs e)
        {
            if (G1int == 0)
            {
                if (numberOfQueens < 8)
                {
                    next.Visible = false;
                    G1int++;
                    checkQueen("g1");
                    numberOfQueens++;
                }
                else
                {
                    MessageBox.Show("The number of Queen is more than 8, you can put just 8 Queen in the table!");
                }
            }
            else
            {
                G1.Visible = false;
                G1int = 0;
                numberOfQueens--;
                next.Visible = true;
            }
        }
        private void btnG2_Click(object sender, EventArgs e)
        {
            if (G2int == 0)
            {
                if (numberOfQueens < 8)
                {
                    next.Visible = false;
                    G2int++;
                    checkQueen("g2");
                    numberOfQueens++;
                }
                else
                {
                    MessageBox.Show("The number of Queen is more than 8, you can put just 8 Queen in the table!");
                }
            }
            else
            {
                G2.Visible = false;
                G2int = 0;
                numberOfQueens--;
                next.Visible = true;
            }
        }
        private void btnG3_Click(object sender, EventArgs e)
        {
            if (G3int == 0)
            {
                if (numberOfQueens < 8)
                {
                    next.Visible = false;
                    G3int++;
                    checkQueen("g3");
                    numberOfQueens++;
                }
                else
                {
                    MessageBox.Show("The number of Queen is more than 8, you can put just 8 Queen in the table!");
                }
            }
            else
            {
                G3.Visible = false;
                G3int = 0;
                numberOfQueens--;
                next.Visible = true;
            }
        }
        private void btnG4_Click(object sender, EventArgs e)
        {
            if (G4int == 0)
            {
                if (numberOfQueens < 8)
                {
                    next.Visible = false;
                    G4int++;
                    checkQueen("g4");
                    numberOfQueens++;
                }
                else
                {
                    MessageBox.Show("The number of Queen is more than 8, you can put just 8 Queen in the table!");
                }
            }
            else
            {
                G4.Visible = false;
                G4int = 0;
                numberOfQueens--;
                next.Visible = true;
            }
        }
        private void btnG5_Click(object sender, EventArgs e)
        {
            if (G5int == 0)
            {
                if (numberOfQueens < 8)
                {
                    next.Visible = false;
                    G5int++;
                    checkQueen("g5");
                    numberOfQueens++;
                }
                else
                {
                    MessageBox.Show("The number of Queen is more than 8, you can put just 8 Queen in the table!");
                }
            }
            else
            {
                G5.Visible = false;
                G5int = 0;
                numberOfQueens--;
                next.Visible = true;
            }
        }
        private void btnG6_Click(object sender, EventArgs e)
        {
            if (G6int == 0)
            {
                if (numberOfQueens < 8)
                {
                    next.Visible = false;
                    G6int++;
                    checkQueen("g6");
                    numberOfQueens++;
                }
                else
                {
                    MessageBox.Show("The number of Queen is more than 8, you can put just 8 Queen in the table!");
                }
            }
            else
            {
                G6.Visible = false;
                G6int = 0;
                numberOfQueens--;
                next.Visible = true;
            }
        }
        private void btnG7_Click(object sender, EventArgs e)
        {
            if (G7int == 0)
            {
                if (numberOfQueens < 8)
                {
                    next.Visible = false;
                    G7int++;
                    checkQueen("g7");
                    numberOfQueens++;
                }
                else
                {
                    MessageBox.Show("The number of Queen is more than 8, you can put just 8 Queen in the table!");
                }
            }
            else
            {
                G7.Visible = false;
                G7int = 0;
                numberOfQueens--;
                next.Visible = true;
            }
        }
        private void btnG8_Click(object sender, EventArgs e)
        {
            if (G8int == 0)
            {
                if (numberOfQueens < 8)
                {
                    next.Visible = false;
                    G8int++;
                    checkQueen("g8");
                    numberOfQueens++;
                }
                else
                {
                    MessageBox.Show("The number of Queen is more than 8, you can put just 8 Queen in the table!");
                }
            }
            else
            {
                G8.Visible = false;
                G8int = 0;
                numberOfQueens--;
                next.Visible = true;
            }
        }

        private void btnH1_Click(object sender, EventArgs e)
        {
            if (H1int == 0)
            {
                if (numberOfQueens < 8)
                {
                    next.Visible = false;
                    H1int++;
                    checkQueen("h1");
                    numberOfQueens++;
                }
                else
                {
                    MessageBox.Show("The number of Queen is more than 8, you can put just 8 Queen in the table!");
                }
            }
            else
            {
                H1.Visible = false;
                H1int = 0;
                numberOfQueens--;
                next.Visible = true;
            }
        }
        private void btnH2_Click(object sender, EventArgs e)
        {
            if (H2int == 0)
            {
                if (numberOfQueens < 8)
                {
                    next.Visible = false;
                    H2int++;
                    checkQueen("h2");
                    numberOfQueens++;
                }
                else
                {
                    MessageBox.Show("The number of Queen is more than 8, you can put just 8 Queen in the table!");
                }
            }
            else
            {
                H2.Visible = false;
                H2int = 0;
                numberOfQueens--;
                next.Visible = true;
            }
        }
        private void btnH3_Click(object sender, EventArgs e)
        {
            if (H3int == 0)
            {
                if (numberOfQueens < 8)
                {
                    next.Visible = false;
                    H3int++;
                    checkQueen("h3");
                    numberOfQueens++;
                }
                else
                {
                    MessageBox.Show("The number of Queen is more than 8, you can put just 8 Queen in the table!");
                }
            }
            else
            {
                H3.Visible = false;
                H3int = 0;
                numberOfQueens--;
                next.Visible = true;
            }
        }
        private void btnH4_Click(object sender, EventArgs e)
        {
            if (H4int == 0)
            {
                if (numberOfQueens < 8)
                {
                    next.Visible = false;
                    H4int++;
                    checkQueen("h4");
                    numberOfQueens++;
                }
                else
                {
                    MessageBox.Show("The number of Queen is more than 8, you can put just 8 Queen in the table!");
                }
            }
            else
            {
                H4.Visible = false;
                H4int = 0;
                numberOfQueens--;
                next.Visible = true;
            }
        }
        private void button17_Click(object sender, EventArgs e)
        {
            if (H5int == 0)
            {
                if (numberOfQueens < 8)
                {
                    next.Visible = false;
                    H5int++;
                    numberOfQueens++;
                    checkQueen("h5");
                    numberOfQueens++;
                }
                else
                {
                    MessageBox.Show("The number of Queen is more than 8, you can put just 8 Queen in the table!");
                }
            }
            else
            {
                H5.Visible = false;
                H5int--;
                numberOfQueens--;
                next.Visible = true;
            }
        }
        private void btnH6_Click(object sender, EventArgs e)
        {
            if (H6int == 0)
            {
                if (numberOfQueens < 8)
                {
                    next.Visible = false;
                    H6int++;
                    checkQueen("h6");
                    numberOfQueens++;
                }
                else
                {
                    MessageBox.Show("The number of Queen is more than 8, you can put just 8 Queen in the table!");
                }
            }
            else
            {
                H6.Visible = false;
                H6int = 0;
                numberOfQueens--;
                next.Visible = true;
            }
        }
        private void btnH7_Click(object sender, EventArgs e)
        {
            if (H7int == 0)
            {
                if (numberOfQueens < 8)
                {
                    next.Visible = false;
                    H7int++;
                    checkQueen("h7");
                    numberOfQueens++;
                }
                else
                {
                    MessageBox.Show("The number of Queen is more than 8, you can put just 8 Queen in the table!");
                }
            }
            else
            {
                H7.Visible = false;
                H7int = 0;
                numberOfQueens--;
                next.Visible = true;
            }
        }
        private void btnH8_Click(object sender, EventArgs e)
        {
            if (H8int == 0)
            {
                if (numberOfQueens < 8)
                {
                    next.Visible = false;
                    H8int++;
                    checkQueen("h8");
                    numberOfQueens++;
                }
                else
                {
                    MessageBox.Show("The number of Queen is more than 8, you can put just 8 Queen in the table!");
                }
            }
            else
            {
                H8.Visible = false;
                H8int = 0;
                numberOfQueens--;
                next.Visible = true;
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

        private void btnTreeAlgorithm_Click(object sender, EventArgs e)
        {
            string userName = Environment.UserName;
            Stopwatch sw = Stopwatch.StartNew();
            // the code that you want to measure comes here

            new Position(0, Int32.MinValue, null).WalkThroughTree();
            string textToPrint = Environment.NewLine + Position.AllSolution + Environment.NewLine + "Queens/Squares: " + Position.NumberOfQueens.ToString("#,##0");
            textToPrint += Environment.NewLine + "Attempts: " + Position.NumberOfAttempts.ToString("#,##0");
            textToPrint += Environment.NewLine + "\nNodes: " + (Position.NumberOfNodes - 1).ToString("#,##0");
            textToPrint += Environment.NewLine + "\nSolutions: " + Position.NumberOfSolutions.ToString("#,##0");

            string path = @"C:\Users\" + userName + @"\Desktop\TreeAlgorithm.txt";
            File.WriteAllText(@"C:\Users\" + userName + @"\Desktop\TreeAlgorithm.txt", String.Empty);
            if (!File.Exists(path))
            {
                File.Create(path);
                StreamWriter tw = new StreamWriter(path);
                tw.WriteLine(" All the unique solution of the 8 Queen Problem!");
                tw.WriteLine(textToPrint);
                string TimeItTakesToSaveTheFile = sw.ElapsedMilliseconds + "ms";
                sw.Stop();
                tw.WriteLine(TimeItTakesToSaveTheFile);
                tw.Close();
            }
            else if (File.Exists(path))
            {
                using (var tw = new StreamWriter(path, true))
                {
                    tw.WriteLine("All the unique solution of the 8 Queen Problem");
                    tw.WriteLine(textToPrint);
                    string TimeItTakesToSaveTheFile = sw.ElapsedMilliseconds + "ms";
                    sw.Stop();
                    tw.WriteLine(TimeItTakesToSaveTheFile);
                    tw.Close();
                }
            }
        }
    }
}      
