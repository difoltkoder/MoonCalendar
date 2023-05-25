using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Policy;
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
using System.Net;
using System.Net.Http;
using System.Drawing;
using Flurl;

namespace mooncalendar
{
    /// <summary>
    /// Логика взаимодействия для Page3.xaml
    /// </summary>
    public partial class Page3 : Page
    {
        public Page3()
        {
            InitializeComponent();
           



        }
        
        private void randomize() 
        {
            Random random = new Random();
            BitmapImage bitmap = new BitmapImage();
            int temp= random.Next(0,4);
          
            switch (temp)
            {
                case 0:
                    Solutiontoday.Text = "сегодня всё хорошо";
                    
                    bitmap.BeginInit();
                    bitmap.UriSource = new Uri("https://www.astrocentr.ru/img/gadaniya/gadaniya_online/gadanie_st/stratagema_33.jpg");
                    bitmap.EndInit();
                    RandomImage.Source = bitmap;
                    RandomImage.Width= 300;
                    RandomImage.Height= 150; 

                    break;
                case 1:
                    Solutiontoday.Text = "сегодня всё не очень хорошо";
                    bitmap.BeginInit();
                    bitmap.UriSource = new Uri("https://www.astrocentr.ru/img/gadaniya/gadaniya_online/gadanie_st/stratagema_20.jpg");
                    bitmap.EndInit();
                    RandomImage.Source = bitmap;
                    break;
                case 2:
                    Solutiontoday.Text = "сегодня ничего не получиться";
                    bitmap.BeginInit();
                    bitmap.UriSource = new Uri("https://www.astrocentr.ru/img/gadaniya/gadaniya_online/gadanie_st/stratagema_21.jpg");
                    bitmap.EndInit();
                    RandomImage.Source = bitmap;
                    break;
                case 3:
                    Solutiontoday.Text = "лучше побыть дома и ни куда не ходить";
                    bitmap.BeginInit();
                    bitmap.UriSource = new Uri("https://www.astrocentr.ru/img/gadaniya/gadaniya_online/gadanie_st/stratagema_30.jpg");
                    bitmap.EndInit();
                    RandomImage.Source = bitmap;
                    break;

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            randomize();
        }
    }
}
