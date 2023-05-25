using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
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
using System.Xml.Linq;

namespace mooncalendar
{
    /// <summary>
    /// Логика взаимодействия для Page4.xaml
    /// </summary>
    public partial class Page4 : Page
    {
       
        int _year = DateTime.Now.Year;
        int _month = 5;
        int _day = 1;

        public Page4()
        {
            DateTime data = new DateTime(_year, _month, _day);
            int dayOfWeek = (int)data.DayOfWeek;
            int i = 0;
            int day = 1;
            InitializeComponent();

            if (dayOfWeek == 0)
                dayOfWeek = 7;

            for (; i < dayOfWeek - 1; i++)
            {
            }

            for (; day <= DateTime.DaysInMonth(_year, _month); i++)
            {
                if (day == DateTime.Now.Day && _month == DateTime.Now.Month)
                {
                    ((Button)myGrid.Children[i]).Background = System.Windows.Media.Brushes.LightBlue;
                }
                ((Button)myGrid.Children[i]).Content = day++;
            }
        }
    }

    
}