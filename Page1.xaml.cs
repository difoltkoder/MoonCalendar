using System;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Innovative.SolarCalculator;
using System.Windows.Controls;
using System.IO;
using System.Windows;
using System.Net;
using System.Globalization;
using System.Runtime.InteropServices.ComTypes;
/*
1) вывод какая луна
2)сделать норм закат рассвет
 */
namespace mooncalendar
{
    /// <summary>
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        private static string urlzakat = "https://my-calend.ru/moon/may";
        private static string UrlSite = "https://calendar.yoip.ru/lunar/today-moon-phase.html";
       
        public static string s = GetHtmlPageText(urlzakat);
        public static string s1 = GetHtmlPageText(UrlSite);

        private static string rus_str = "↑↓:аАбБвВгГдДеЕёЁжЖзЗиИйЙкКлЛмМнНоОпПрРсСтТуУфФхЧцЦчЧшШщЩьыъэЭюЮяЯ1234567890";
        private static string rus_str2 = "<аАбБвВгГдДеЕёЁжЖзЗиИйЙкКлЛмМнНоОпПрРсСтТуУфФхЧцЦчЧшШщЩьыъэЭюЮяЯ1234567890";

        public static string LocalLang = string.Join("", s.Where(c => rus_str.Contains(c.ToString())));
        public static string znaktoday = string.Join("", s1.Where(c => rus_str2.Contains(c.ToString())));


        //ПРОМТ ДЕНЬМАСЯЦДЕНЬНЕДЕЛИ Посмотреть
        public Page1()
        {
            InitializeComponent();
            Datanow();
            stroki();


          
            

        }

        private void UnSetVisible() 
        {
            phaze1.Visibility = Visibility.Hidden;
            phaze2.Visibility = Visibility.Hidden;
            phaze3.Visibility = Visibility.Hidden;
            phaze4.Visibility = Visibility.Hidden;
            phaze5.Visibility = Visibility.Hidden;
            phaze6.Visibility = Visibility.Hidden;
            phaze7.Visibility = Visibility.Hidden;
            phaze8.Visibility = Visibility.Hidden;
        }

        private void Datanow()
        {
            DateTime DateInDatePicker = DateTime.Now;
            datepicker.Text = DateInDatePicker.ToString();
        }

        private void OnCalendarOpened(object sender, RoutedEventArgs e)
        {
            //datepicker.SelectedDate = DateTime.Now.Date;
        }

        private void OnSelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {

            DateTime ? date = datepicker.SelectedDate;
            
            
            string fwe=date.ToString();
            DateTime setdata= DateTime.Parse(fwe);

           

            fwe = $"{setdata.Day}<{setdata.ToString("MMMM", new CultureInfo("ru-RU")).Replace('й', 'я')}";
            string fwr = $"{setdata.Day}{setdata.ToString("MMMM", new CultureInfo("ru-RU")).Replace('й', 'я').ToLower()}{setdata.ToString("ddd").ToLower()}";
            string ZnakZodiaka = getBetween(znaktoday, fwe, "<<<<<");//основной промт
            string fweflk = getBetween(LocalLang,fwr, "Взнаке");
            string rus_str3 = "<:1234567890↓↑";
            string wefwe = string.Join("", fweflk.Where(c => rus_str3.Contains(c.ToString())));


            string Warinng = getBetween("<"+ fweflk, "<", "лунный");
            if (Warinng.Length == 4)
            {

                Warinng = Warinng.Substring(2);
                Warinng = Warinng.Insert(1, " ");

                Warning1.Text = Warinng;
            }

            if (Warinng.Length == 5)
            {
                Warinng = Warinng.Substring(2);
                Warinng = Warinng.Insert(1, " ");

                Warning1.Text = Warinng;
            }

            if (Warinng.Length == 6)
            {
                Warinng = Warinng.Substring(2);
                Warinng = Warinng.Insert(2, " ");
                Warning1.Text = Warinng;
            }

            if (Warinng.Length == 7)
            {
                Warinng = Warinng.Substring(2);
                Warinng = Warinng.Insert(2, " ");
                Warinng = Warinng.Insert(5, " ");
                Warning1.Text = Warinng;
            }



            string TimeToStart = getBetween(wefwe, "↓", "↑");
            string TimeToEnd = getBetween(wefwe + "<", "↑", "<");

            string ZnakZodiaka2 = getBetween(ZnakZodiaka + "<<<<<", "<<", "<<<<<");
            string ZnakZodiaka3 = getBetween(ZnakZodiaka2 + "<<<<<", "<<", "<<<<<");
            string ZnakZodiaka4 = getBetween(ZnakZodiaka3 + "<<<<<", "<<", "<<<<<");
            string ZnakZodiakaMain = getBetween(ZnakZodiaka4 + "<<<<<", "<<", "<<");
           
            lunnZnak.Text = ZnakZodiakaMain;
            if (TimeToEnd.Length == 10)
            {
                TimeToStart = getBetween("<" + TimeToEnd, "<", "↓");
                voshod.Text = "Восход\n" + TimeToStart;
                TimeToEnd = getBetween(TimeToEnd+ "<", "↓", "<");
                zakat.Text = "Закат\n" + TimeToEnd;
            }
            else
            {
                voshod.Text = "Восход\n" + TimeToStart;
                zakat.Text = "Закат\n" + TimeToEnd;
            }


            GetSelektedDate(date);
        }

