using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class Form1 : Form
    {

        String[] gameBoard = new string[9];
        int currentTurn = 0;
        static String player1, player2;

        public Form1()
        {
            InitializeComponent();
        }

        public static void setPlayerNames(String n1, String n2)
        {
            player1 = n1;
            player2 = n2;
        }

        public String returnSymbol(int turn)
        {
             if (turn % 2 == 0) 
            {
                return "O";
            }
            else 
            {
                return "X";
            }
        }

       
        public void checkForWinner() 
        {
            try { 
            for (int i=0; i<8; i++) 
            {
                String combination = "";

                switch(i)
                {
                    case 0:
                        combination = gameBoard[0] + gameBoard[1] + gameBoard[2];
                        break;
                    case 1:
                        combination = gameBoard[3] + gameBoard[4] + gameBoard[5];
                        break;
                    case 2:
                        combination = gameBoard[6] + gameBoard[7] + gameBoard[8];
                        break;
                    case 3:
                        combination = gameBoard[0] + gameBoard[3] + gameBoard[6];
                        break;
                    case 4:
                        combination = gameBoard[1] + gameBoard[4] + gameBoard[7];
                        break;
                    case 5:
                        combination = gameBoard[2] + gameBoard[5] + gameBoard[8];
                        break;
                    case 6:
                        combination = gameBoard[0] + gameBoard[4] + gameBoard[8];
                        break;
                    case 7:
                        combination = gameBoard[2] + gameBoard[4] + gameBoard[6];
                        break;

                }


                        if (combination.Equals("OOO"))
                                                                  
                        {
                         
                         reset();
                         MessageBox.Show( label2.Text + "  venceu a partida!", "Temos um vencedor!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                         o_win_count.Text = (Int16.Parse(o_win_count.Text) + 1).ToString();
                        }
                        else if(combination.Equals("XXX"))
                        {
                         reset();
                         MessageBox.Show( label1.Text + " venceu a partida!", "Temos um vencedor!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        x_win_count.Text = (Int16.Parse(x_win_count.Text) + 1).ToString();
                        }

                checkDraw();
            }
            }
            catch { }

            }

        
        public void reset()
        {
            button1.Text = "";
            button2.Text = "";
            button3.Text = "";
            button4.Text = "";
            button5.Text = "";
            button6.Text = "";
            button7.Text = "";
            button8.Text = "";
            button9.Text = "";
            gameBoard = new string[9];
            currentTurn = 0;
        }

        public void checkDraw()
        {
            int counter = 0;
            for (int i=0; i<gameBoard.Length; i++)
            {
                if (gameBoard[i] !=null) { counter++;}

                if (counter == 9)
                {
                    reset();
                    draw_count.Text = (Int16.Parse(draw_count.Text) + 1).ToString();
                    MessageBox.Show("Vocês empataram a partida!", "Temos um empate!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }
        }

              
        private void button1_Click(object sender, EventArgs e)
        {
            currentTurn++;
            gameBoard[0] = returnSymbol(currentTurn);
            button1.Text = gameBoard[0];
            checkForWinner();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            currentTurn++;
            gameBoard[1] = returnSymbol(currentTurn);
            button2.Text = gameBoard[1];
            checkForWinner();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            currentTurn++;
            gameBoard[2] = returnSymbol(currentTurn);
            button3.Text = gameBoard[2];
            checkForWinner();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            currentTurn++;
            gameBoard[3] = returnSymbol(currentTurn);
            button4.Text = gameBoard[3];
            checkForWinner();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            currentTurn++;
            gameBoard[4] = returnSymbol(currentTurn);
            button5.Text = gameBoard[4];
            checkForWinner();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            currentTurn++;
            gameBoard[5] = returnSymbol(currentTurn);
            button6.Text = gameBoard[5];
            checkForWinner();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            currentTurn++;
            gameBoard[6] = returnSymbol(currentTurn);
            button7.Text = gameBoard[6];
            checkForWinner();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            currentTurn++;
            gameBoard[7] = returnSymbol(currentTurn);
            button8.Text = gameBoard[7];
            checkForWinner();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            currentTurn++;
            gameBoard[8] = returnSymbol(currentTurn);
            button9.Text = gameBoard[8];
            checkForWinner();
        }

        private void o_win_count_Click(object sender, EventArgs e)
        {

        }

       

        private void sobreToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Feito por Matheus", "Obrigado por jogar!");
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void novoJogoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            o_win_count.Text = "0";
            x_win_count.Text = "0";
            draw_count.Text =  "0";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.ShowDialog();
            label1.Text = player1;
            label2.Text = player2;
        }
    }
}
