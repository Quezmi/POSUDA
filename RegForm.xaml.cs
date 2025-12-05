using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
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
using System.Windows.Shapes;

namespace POSUDA
{
    /// <summary>
    /// Логика взаимодействия для RegForm.xaml
    /// </summary>
    public partial class RegForm : Window
    {
        AppContext db;
        public RegForm()
        {
            InitializeComponent();

            db = new AppContext();

          
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RegLogin_textBox.Background = null;
            RegName_TextBox.Background = null;  
            RegPass_TextBox.Background = null;
            RegReg_Button.Background = null;
            RegRole_textBox.Background = null;
            String Login = RegLogin_textBox.Text.Trim();
            String Name = RegName_TextBox.Text.Trim();
            String Role = RegRole_textBox.Text.Trim();
            String Pass = RegPass_TextBox.Password.Trim();
            if (Login.Length < 5)
            {
                RegLogin_textBox.ToolTip = "Миша, всё х, давай по новой";
                RegLogin_textBox.Background = Brushes.DarkRed;
            }
            else if (Pass.Length < 5)
            {
                RegPass_TextBox.Background = Brushes.DarkRed;
            }
            else if (Pass.Length == 5) { RegPass_TextBox.Background = Brushes.Yellow; }
            else if (Role != "Администратор" && Role != "Клиент")
            {
                RegRole_textBox.ToolTip = "Принимается только Администратор или Клиент";
                RegRole_textBox.Background = Brushes.DarkRed;
            }
            else if (Name.Length < 10)
            {
                RegName_TextBox.ToolTip = "Больно коротко тебя кличут";
                RegName_TextBox.Background = Brushes.DarkRed;
            }
            else
            {
                user user = new user(Login, Name, Role, Pass);
                db.users.Add(user);
                db.SaveChanges();
               // POSUDA.MainWindow Fform = new POSUDA.MainWindow();
                //Fform.Show();
                //this.Close();
            }
                
          
        }
    }
}
