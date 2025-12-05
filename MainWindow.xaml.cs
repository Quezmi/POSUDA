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
using System.IO;

namespace POSUDA
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Capcha_Botton_Click(object sender, RoutedEventArgs e)
        {
            string allowchar = "";

            allowchar = "A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z";
            allowchar += ",a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,y,z";
            allowchar += ",1,2,3,4,5,6,7,8,9,0";

            string[] ar = allowchar.Split(',');

            string pwd = ""; // ← без пробела

            Random r = new Random();

            for (int i = 0; i < 6; i++)
            {
                pwd += ar[r.Next(ar.Length)];
            }

            TextBox_Capcha.Text = pwd;
        }

        private void Join_Botton_Click(object sender, RoutedEventArgs e)
        {
            string dbPath = @"C:\Users\user\source\repos\POSUDA\users.db";
            MessageBox.Show($"Путь к БД: {dbPath}\nСуществует: {System.IO.File.Exists(dbPath)}");

            using (var db = new AppContext())
            {
                var all = db.users.ToList();
                MessageBox.Show($"Количество пользователей, которых видит EF: {all.Count}");
            }


            string text1 = TextBox_Capcha.Text.Trim();
            string text2 = TextBox_JoinCapcha.Text.Trim();
            String login = MainLogit_Text.Text.Trim();
            String pass = MainPass_PassBox.Password.Trim();
            if (login.Length < 5)
            {
                MainLogit_Text.ToolTip = "Миша, всё х, давай по новой";
                MainLogit_Text.Background = Brushes.DarkRed;
            }
            else if (pass.Length < 5)
            {
                MainPass_PassBox.Background = Brushes.DarkRed;
            }
            else
            {
                user AuthUser = null;
                using (AppContext db = new AppContext())
                {
                    AuthUser = db.users.Where(b => b.Login == login && b.Password == pass).FirstOrDefault();
                }
                if (AuthUser != null)
                {
                    int a = 0;
                    if (string.Equals(text1, text2, StringComparison.OrdinalIgnoreCase) )
                    {
                        a = 0;
                        MessageBox.Show("Затычка, работает нормас");
                    }
                    else
                    {
                        a++;
                        MessageBox.Show("Вы робот");
                    }
                }
                else { MessageBox.Show("Дурашка, иди вспоминай как кличат тебя в сие кругах"); }
                
            }

           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            POSUDA.RegForm regForm = new POSUDA.RegForm();
            regForm.Show();
            this.Close();

        }
    }
}
