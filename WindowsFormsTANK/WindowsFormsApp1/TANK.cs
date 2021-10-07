using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsTANK
{
    public class TANK:BasicTANK
    {
        public Color DopColor { private set; get; }
        /// <summary>
        /// Признак наличия переднего спойлера
        /// </summary>
        public bool FrontSpoiler { private set; get; }
        /// <summary>
        /// Признак наличия боковых спойлеров
        /// </summary>
        public bool SideSpoiler { private set; get; }
        /// <summary>
        /// Признак наличия заднего спойлера
        /// </summary>
        public bool BackSpoiler { private set; get; }
        /// <summary>
        /// Признак наличия гоночной полосы
        /// </summary>
        public bool SportLine { private set; get; }
        /// <summary>
        /// Инициализация свойств
        /// </summary>
        /// <param name="maxSpeed">Максимальная скорость</param>
        /// <param name="weight">Вес автомобиля</param>
        /// <param name="mainColor">Основной цвет кузова</param>
        /// <param name="dopColor">Дополнительный цвет</param>
        /// <param name="frontSpoiler">Признак наличия переднего спойлера</param>
        /// <param name="sideSpoiler">Признак наличия боковых спойлеров</param>
        /// <param name="backSpoiler">Признак наличия заднего спойлера</param>
        /// <param name="sportLine">Признак наличия гоночной полосы</param>
        public TANK(int maxSpeed, float weight, Color mainColor, Color dopColor,
       bool frontSpoiler, bool sideSpoiler, bool backSpoiler, bool sportLine): base(maxSpeed, weight, mainColor, 205, 95)
        {
            MaxSpeed = maxSpeed;
            Weight = weight;
            MainColor = mainColor;
            DopColor = dopColor;
            FrontSpoiler = frontSpoiler;
            SideSpoiler = sideSpoiler;
            BackSpoiler = backSpoiler;
            SportLine = sportLine;
        }
 
        /// <summary>
        /// Отрисовка автомобиля
        /// </summary>
        /// <param name="g"></param>
        public override void DrawTransport(Graphics g)
        {
            Pen pen = new Pen(Color.Black);

            // отрисуем сперва передний спойлер автомобиля (чтобы потом отрисовка
            //автомобиля на него "легла")
            if (FrontSpoiler)
            {
                //прямоугльники
                Brush br = new SolidBrush(Color.Black);
                g.DrawRectangle(pen, _startPosX + 80, _startPosY + 10, 60, 20);
                g.DrawRectangle(pen, _startPosX + 40, _startPosY + 30, 150, 20);
                g.FillRectangle(br, _startPosX + 40, _startPosY + 30, 149, 19);
                g.FillRectangle(br, _startPosX + 80, _startPosY + 10, 59, 19);

            }
            if (SideSpoiler)
            {
                //колеса
                Brush brYellow = new SolidBrush(Color.Yellow);
                g.DrawEllipse(pen, _startPosX + 40, _startPosY + 60, 20, 20);
                g.DrawEllipse(pen, _startPosX + 75, _startPosY + 70, 10, 10);
                g.DrawEllipse(pen, _startPosX + 95, _startPosY + 70, 10, 10);
                g.DrawEllipse(pen, _startPosX + 115, _startPosY + 70, 10, 10);
                g.DrawEllipse(pen, _startPosX + 135, _startPosY + 70, 10, 10);
                g.DrawEllipse(pen, _startPosX + 170, _startPosY + 60, 20, 20);
            }
            base.DrawTransport(g);
            if (SportLine)
            {
                //гусеница
                g.DrawEllipse(pen, _startPosX + 30, _startPosY + 50, 170, 40);
                g.DrawEllipse(pen, _startPosX + 25, _startPosY + 45, 180, 50);
            }
            
        }
    }
}

