using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsTANK
{
    /// <summary>
    /// Класс отрисовки модифицированнного танка
    /// </summary>
    public class TANK:BasicTANK, IEquatable<TANK>
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
        /// Конструктор для загрузки с файла
        /// </summary>
        /// <param name="info"></param>
        public TANK(string info) : base(info)
        {
            string[] strs = info.Split(separator);
            if (strs.Length == 8)
            {
                MaxSpeed = Convert.ToInt32(strs[0]);
                Weight = Convert.ToInt32(strs[1]);
                MainColor = Color.FromName(strs[2]);
                DopColor = Color.FromName(strs[3]);
                FrontSpoiler = Convert.ToBoolean(strs[4]);
                BackSpoiler = Convert.ToBoolean(strs[5]);
                SideSpoiler = Convert.ToBoolean(strs[6]);
                SportLine = Convert.ToBoolean(strs[7]);
            }
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
                

            }
            Brush bra = new SolidBrush(Color.Black);
            g.FillRectangle(bra, _startPosX + 40, _startPosY + 30, 149, 19);
            g.FillRectangle(bra, _startPosX + 80, _startPosY + 10, 59, 19);
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
            //гусеница
            g.DrawEllipse(pen, _startPosX + 30, _startPosY + 50, 170, 40);
            g.DrawEllipse(pen, _startPosX + 25, _startPosY + 45, 180, 50);
            if (SportLine)
            {
                //дуло
                Brush dulo = new SolidBrush(MainColor);
                g.FillRectangle(dulo, _startPosX + 140, _startPosY + 15, 80, 10);
            }
            if (BackSpoiler)
            {
                //люк
                Brush luk = new SolidBrush(DopColor);
                g.FillRectangle(luk, _startPosX + 100, _startPosY, 20, 10);
                
            }
        }
        /// <summary>
        /// Смена дополнительного цвета
        /// </summary>
        /// <param name="color"></param>
        public void SetDopColor(Color color)
        {
            DopColor = color;
        }
        public override string ToString()
        {
            return
           $"{base.ToString()}{separator}{DopColor.Name}{separator}{FrontSpoiler}{separator}{SideSpoiler}{separator}{BackSpoiler}{ separator}{ SportLine}";
        }
        /// <summary>
        /// Метод интерфейса IEquatable для класса SportCar
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(TANK other)
        {

            if (other == null)
            {
                return false;
            }
            if (GetType().Name != other.GetType().Name)
            {
                return false;
            }
            if (MaxSpeed != other.MaxSpeed)
            {
                return false;
            }
            if (Weight != other.Weight)
            {
                return false;
            }
            if (MainColor != other.MainColor)
            {
                return false;
            }
            if (DopColor != other.DopColor)
            {
                return false;
            }
            if (FrontSpoiler != other.FrontSpoiler)
            {
                return false;
            }
            if (BackSpoiler != other.BackSpoiler)
            {
                return false;
            }
            if (SideSpoiler != other.SideSpoiler)
            {
                return false;
            }
            if (SportLine != other.SportLine)
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// Перегрузка метода от object
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(Object obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (!(obj is TANK TankObj))
            {
                return false;
            }
            else
            {
                return Equals(TankObj);
            }
        }
    }
}

