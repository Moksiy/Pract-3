using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;
using System.IO;

/*
ПП3-2-1 Вывести с помощью ListView информацию о многоугольниках, что описаны в текстовом файле: в
каждой строке указываются координаты всех вершин одного многоугольника. В компоненте должно быть 
три столбца: количество вершин, периметр, площадь. Проверять на то, что многоугольник является 
корректным многоугольником не требуется.
     */
namespace Pract3
{
    /// <summary>
    /// Логика (её нет) взаимодействия для MainWindow.xaml
    /// </summary>

     
    public class Information
    {
        public int[] Coordinates { get; set; }
        public int Tops { get; set; }
        public double S { get; set; }
        public double P { get; set; }
    }

    /// <summary>
    /// Класс со списком и методами для передачи значений
    /// </summary>
    public class Data : Window
    {
        public string FileName { get; set; }
        public int[] Coord;
        public List<Information> list = new List<Information>();
        /// <summary>
        /// Метод заполнения списка
        /// </summary>
        /// <param name="coord">массив координат</param>
        public void AddCoordinates(int[] coord)
        {
            list.Add(new Information());
            list[list.Count - 1].Coordinates = coord;
            list[list.Count - 1].Tops = (coord.Length) / 2;
            list[list.Count - 1].P = CalculateP(list[list.Count - 1].Tops, coord);
            list[list.Count - 1].S = CalculateS(list[list.Count - 1].Tops, coord);
        }

        /// <summary>
        /// Метод расчета периметра
        /// </summary>
        /// <param name="x"> количество пар значений х и у</param>
        /// <param name="coord"> массив значений</param>
        /// <returns></returns>
        private double CalculateP(int x, int[] coord)
        {
            double result = 0;
            if (x == 1)
            {
                MessageBox.Show("Ошибка");
            }
            else
            {
                for (int i = 0; i < (x - 1) * 2; i += 2)
                {
                    result += Linelength(coord[i], coord[i + 1], coord[i + 2], coord[i + 3]);
                }
                result += Linelength(coord[0], coord[1], coord[coord.Length - 2], coord[coord.Length - 1]);
            }
            return result;
        }

        /// <summary>
        /// Метод расчета площади
        /// </summary>
        /// <param name="x">количество пар значений х и у в массиве</param>
        /// <param name="coord">массив значений</param>
        /// <returns></returns>
        private double CalculateS(int x, int[] coord)
        {
            double result = 0;
            if (x == 1 || x == 2)
            {
                MessageBox.Show("Ошибка");
            }
            else
            {
                result = Square(coord);
            }
            return result;
        }

        /// <summary>
        /// Расчет длины стороны
        /// </summary>
        /// <param name="x1">х первой координаты</param>
        /// <param name="y1">у первой координаты</param>
        /// <param name="x2">х второй координаты</param>
        /// <param name="y2">у второй координаты</param>
        /// <returns></returns>
        private double Linelength(int x1, int y1, int x2, int y2)
        {
            double result = Math.Sqrt(Math.Pow((x1 - x2), 2) + Math.Pow((y1 - y2), 2));
            return result;
        }

        /// <summary>
        /// Расчет площади 
        /// </summary>
        /// <param name="coord">массив значений</param>
        /// <returns></returns>
        private double Square(int[] coord)
        {
            double result = 0;
            if (coord.Length / 2 > 3)
            {
                result = (SumCoord(coord) + (coord[coord.Length - 2] * coord[1]) - DiffCoord(coord) - (coord[0] * coord[coord.Length - 1])) / 2;
            }
            else { result = ((coord[0] - coord[4]) * (coord[3] - coord[5]) - (coord[2] - coord[4]) * (coord[1] - coord[5])) / 2; }
            return Math.Abs(result);
        }

        /// <summary>
        /// Сумма множителей
        /// </summary>
        /// <param name="coord"> массив значений</param>
        /// <returns></returns>
        private double SumCoord(int[] coord)
        {
            double res = 0;
            int count = coord.Length;
            for (int i = 0; i < count - 2; i += 2)
            {
                res += (coord[i] * coord[i + 3]);
            }
            return res;
        }

        /// <summary>
        /// Разность множителей
        /// </summary>
        /// <param name="coord">массив значений</param>
        /// <returns></returns>
        private double DiffCoord(int[] coord)
        {
            double res = 0;
            int count = coord.Length;
            for (int i = 1; i < count - 2; i += 2)
            {
                res += (coord[i + 1] * coord[i]);
            }
            return res;
        }

        /// <summary>
        /// Метод возвращающий количество вершин
        /// </summary>
        /// <param name="index">индекс</param>
        /// <returns></returns>
        public int OutputTops(int index)
        {
            return list[index].Tops;
        }

        /// <summary>
        /// Метод возвращающий площадь
        /// </summary>
        /// <param name="index">индекс</param>
        /// <returns></returns>
        public double OutputS(int index)
        {
            return list[index].S;
        }

        /// <summary>
        /// Метод возвращающий периметр
        /// </summary>
        /// <param name="index">индекс</param>
        /// <returns></returns>
        public double OutputP(int index)
        {
            return list[index].P;
        }

        /// <summary>
        /// Метод возвращающий количество элементов в списке
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            return list.Count;
        }
    }

    public partial class MainWindow : Window
    {
        Data data = new Data();

        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Обработчик на открытие диалогового окна
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.Filter = "Text documents (*.txt)|*.txt|All files (*.*)|*.*";
            dialog.FilterIndex = 2;
            Nullable<bool> result = dialog.ShowDialog();
            if (result == true)
            {
                data.FileName = dialog.FileName;
            }
        }

        /// <summary>
        /// Обработчик считывания и вывода информации
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (data.FileName != null)
            {
                Reader();
                OutputList();
            }
            else { MessageBox.Show("Не выбран файл"); }
        }

        /// <summary>
        /// Считывание
        /// </summary>
        private void Reader()
        {
            StreamReader reader = File.OpenText(data.FileName);
            string input;
            while ((input = reader.ReadLine()) != null)
            {
                try
                {
                    int[] coordinates = input.Split(' ').Where(x => !string.IsNullOrWhiteSpace(x)).Select(x => int.Parse(x)).ToArray();
                    data.AddCoordinates(coordinates);
                }
                catch (InvalidCastException)
                {

                }
            }
        }

        /// <summary>
        /// Вывод
        /// </summary>
        public void OutputList()
        {
            for (int i = 0; i < data.Count(); i++)
            {
                Information element = new Information()
                {
                    Tops = data.OutputTops(i),
                    S = data.OutputS(i),
                    P = data.OutputP(i)
                };

                ListV.Items.Add(element);
            }
        }
    }
}
