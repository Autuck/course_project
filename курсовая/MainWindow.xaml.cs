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

namespace курсовая
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int numberofquest = 1;
        string s = Environment.CurrentDirectory;
        string goodotvet;
        int otvettrue;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void read(object sender, RoutedEventArgs e)
        {
            worktest.Visibility = Visibility.Collapsed;
            Uri fg = new Uri(System.IO.Path.Combine(s, @"текст.htm"));
            WebBrowser.Source = fg;
            readgrid.Visibility = Visibility.Visible;
        }
        private void test(object sender, RoutedEventArgs e)
        {
            this.numberofquest = 1;
            this.otvettrue = 0;
            Button.Content = "следующий вопрос";
            readgrid.Visibility = Visibility.Collapsed;
            worktest.Visibility = Visibility.Visible;
            System.IO.StreamReader f = new System.IO.StreamReader(System.IO.Path.Combine
                  (s, @"" + numberofquest.ToString() + ".txt"), System.Text.Encoding.GetEncoding("windows-1251"));
            qw.Content = f.ReadLine();
            rb1.Content = f.ReadLine();
            rb2.Content = f.ReadLine();
            rb3.Content = f.ReadLine();
            rb4.Content = f.ReadLine();
            this.goodotvet = f.ReadLine();

        }

        private void openim(object sender, RoutedEventArgs e)
        {
            try
            {
                Uri ss = new Uri(System.IO.Path.Combine(s, @"" + numberofquest.ToString() + ".jpg"));
                Window1 fg = new Window1();
                fg.image.Source = new BitmapImage(ss);
                fg.ShowDialog();
            }
            catch { MessageBox.Show("Приложение не было найдено"); }
        }

        private void nextqw(object sender, RoutedEventArgs e)
        {
            int vvod = 0;
            int otvet = 0;
            if (rb1.IsChecked == true) otvet = 1;
            else if (rb2.IsChecked == true) otvet = 2;
            else if (rb3.IsChecked == true) otvet = 3;
            else if (rb4.IsChecked == true) otvet = 4;
            else { MessageBox.Show("вы забыли выбрать вариант ответа!"); vvod++; }
            if (otvet.ToString() == goodotvet) this.otvettrue++;
            this.numberofquest++;
            if (numberofquest == 7) { Button.Content = "ок"; }
            if (numberofquest >= 8)
            {
                MessageBox.Show("правильных ответов " + otvettrue.ToString() + " из 7");
                otvet++;
                worktest.Visibility = Visibility.Collapsed;
            }
            else
            {
                if (vvod == 0)
                {
                    System.IO.StreamReader f = new System.IO.StreamReader(System.IO.Path.Combine
                        (s, @"" + numberofquest.ToString() + ".txt"), System.Text.Encoding.GetEncoding("windows-1251"));
                    qw.Content = f.ReadLine();
                    rb1.Content = f.ReadLine();
                    rb2.Content = f.ReadLine();
                    rb3.Content = f.ReadLine();
                    rb4.Content = f.ReadLine();
                    this.goodotvet = f.ReadLine();
                }
            }
            rb1.IsChecked = false;
            rb2.IsChecked = false;
            rb3.IsChecked = false;
            rb4.IsChecked = false;
        }
    }
}
