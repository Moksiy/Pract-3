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
        public int Tops { get; set; }
        public double S { get; set; }
        public double P { get; set; }
    }

    public class Data
    {
        public string FileName { get; set; }
        public List<int> Coord = new List<int>();
        public List<List<int>> list = new List<List<int>>();
        public void AddCoordinates(int x)
        {
            list.Add(new List<int>(x));
        }
        List<Information> result = new List<Information>();
    }

    public partial class MainWindow : Window
    {
        Data data = new Data();

        public MainWindow()
        {
            InitializeComponent();
        }

        //Обработчик на открытие диалогового окна
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

        //Обработчик считывания и вывода информации
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (data.FileName != null)
            {
                Reader();
            }else { MessageBox.Show("Не выбран файл"); }
        }

        //Считывание
        private void Reader()
        {
            string x;
            int i = 1;
            StreamReader reader = File.OpenText(data.FileName);
            string input;
            while ((input = reader.ReadLine()) != null)
            {
                foreach (var st in input.Split())
                {
                    x = st;
                    data.AddCoordinates(Convert.ToInt32(x));
                }
            }
        }
    }
}
