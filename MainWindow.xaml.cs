using System;
using System.Collections.Generic;
using System.Globalization;
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
using System.Windows.Media.Animation;
using System.Windows.Shapes;

using static System.Net.Mime.MediaTypeNames;

namespace mooncalendar
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();

            DoubleAnimation btnAnimation=new DoubleAnimation();
            btnAnimation.From= 0;
            btnAnimation.To= 585;
            btnAnimation.Duration=TimeSpan.FromSeconds(3);
            TextBox12.BeginAnimation(TextBox.WidthProperty, btnAnimation);


        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            Myframe.Content = new Page4();
            TextBox12.Text = " ";
        }

        private void Calendar_Click(object sender, RoutedEventArgs e)
        {
            Myframe.Content = new Page1();
            TextBox12.Text = " ";
        }

        private void Zametki_Click(object sender, RoutedEventArgs e)
        {
            Myframe.Content = new Page2();
            TextBox12.Text = " ";
        }

        private void Randomazer_Click(object sender, RoutedEventArgs e)
        {
            Myframe.Content = new Page3();
            TextBox12.Text = " ";
        }
    }
}
