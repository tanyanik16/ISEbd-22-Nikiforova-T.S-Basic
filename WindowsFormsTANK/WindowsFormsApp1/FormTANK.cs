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
        private TANK Tank = new TANK();
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

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Обработка нажатия кнопки "Создать"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void Create_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            Tank = new TANK();
            Tank.Init(rnd.Next(100, 300), rnd.Next(1000, 2000), Color.Blue,
            Color.Yellow, true, true, true, true); Tank.SetPosition(rnd.Next(10, 100),
            rnd.Next(10, 100), this.Size.Width, this.Size.Height);
            Draw();
        }

        private void FormTANK_Resize(object sender, EventArgs e)
        {
            Tank.resize(this.Size.Height, this.Size.Width);
        }
    }
}
