using System;
using System.Windows.Forms;
using TagGame.src;

namespace TagGame
{
    public partial class Form1 : Form
    {
        Game game;

        public Form1()
        {
            InitializeComponent();
            game = new Game(4);

        }
        //метод возращает кнопку которая находится на текущей позиции
        private Button button(int pos) {
            //получение всех кнопок из формы
            foreach (Control b in tableLayoutPanel1.Controls) {

                if (b is Button) {
                    
                    if (Convert.ToInt16(b.Tag) == pos) {
                        return (Button)b;
                    }

                }
            }

            return null;
        }     

        private void button0_Click(object sender, EventArgs e)
        {
            game.move(Convert.ToInt16(((Button)sender).Tag));
            update();
        }

        private void start_menuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            game.start();
            game.random();
            update();           
        }

        private void update() {

            for (int i = 0; i < 16; i++)
            {
                int gn = game.getNumber(i);
                button(i).Text = gn.ToString();
                button(i).Visible = (gn > 0);
            }

        }
    }
}
