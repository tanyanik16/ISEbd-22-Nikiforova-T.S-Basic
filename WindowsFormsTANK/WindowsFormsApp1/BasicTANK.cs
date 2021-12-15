using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace WindowsFormsTANK
{
    public class BasicTANK : Vehicle, IEquatable<BasicTANK>
    {
        /// <summary>
        /// Ширина отрисовки автомобиля
        /// </summary>
        protected readonly int TankWidth = 205;
        /// <summary>
        /// Высота отрисовки автомобиля
        /// </summary>
        protected readonly int TankHeight = 95;
        /// <summary>
        /// Разделитель для записи информации по объекту в файл
        /// </summary>
        protected readonly char separator = ';';
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="maxSpeed">Максимальная скорость</param>
        /// <param name="weight">Вес автомобиля</param>
        /// <param name="mainColor">Основной цвет кузова</param>
        public BasicTANK(int maxSpeed, float weight, Color mainColor)
        {
            MaxSpeed = maxSpeed;
            Weight = weight;
            MainColor = mainColor;
        }
        /// <summary>
        /// Конструктор для загрузки с файла
        /// </summary>
        /// <param name="info">Информация по объекту</param>
        public BasicTANK(string info)
        {
            string[] strs = info.Split(separator);
            if (strs.Length == 3)
            {
                MaxSpeed = Convert.ToInt32(strs[0]);
                Weight = Convert.ToInt32(strs[1]);
                MainColor = Color.FromName(strs[2]);
            }
        }
        protected BasicTANK(int maxSpeed, float weight, Color mainColor, int TankWidth, int TankHeight)
        {
            MaxSpeed = maxSpeed;
            Weight = weight;
            MainColor = mainColor;
            this.TankWidth = TankWidth;
            this.TankHeight = TankHeight;
        }
        public override void MoveTransport(Direction direction)
        {
            float step = MaxSpeed * 100 / Weight;
            switch (direction)
            {
                case Direction.Right:
                    if (_startPosX + step < _pictureWidth - TankWidth)
                    {
                        _startPosX += step;
                    }
                    break;
                //влево
                case Direction.Left:
                    if (_startPosX - step > 0) // ??
                    {
                        _startPosX -= step;
                    }
                    break;
                //вверх
                case Direction.Up:
                    if (_startPosY - step > 0) // ?? 
                    {
                        _startPosY -= step;
                    }
                    break;
                //вниз
                case Direction.Down:
                    if (_startPosY + step < _pictureHeight - TankHeight)
                    {
                        _startPosY += step;
                    }
                    break;
            }
        }
        public override void DrawTransport(Graphics g)
        {
            Pen pen = new Pen(Color.Black);

            //прямоугльники
            Brush br = new SolidBrush(MainColor);
            g.DrawRectangle(pen, _startPosX + 80, _startPosY + 10, 60, 20);
            g.DrawRectangle(pen, _startPosX + 40, _startPosY + 30, 150, 20);
            g.FillRectangle(br, _startPosX + 40, _startPosY + 30, 149, 19);
            g.FillRectangle(br, _startPosX + 80, _startPosY + 10, 59, 19);

            //колеса
            Brush brYellow = new SolidBrush(Color.Yellow);
            g.DrawEllipse(pen, _startPosX + 40, _startPosY + 60, 20, 20);
            g.DrawEllipse(pen, _startPosX + 75, _startPosY + 70, 10, 10);
            g.DrawEllipse(pen, _startPosX + 95, _startPosY + 70, 10, 10);
            g.DrawEllipse(pen, _startPosX + 115, _startPosY + 70, 10, 10);
            g.DrawEllipse(pen, _startPosX + 135, _startPosY + 70, 10, 10);
            g.DrawEllipse(pen, _startPosX + 170, _startPosY + 60, 20, 20);
            //гусеница

            g.DrawEllipse(pen, _startPosX + 30, _startPosY + 50, 170, 40);
            g.DrawEllipse(pen, _startPosX + 25, _startPosY + 45, 180, 50);
        }
        public override string ToString()
        {
            return $"{MaxSpeed}{separator}{Weight}{separator}{MainColor.Name}";
        }
        public bool Equals(BasicTANK other)
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
            if (!(obj is BasicTANK TankObj))
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

   
