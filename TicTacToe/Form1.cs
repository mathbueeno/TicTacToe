using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TicTacToe.Config;

namespace TicTacToe
{
    public partial class Form1 : Form
    {

        TipoJogadores?[] gameBoard = new TipoJogadores?[16];
        static String player1, player2;

        public int currentTurn = 0;


        public Form1()
        {
            InitializeComponent();
        }

        public static void setPlayerNames(String n1, String n2)
        {
            player1 = n1;
            player2 = n2;
        }

        public TipoJogadores returnSymbol(int turn)
        {
            return (turn % 2 == 0) ? TipoJogadores.JogadorO : TipoJogadores.JogadorX;



        }

        public Retorno findMatch()
        {
            //                combination = gameBoard[0] + gameBoard[4] + gameBoard[8];
            //                combination = gameBoard[2] + gameBoard[4] + gameBoard[6];
            try
            {


                // diagonais ok
                if (gameBoard[0] != null && gameBoard[0] == gameBoard[5] && gameBoard[0] == gameBoard[10] && gameBoard[0] == gameBoard[15])
                    return new Retorno() { Sucesso = true, Tipo = gameBoard[0] };



                if (gameBoard[3] != null && gameBoard[3] == gameBoard[6] && gameBoard[3] == gameBoard[9] && gameBoard[3] == gameBoard[12])
                    return new Retorno() { Sucesso = true, Tipo = gameBoard[3] };


                // i < 16 - mudança
                for (int i = 0; i < 15; i++)
                {
                    // horizontal 
                    // i    +   1 - mudança
                    var valorInicial = i == 0 ? 0 : i + 2;
                    if (gameBoard[valorInicial] != null && gameBoard[valorInicial] == gameBoard[valorInicial + 1] && gameBoard[valorInicial] == gameBoard[valorInicial + 2] && gameBoard[valorInicial] == gameBoard[valorInicial + 3])
                        return new Retorno() { Sucesso = true, Tipo = gameBoard[valorInicial] };



                    // vertical ok
                    // combination = gameBoard[0] + gameBoard[3] + gameBoard[6];
                    //combination = gameBoard[1] + gameBoard[4] + gameBoard[7];
                    if (gameBoard[i] != null && gameBoard[i] == gameBoard[i + 4] && gameBoard[i] == gameBoard[i + 8] && gameBoard[i] == gameBoard[i + 12])
                        return new Retorno() { Sucesso = true, Tipo = gameBoard[i] };


                }
            }
            catch { }
            return new Retorno();
        }