        private void GetSelektedDate(DateTime? date) 
        {
            string str=date.ToString();
            DateTime enteredDate = DateTime.Parse(str);
            MoonPosit(enteredDate.Year, enteredDate.Month, enteredDate.Day);
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string PathToZametki = "C:\\zametki.txt";
            TextWriter txt = new StreamWriter(PathToZametki);

            txt.Write(zametki.Text+"\n");
            txt.Close();
        }

        private void MoonPosit(int year, int month, int day)
        {

            double ag; // Moon's age
            double di; // Moon's distance in earth radius
            double la; // Moon's ecliptic latitude
            double lo; // Moon's ecliptic longitude
            string phase;
            int yy, mm, k1, k2, k3, jd;
            double ip, dp, np, rp;

            //Calculate the Julian date at 12h UT
            yy = year - (int)Math.Floor((12.0 - month) / 10.0);
            mm = month + 9;

            if (mm >= 12)
            {
                mm = mm - 12;
            }

            k1 = (int)Math.Floor(365.25 * (yy + 4712.0));
            k2 = (int)Math.Floor(30.6 * mm + 0.5);
            k3 = (int)Math.Floor(((yy / 100.0) + 49.0) * 0.75) - 38;
            jd = k1 + k2 + day + 59;

            if (jd > 2299160)
            {
                jd = jd - k3;
            }

            //Calculate moon's age in days
            ip = Normalize((jd - 2451550.1) / 29.530588853);
            ag = ip * 29.53;
            phase = MoonPhaseCalc(ag);
            ip = ip * 2 * Math.PI;
            //Calculate moon's distance
            dp = 2 * Math.PI * Normalize((jd - 2451562.2) / 27.55454988);
            di = 60.4 - 3.3 * Math.Cos(dp) - 0.6 * Math.Cos(2 * ip - dp) - 0.5 * Math.Cos(2 * ip);
            //Calculate moon's ecliptic latitude
            np = 2 * Math.PI * Normalize((jd - 2451565.2) / 27.212220817);
            la = 5.1 * Math.Sin(np);
            //calculate moon's ecliptic longitude
            rp = Normalize((jd - 2451555.8) / 27.321582241);
            lo = 360 * rp + 6.3 * Math.Sin(dp) + 1.3 * Math.Sin(2 * ip - dp) + 0.7 * Math.Sin(2 * ip);
            
        }


        string MoonPhaseCalc(double ag)
        {
            string phase;
            UnSetVisible();

            if (ag < 1.84566)
            {
                phaze1.Visibility = Visibility;
                phase = "Новая Луна";
                fazamoon.Text = $"Фаза луны \n {phase}";
                return phase;
            }

            if (ag < 5.53699)
            {
                phaze2.Visibility = Visibility; 
                phase = "Восковой полумесяц";
                fazamoon.Text = $"Фаза луны \n {phase}";
                return phase;
            }

            if (ag < 9.22831)
            {
                phaze3.Visibility = Visibility;
                phase = "Первый квартал";
                fazamoon.Text = $"Фаза луны \n {phase}";
                return phase;
            }

            if (ag < 12.91963)
            {
                phaze4.Visibility = Visibility;          
                phase = "Растущая Луна";
                fazamoon.Text = $"Фаза луны \n {phase}";
                return phase;
            }

            if (ag < 16.61096)
            {
                phaze5.Visibility = Visibility;
                phase = "Полная луна";
                fazamoon.Text = $"Фаза луны \n {phase}";
                return phase;
            }

            if (ag < 20.30228)
            {
                phaze6.Visibility = Visibility;
                phase = "Убывающая луна";
                fazamoon.Text = $"Фаза луны \n {phase}";
                return phase;
            }

            if (ag < 23.99361)
            {
                phaze7.Visibility = Visibility;
                phase = "последний квартал";
                fazamoon.Text = $"Фаза луны \n {phase}";
                return phase;
            }

            if (ag < 27.68493)
            {
                phaze8.Visibility = Visibility;
                phase = "Убывающий полумесяц";
                fazamoon.Text = $"Фаза луны \n {phase}";
                return phase;
            }

            phaze1.Visibility = Visibility;
            phase = "Новая Луна";
            fazamoon.Text = $"Фаза луны \n {phase}";
            return phase;
        }

        static double Normalize(double v)
        {
            v = v - Math.Floor(v);
            if (v < 0)
            {
                v = v + 1;
            }
            return v;
        }
        
           


            public void stroki()//запись в текстовый
            {
                string PathToZametki = "C:\\zametki2.txt";
                TextWriter txt = new StreamWriter(PathToZametki);
                txt.Write(LocalLang);
                txt.Close();
            }

            //поиск от момента до момента в строке
            public static string getBetween(string strSource, string strStart, string strEnd)
        {
            try
            {
                if (strSource.Contains(strStart) && strSource.Contains(strEnd))
                {
                    int Start, End;
                    Start = strSource.IndexOf(strStart, 0) + strStart.Length;
                    End = strSource.IndexOf(strEnd, Start);
                    return strSource.Substring(Start, End - Start);
                }
            }
            catch { return "";}
                return "";
            }

            //парсинг
            private static string GetHtmlPageText(string url)
            {
                string txt = String.Empty;
                WebRequest req = WebRequest.Create(url);
                WebResponse resp = req.GetResponse();
                using (Stream stream = resp.GetResponseStream())
                {
                    using (StreamReader sr = new StreamReader(stream))
                    {
                        txt = sr.ReadToEnd();
                    }
                }

                return txt;
            }
        
    }
    
}
