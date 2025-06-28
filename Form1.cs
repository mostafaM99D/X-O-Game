using _5__X_O_Project.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _5__X_O_Project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        enum enPlayer {Player1,Player2 };
        enum enWinner { Player1,Player2,Draw };
        struct stGameResult
        {
            public int Player1Score  ;
            public int Player2Score ;
            public int GameScore ;
           
        }

        stGameResult GameResult;
        enPlayer playerTurn = enPlayer.Player1;
        enWinner winner=enWinner.Player1;
        private void PaintWallpaper(object sender, PaintEventArgs e)
        {
            Color White = Color.FromArgb(255,255,255,255);
            Pen pen = new Pen(White);

            pen.Width = 10;
            pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;

            e.Graphics.DrawLine(pen,500,100,500,350);
            e.Graphics.DrawLine(pen, 600, 100, 600, 350);
            e.Graphics.DrawLine(pen, 400,182,700,182);
            e.Graphics.DrawLine(pen, 400, 273, 700, 273);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lblPlayerTurn.Text = "Player 1";
            lblPlayerWinner.Text = "Processing";
        }

       private bool CheckValue(PictureBox pbox1, PictureBox pbox2,PictureBox pbox3)
        {
            GameResult.Player1Score += 0;
            GameResult.Player2Score += 0;
            if((pbox1.Tag.ToString()==pbox2.Tag.ToString())&&
                (pbox2.Tag.ToString()==pbox3.Tag.ToString())&&
                (pbox1.Tag!="?".ToString()))
             {
               
                pbox1.BackColor = Color.Green;
                pbox2.BackColor = Color.Green;
                pbox3.BackColor = Color.Green;
                switch (winner)
                {
                    case enWinner.Player1:

                        
                        GameResult.Player1Score++;
                        lblPlayer1Score.Text = GameResult.Player1Score.ToString();
                        lblPlayerWinner.Text = "Player 1 Winner";
                      
                        return true;
                       
                        
                    case enWinner.Player2:

                        
                        GameResult.Player2Score++;
                        lblPlayer2Score.Text = GameResult.Player2Score.ToString();
                        lblPlayerWinner.Text = "Player 2 Winner";
                        return true;
                       

                    case enWinner.Draw:
                        lblPlayerWinner.Text = "No Winner Draw";
                        return true;
                       

                }
                
             }
            return false; ;
        }

        void CheckWinner()
        {
            if(CheckValue(pbBox1,pbBox2,pbBox3))
                return;
            else if (CheckValue(pbBox4, pbBox5, pbBox6))
                return;
            else if (CheckValue(pbBox7, pbBox8, pbBox9))
                return;
            else if (CheckValue(pbBox1, pbBox4, pbBox7))
                return;
            else if (CheckValue(pbBox2, pbBox5, pbBox8))
                return;
            else if(CheckValue(pbBox3, pbBox6, pbBox9))
                return;
            else if (CheckValue(pbBox1, pbBox5, pbBox9))
                return;
            else if (CheckValue(pbBox7, pbBox5, pbBox3))
                return;
        }

        void Reset(PictureBox pbox)
        {
            pbox.Image = Resources.pngwing_com__2_;
            pbox.BackColor = Color.Transparent;
            pbox.Tag = "?".ToString();
            lblPlayerTurn.Text = "Player 1";
            lblPlayerWinner.Text = "Processing";
            
        }
        void End()
        {
            Reset(pbBox1);
            Reset(pbBox2);
            Reset(pbBox3);
            Reset(pbBox4);
            Reset(pbBox5);
            Reset(pbBox6);
            Reset(pbBox7);
            Reset(pbBox8);
            Reset(pbBox9);
            
        }
        public int x = 0;
       public void PboxClick(PictureBox pbox)
        {
            
                x++;
                if (x == 9)
                {
                    MessageBox.Show("Draw!😑", "!!", MessageBoxButtons.OK);
                    End();
                    return;
                }
                
            
           
            if (pbox.Tag.ToString() == "?")
            {
                switch (playerTurn)
                {
                    case enPlayer.Player1:
                        pbox.Image = Resources.pngwing_com__1_;
                        pbox.Tag = "X".ToString();
                        playerTurn = enPlayer.Player2;
                        lblPlayerTurn.Text = "Player 2";
                        winner = enWinner.Player1;
                        GameResult.GameScore++;
                        CheckWinner();
                        break;
                    case enPlayer.Player2:
                        pbox.Image = Resources.pngwing_com;
                        pbox.Tag = "O".ToString();
                        playerTurn = enPlayer.Player1;
                        winner = enWinner.Player2;
                        lblPlayerTurn.Text = "Player 1";
                        GameResult.GameScore++;
                        CheckWinner();
                        break;
                }
                
            }else
            {
                MessageBox.Show("Change Your Choice", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
           
        }

        private void pbBox_Click(object sender, EventArgs e)
        {
            PboxClick((PictureBox)sender);
        }

       

        private void lblRestartGame_Click(object sender, EventArgs e)
        {
            End();
            GameResult. GameScore = 1;
        }

        private void label6_Click(object sender, EventArgs e)
        {
            GameResult.Player1Score = 0;
            GameResult.Player2Score = 0;
            lblPlayer1Score.Text=GameResult.Player1Score.ToString();
            lblPlayer2Score.Text=GameResult.Player2Score.ToString();
        }
    }
}