        public void checkForWinner()
        {


            //    try { 
            //    for (int i=0; i<8; i++) 
            //    {
            //        String combination = "";

            //        switch(i)
            //        {
            //            case 0:
            //                combination = gameBoard[0] + gameBoard[1] + gameBoard[2];
            //                break;
            //            case 1:
            //                combination = gameBoard[3] + gameBoard[4] + gameBoard[5];
            //                break;
            //            case 2:
            //                combination = gameBoard[6] + gameBoard[7] + gameBoard[8];
            //                break;
            //            case 3:
            //                combination = gameBoard[0] + gameBoard[3] + gameBoard[6];
            //                break;
            //            case 4:
            //                combination = gameBoard[1] + gameBoard[4] + gameBoard[7];
            //                break;
            //            case 5:
            //                combination = gameBoard[2] + gameBoard[5] + gameBoard[8];
            //                break;
            //            case 6:
            //                combination = gameBoard[0] + gameBoard[4] + gameBoard[8];
            //                break;
            //            case 7:
            //                combination = gameBoard[2] + gameBoard[4] + gameBoard[6];
            //                break;

            //}
            var retornoVencedor = findMatch();

            if (retornoVencedor.Sucesso)
            {
                var jogadorVencedorCount = retornoVencedor.Tipo == TipoJogadores.JogadorO ? o_win_count : x_win_count;
                var jogadorVencedorLabel = retornoVencedor.Tipo == TipoJogadores.JogadorO ? label2 : label1;
                reset();
                MessageBox.Show(jogadorVencedorLabel.Text + "  venceu a partida!", "Temos um vencedor!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                jogadorVencedorCount.Text = (Int16.Parse(jogadorVencedorCount.Text) + 1).ToString();
            }
            checkDraw();


            //if (combination.Equals("OOO"))

            //            {

            //             reset();
            //             MessageBox.Show( label2.Text + "  venceu a partida!", "Temos um vencedor!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //             o_win_count.Text = (Int16.Parse(o_win_count.Text) + 1).ToString();
            //            }
            //            else if(combination.Equals("XXX"))
            //            {
            //             reset();
            //             MessageBox.Show( label1.Text + " venceu a partida!", "Temos um vencedor!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //            x_win_count.Text = (Int16.Parse(x_win_count.Text) + 1).ToString();
            //            }

            //    checkDraw();
            //}
            //}
            //catch { }

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
            button10.Text = "";
            button11.Text = "";
            button12.Text = "";
            button13.Text = "";
            button14.Text = "";
            button15.Text = "";
            button16.Text = "";
            gameBoard = new TipoJogadores?[16];
            currentTurn = 0;
        }

        public void checkDraw()
        {

            for (int i = 0; i < gameBoard.Length; i++)
            {
                if (gameBoard[i] == null)
                    break;

                if (i == 15)
                {
                    reset();
                    draw_count.Text = (Int16.Parse(draw_count.Text) + 1).ToString();
                    MessageBox.Show("Vocês empataram a partida!", "Temos um empate!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }
        }

        // Esse método retorna X ou O
        private String GetJogador(TipoJogadores? tipo)
        {


            return tipo == TipoJogadores.JogadorX ? "X" : "O";


        }

        public void button1_Click(object sender, EventArgs e) // otimizar esses botões
        {
            //currentTurn++;
            //gameBoard[0] = returnSymbol(currentTurn);
            button1.Text = GetJogador(gameBoard[0] = returnSymbol(currentTurn = currentTurn + 1));
            checkForWinner();
        }

        public void button2_Click(object sender, EventArgs e) // 4x4 para acertar ok
        {
            //currentTurn++;
            //gameBoard[1] = returnSymbol(currentTurn);
            button2.Text = GetJogador(gameBoard[1] = returnSymbol(currentTurn = currentTurn + 1));
            checkForWinner();
        }

        public void button3_Click(object sender, EventArgs e)
        {
            //currentTurn++;
            //gameBoard[2] = returnSymbol(currentTurn);
            button3.Text = GetJogador(gameBoard[2] = returnSymbol(currentTurn = currentTurn + 1));
            checkForWinner();
        }

        public void button13_Click(object sender, EventArgs e)
        {
            // currentTurn++;
            //gameBoard[3] = returnSymbol(currentTurn);
            button13.Text = GetJogador(gameBoard[3] = returnSymbol(currentTurn = currentTurn + 1));
            checkForWinner();
        }

        public void button4_Click(object sender, EventArgs e)
        {
            // currentTurn++;
            // gameBoard[4] = returnSymbol(currentTurn);
            button4.Text = GetJogador(gameBoard[4] = returnSymbol(currentTurn = currentTurn + 1));
            checkForWinner();
        }

        public void button5_Click(object sender, EventArgs e)
        {
            // currentTurn++;
            // gameBoard[5] = returnSymbol(currentTurn);
            button5.Text = GetJogador(gameBoard[5] = returnSymbol(currentTurn = currentTurn + 1));
            checkForWinner();
        }

        public void button6_Click(object sender, EventArgs e)
        {
            // currentTurn++;
            // gameBoard[6] = returnSymbol(currentTurn);
            button6.Text = GetJogador(gameBoard[6] = returnSymbol(currentTurn = currentTurn + 1));
            checkForWinner();
        }
        public void button14_Click(object sender, EventArgs e)
        {
            //currentTurn++;
            //gameBoard[7] = returnSymbol(currentTurn);
            button14.Text = GetJogador(gameBoard[7] = returnSymbol(currentTurn = currentTurn + 1));
            checkForWinner();
        }

        public void button7_Click(object sender, EventArgs e)
        {
            //currentTurn++;
            //gameBoard[8] = returnSymbol(currentTurn);
            button7.Text = GetJogador(gameBoard[8] = returnSymbol(currentTurn = currentTurn + 1));
            checkForWinner();
        }

        public void button8_Click(object sender, EventArgs e)
        {
            // currentTurn++;
            //gameBoard[9] = returnSymbol(currentTurn);
            button8.Text = GetJogador(gameBoard[9] = returnSymbol(currentTurn = currentTurn + 1));
            checkForWinner();
        }

        public void button9_Click(object sender, EventArgs e)
        {
            // currentTurn++;
            // gameBoard[10] = returnSymbol(currentTurn);
            button9.Text = GetJogador(gameBoard[10] = returnSymbol(currentTurn = currentTurn + 1));
            checkForWinner();
        }
        public void button15_Click(object sender, EventArgs e)
        {
            // currentTurn++;
            // gameBoard[11] = returnSymbol(currentTurn);
            button15.Text = GetJogador(gameBoard[11] = returnSymbol(currentTurn = currentTurn + 1));
            checkForWinner();
        }
        public void button10_Click(object sender, EventArgs e)
        {
            // currentTurn++;
            //gameBoard[12] = returnSymbol(currentTurn);
            button10.Text = GetJogador(gameBoard[12] = returnSymbol(currentTurn = currentTurn + 1));
            checkForWinner();
        }

        public void button11_Click(object sender, EventArgs e)
        {
            // currentTurn++;
            // gameBoard[13] = returnSymbol(currentTurn);
            button11.Text = GetJogador(gameBoard[13] = returnSymbol(currentTurn = currentTurn + 1));
            checkForWinner();
        }

        public void button12_Click(object sender, EventArgs e)
        {
            // currentTurn++;
            // gameBoard[14] = returnSymbol(currentTurn);
            button12.Text = GetJogador(gameBoard[14] = returnSymbol(currentTurn = currentTurn + 1));
            checkForWinner();
        }


        private void button16_Click(object sender, EventArgs e)
        {
            // currentTurn++;
            // gameBoard[15] = returnSymbol(currentTurn);
            button16.Text = GetJogador(gameBoard[15] = returnSymbol(currentTurn = currentTurn + 1));
            checkForWinner();
        }


        private void o_win_count_Click(object sender, EventArgs e)
        {

        }


        private void sobreToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("O objetivo do jogo é fazer uma sequência de três símbolos iguais, seja em linha vertical, horizontal ou diagonal, enquanto tenta impedir que seu adversário faça o mesmo.", "Objetivo do jogo");
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void novoJogoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            o_win_count.Text = "0";
            x_win_count.Text = "0";
            draw_count.Text = "0";
            reset();
        }

        private void x_win_count_Click(object sender, EventArgs e)
        {

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
