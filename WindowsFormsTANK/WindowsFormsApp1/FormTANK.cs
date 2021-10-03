using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsTANK
{
    public partial class FormTANK : Form
    {
        private BasicTANK Tank ;
        public FormTANK()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Метод отрисовки машины
        /// </summary>
        private void Draw()
        {
            Bitmap bmp = new Bitmap(pictureBoxTank.Width, pictureBoxTank.Height);
            Graphics gr = Graphics.FromImage(bmp);
            Tank.DrawTransport(gr);
            pictureBoxTank.Image = bmp;
        }

        /// <summary>
        /// Обработка нажатия кнопок управления
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonMove_Click(object sender, EventArgs e)
        {
            //получаем имя кнопки
            string name = (sender as Button).Name;
            switch (name)
            {
                case "buttonUp":
                    Tank.MoveTransport(Direction.Up);
                    break;
                case "buttonDown":
                    Tank.MoveTransport(Direction.Down);
                    break;
                case "buttonLeft":
                    Tank.MoveTransport(Direction.Left);
                    break;
                case "buttonRight":
                    Tank.MoveTransport(Direction.Right);
                    break;
            }
            Draw();
        }

 
        /// <summary>
        /// Обработка нажатия кнопки "Создать"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void Create_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            Tank= new TANK(rnd.Next(100, 300), rnd.Next(1000, 2000), Color.Blue,
            Color.Yellow, true, true, true, true); Tank.SetPosition(rnd.Next(10, 100),
            rnd.Next(10, 100), pictureBoxTank.Width,
pictureBoxTank.Height);
            Draw();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            Tank = new BasicTANK(rnd.Next(100, 300), rnd.Next(1000, 2000), Color.Blue);
            Tank.SetPosition(rnd.Next(10, 100), rnd.Next(10, 100), pictureBoxTank.Width,
pictureBoxTank.Height);
            Draw();
        }
    }
}
