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
    public partial class FormTankConfig : Form
    {
        /// <summary>
        /// Переменная-выбранная машина
        /// </summary>
        Vehicle tank = null;
        /// <summary>
        /// Событие
        /// </summary>
        private event Action <Vehicle> eventAddTank;
        public FormTankConfig()
        {
            InitializeComponent();
            buttonCancel.Click += (object sender, EventArgs e) => { Close(); };
            this.panelDark.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelColor_MouseDown);
            this.panel2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelColor_MouseDown);
            this.panel3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelColor_MouseDown);
            this.panel4.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelColor_MouseDown);
            this.panel5.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelColor_MouseDown);
            this.panel6.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelColor_MouseDown);
            this.panel7.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelColor_MouseDown);
            this.panel8.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelColor_MouseDown);
        }
        /// <summary>
        /// Отрисовать танк
        /// </summary>
        private void DrawTank()
        {
            if (tank != null)
            {
                Bitmap bmp = new Bitmap(pictureBoxOtobrTank.Width, pictureBoxOtobrTank.Height);
                Graphics gr = Graphics.FromImage(bmp);
                tank.SetPosition(5, 5, pictureBoxOtobrTank.Width, pictureBoxOtobrTank.Height);
                tank.DrawTransport(gr);
                pictureBoxOtobrTank.Image = bmp;
            }
        }
        /// <summary>
        /// Добавление события
        /// </summary>
        /// <param name="ev"></param>
        public void AddEvent(Action<Vehicle> ev)
        {
            if (eventAddTank == null)
            {
                eventAddTank = new Action<Vehicle>(ev);
            }
            else
            {
                eventAddTank += ev;
            }

        }
        /// <summary>
        /// Передаем информацию при нажатии на обычный танк
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void labelTank_MouseDown(object sender, MouseEventArgs e)
        {
            ObTank.DoDragDrop(ObTank.Text, DragDropEffects.Move |DragDropEffects.Copy);
        }
        /// <summary>
        /// Передаем информацию при нажатии на модиф.танк
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        private void labelModTank_MouseDown(object sender, MouseEventArgs e)
        {
            ModTank.DoDragDrop(ModTank.Text, DragDropEffects.Move |DragDropEffects.Copy);
        }
        /// <summary>
        /// Проверка получаемой информации (ее типа на соответствие требуемому)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panelTank_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }
        /// <summary>
        /// Действия при приеме перетаскиваемой информации
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panelTank_DragDrop(object sender, DragEventArgs e)
        {
            switch (e.Data.GetData(DataFormats.Text).ToString())
            {
                case "Обычный танк":
                    tank = new BasicTANK ((int)numericUpDownMAX.Value, (int)numericUpDownVES.Value, Color.White); 
                    break;
                case "Модифицированнный танк":
                    tank = new TANK((int)numericUpDownMAX.Value, (int)numericUpDownVES.Value, Color.White, Color.Black,
true, true, checkBoxDulo.Checked, checkBoxlyk.Checked);
                    break;
            }
            DrawTank();
        }
        /// <summary>
        /// Отправляем цвет с панели
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panelColor_MouseDown(object sender, MouseEventArgs e)
        {
            Color color = (sender as Panel).BackColor;
            (sender as Panel).DoDragDrop(color, DragDropEffects.Move | DragDropEffects.Copy);
        }
        /// <summary>
        /// Проверка получаемой информации (ее типа на соответствие требуемому)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void labelBaseColor_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(Color)))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }
        /// <summary>
        /// Принимаем основной цвет
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void labelBaseColor_DragDrop(object sender, DragEventArgs e)
        {
            tank.SetMainColor((Color)e.Data.GetData(typeof(Color)));
            DrawTank();
        }
        /// <summary>
        /// Принимаем дополнительный цвет
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void labelDopColor_DragDrop(object sender, DragEventArgs e)
        {
            if (tank is TANK)
            {
                (tank as TANK ).SetDopColor((Color)e.Data.GetData(typeof(Color)));
                DrawTank();
            }
        }
        /// <summary>
        /// Добавление машины
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonOk_Click(object sender, EventArgs e)
        {
            eventAddTank?.Invoke(tank);
            Close();
        }

       
    }
}

