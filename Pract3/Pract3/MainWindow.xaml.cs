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

    public class Coordinate
    {
        int X { get; set; }
        int Y { get; set; }
    }

    public class Information
    {
        int Tops { get; set; }
        double S { get; set; }
        double P { get; set; }
    }

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //Обработчик на открытие диалогового окна
        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
