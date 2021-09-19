using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsTANK
{
    public class TANK
    {
        /// <summary>
        /// Левая координата отрисовки автомобиля
        /// </summary>
        private float _startPosX;
        /// <summary>
        /// Правая кооридната отрисовки автомобиля
        /// </summary>
        private float _startPosY;
        /// <summary>
        /// Ширина окна отрисовки
        /// </summary>
        private int _pictureWidth;
        /// <summary>
        /// Высота окна отрисовки
        /// </summary>
        private int _pictureHeight;
        /// <summary>
        /// Ширина отрисовки автомобиля
        /// </summary>
         private readonly int carWidth = 205;
        /// <summary>
        /// Высота отрисовки автомобиля
        /// </summary>
        private readonly int carHeight = 85;
        /// <summary>
        /// Максимальная скорость
        /// </summary>
        public int MaxSpeed { private set; get; }
        /// <summary>
        /// Вес автомобиля
        /// </summary>
        public float Weight { private set; get; }
        /// <summary>
        /// Основной цвет кузова
        /// </summary>
        public Color MainColor { private set; get; }
        /// <summary>
        /// Дополнительный цвет
        /// </summary>
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
        public void Init(int maxSpeed, float weight, Color mainColor, Color dopColor,
       bool frontSpoiler, bool sideSpoiler, bool backSpoiler, bool sportLine)
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
        /// Установка позиции автомобиля
        /// </summary>
        /// <param name="x">Координата X</param>
        /// <param name="y">Координата Y</param>
        /// <param name="width">Ширина картинки</param>
        /// <param name="height">Высота картинки</param>
        public void SetPosition(int x, int y, int width, int height)
        {
            _startPosX = x;
            _startPosY = y;
            _pictureHeight = height;
            _pictureWidth = width;
            // Продумать логику
        }
        /// <summary>
        /// Изменение направления пермещения
        /// </summary>
        /// <param name="direction">Направление</param>
        public void MoveTransport(Direction direction)
        {
            float step = MaxSpeed * 100 / Weight;
            switch (direction)
            {
                // вправо
                case Direction.Right:
                    if (_startPosX + step < _pictureWidth - carWidth - 90)
                    {
                        _startPosX += step;
                    }
                    break;
                //влево
                case Direction.Left:
                    if (_startPosX - step < _pictureWidth - carWidth) // ??
                    {
                        if(_startPosX > 0)
                        _startPosX -= step;
                    }
                    break;
                //вверх
                case Direction.Up:
                    if (_startPosY - step < _pictureHeight - carHeight ) // ?? 
                    {
                        if(_startPosY > -50)
                        _startPosY -= step;
                    }
                    break;
                //вниз
                case Direction.Down:
                    if (_startPosY + step < _pictureHeight - carHeight - 100)
                    {
                        _startPosY += step;
                    }
                    break;
            }
        }

        /// <summary>
        /// Отрисовка автомобиля
        /// </summary>
        /// <param name="g"></param>
        public void DrawTransport(Graphics g)
        {
            Pen pen = new Pen(Color.Black);
            // отрисуем сперва передний спойлер автомобиля (чтобы потом отрисовка
            //автомобиля на него "легла")
            if (FrontSpoiler)
            {
                //прямоугльники
                Brush br = new SolidBrush(Color.Black);
                g.DrawRectangle(pen, _startPosX + 80, _startPosY + 80, 60, 20);
                g.DrawRectangle(pen, _startPosX + 40, _startPosY + 100, 150, 20);
                g.FillRectangle(br, _startPosX + 40, _startPosY + 100, 149, 19);
                g.FillRectangle(br, _startPosX + 80, _startPosY + 80, 59, 19);

            }

            //колеса
            Brush brYellow = new SolidBrush(Color.Yellow);
            g.DrawEllipse(pen, _startPosX + 40, _startPosY + 130, 20, 20);
            g.DrawEllipse(pen, _startPosX + 75, _startPosY + 140, 10, 10);
            g.DrawEllipse(pen, _startPosX + 95, _startPosY + 140, 10, 10);
            g.DrawEllipse(pen, _startPosX + 115, _startPosY + 140, 10, 10);
            g.DrawEllipse(pen, _startPosX + 135, _startPosY + 140, 10, 10);
            g.DrawEllipse(pen, _startPosX + 170, _startPosY + 130, 20, 20);
            //гусеница

            g.DrawEllipse(pen, _startPosX + 30, _startPosY + 120, 170, 40);
            g.DrawEllipse(pen, _startPosX + 25, _startPosY + 115, 180, 50);
            //дуло
            Brush dulo = new SolidBrush(Color.Green);
            g.FillRectangle(dulo, _startPosX + 140, _startPosY + 85, 80, 10);

            // люк
            Brush luk = new SolidBrush(Color.Blue);
            g.FillRectangle(luk, _startPosX + 100, _startPosY + 70, 20, 10);
        }
        public void resize(int height, int width)
        {
            _pictureHeight = height;
            _pictureWidth = width;
        }
    }
}

