using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using System.Threading.Tasks;

namespace WindowsFormsTANK
{
    /// <summary>
    /// Класс-коллекция парковок
    /// </summary>
    public class ParkingCollection
    {
        /// <summary>
        /// Словарь (хранилище) с парковками
        /// </summary>
        readonly Dictionary<string, Parking<Vehicle>> parkingStages;
        /// <summary>
        /// Возвращение списка названий праковок
        /// </summary>
        public List<string> Keys => parkingStages.Keys.ToList();
        /// <summary>
        /// Ширина окна отрисовки
        /// </summary>
        private readonly int pictureWidth;
        /// <summary>
        /// Высота окна отрисовки
        /// </summary>
        private readonly int pictureHeight;
        /// <summary>
        /// Разделитель для записи информации в файл
        /// </summary>
        private readonly char separator = ':';
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="pictureWidth"></param>
        /// <param name="pictureHeight"></param>
        public ParkingCollection(int pictureWidth, int pictureHeight)
        {
            parkingStages = new Dictionary<string, Parking<Vehicle>>();
            this.pictureWidth = pictureWidth;
            this.pictureHeight = pictureHeight;
        }
        /// <summary>
        /// Добавление парковки
        /// </summary>
        /// <param name="name">Название парковки</param>
        public void AddParking(string name)
        {
            if (!parkingStages.ContainsKey(name))
            {
                parkingStages.Add(name, new Parking<Vehicle>(pictureWidth, pictureHeight));
            }

        }
        /// <summary>
        /// Удаление парковки
        /// </summary>
        /// <param name="name">Название парковки</param>
        public void DelParking(string name)
        {
            if (parkingStages.ContainsKey(name))
            {
                parkingStages.Remove(name);
            }
        }
        /// <summary>
        /// Доступ к парковке
        /// </summary>
        /// <param name="ind"></param>
        /// <returns></returns>
        public Parking<Vehicle> this[string ind]
        {
            get
            {
                if (parkingStages.ContainsKey(ind))
                {
                    return parkingStages[ind];
                }
                else
                {
                    return null;
                }
            }
        }
        /// <summary>
        /// Метод записи информации в файл
        /// </summary>
        /// <param name="text">Строка, которую следует записать</param>
        /// <param name="stream">Поток для записи</param>
        private void WriteToFile(string text, FileStream stream)
        {
            byte[] info = new UTF8Encoding(true).GetBytes(text);
            stream.Write(info, 0, info.Length);
        }
        /// <summary>
        /// Сохранение информации по автомобилям на парковках в файл
        /// </summary>
        /// <param name="filename">Путь и имя файла</param>
        /// <returns></returns>
        public bool SaveData(string filename)
        {
            if (File.Exists(filename))
            {
                File.Delete(filename);
            }
            using (StreamWriter fs = new StreamWriter(filename))
            {
                fs.WriteLine($"ParkingCollection");
                foreach (var level in parkingStages)
                {
                    //Начинаем парковку
                    fs.WriteLine($"Parking{separator}{level.Key}");
                    ITransport tank = null;
                    for (int i = 0; (tank = level.Value.GetNext(i)) != null; i++)
                    {
                        if (tank != null)
                        {
                            //если место не пустое
                            //Записываем тип машины
                            if (tank.GetType().Name == "BasicTANK")
                            {
                                fs.Write($"BasicTANK{separator}");
                            }
                            if (tank.GetType().Name == "TANK")
                            {
                                fs.Write($"TANK{separator}");
                            }
                            //Записываемые параметры
                            fs.WriteLine(tank);
                        }
                    }
                }
            }
            return true;
        }
        /// <summary>
        /// Загрузка нформации по автомобилям на парковках из файла
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public bool LoadData(string filename)
        {
            if (!File.Exists(filename))
            {
                return false;
            }
            using (StreamReader strs = new StreamReader(filename))
            {
                string line = strs.ReadLine();
                Vehicle tank = null;
                string key = string.Empty;
                if (line.Contains("ParkingCollection"))
                {
                    parkingStages.Clear();
                    line = strs.ReadLine();
                    while (line != null)
                    {
                        if (line.Contains("Parking"))
                        {
                            key = line.Split(separator)[1];
                            parkingStages.Add(key, new Parking<Vehicle>(pictureWidth, pictureHeight));
                            line = strs.ReadLine();
                            continue;
                        }
                        if (string.IsNullOrEmpty(line))
                        {
                            line = strs.ReadLine();
                            continue;
                        }
                        if (line.Split(separator)[0] == "TANK")
                        {
                            tank = new TANK(line.Split(separator)[1]);
                        }
                        else if (line.Split(separator)[0] == "BasicTANK")
                        {
                            tank = new BasicTANK(line.Split(separator)[1]);
                        }
                        var result = parkingStages[key] + tank;
                        if (!result)
                        {
                            return false;
                        }
                        line = strs.ReadLine();
                    }
                    return true;
                }
                return false;
            }

        }
    }
}
