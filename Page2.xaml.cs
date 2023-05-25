using System;
using System.Collections.Generic;
using System.IO;
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


namespace mooncalendar
{
    /// <summary>
    /// Логика взаимодействия для Page2.xaml
    /// </summary>
    public partial class Page2 : Page
    {
        public Page2()
        {
            InitializeComponent();
            try
            {
                TextFromSave1.Text = File.ReadAllText("C:\\zametki.txt");
            }
            catch { }
            try
            {
                TextFromSave2.Text = File.ReadAllText("C:\\zametki4.txt");
            }
            catch { }
            try
            {
                TextFromSave3.Text = File.ReadAllText("C:\\zametki3.txt");
            }
            catch { }
        }


        private void TextFromSave1_TextChanged(object sender, TextChangedEventArgs e)
        {   
            using (StreamWriter sr = new StreamWriter("C:\\zametki.txt"))
            {
                sr.WriteLine(TextFromSave1.Text);
                sr.Close();
            }
        }

        private void TextFromSave2_TextChanged(object sender, TextChangedEventArgs e)
        {
            using (StreamWriter sr = new StreamWriter("C:\\zametki4.txt"))
            {
                sr.WriteLine(TextFromSave2.Text);
                sr.Close();
            }
        }

        private void TextFromSave3_TextChanged(object sender, TextChangedEventArgs e)
        {
            using (StreamWriter sr = new StreamWriter("C:\\zametki3.txt"))
            {
                sr.WriteLine(TextFromSave3.Text);
                sr.Close();
            }
        }
    }
}
