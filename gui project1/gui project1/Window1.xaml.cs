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
using System.Windows.Shapes;
using System.Data.SqlClient;

namespace gui_project1
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    /// //created by chalaka niroda
    /// 


    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void btncreateacc_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.Hide();
                createaccount w2 = new createaccount();
                w2.Show();
            }
            catch
            {
                MessageBox.Show("unexpected error occur");
            }
        }

        private void btnlogon_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataClasses1DataContext db = new DataClasses1DataContext();
                user_detail t = null;
                t = db.user_details.Single(p => p.username == txtEMAIL.Text && p.master == txtpassword.Password.ToString());
                if (t != null)
                {

                    userid.currentmaster = txtpassword.Password.ToString();
                    this.Close();
                    MainWindow w1 = new MainWindow();
                    w1.Show();
                    
                  
                    
                    
                   
                }
                else
                {
                    MessageBox.Show("invalid user name or password");
                    txtEMAIL.Clear();
                    txtpassword.Clear();
                }
            }
            catch
            {
                MessageBox.Show("invalid login");
                txtEMAIL.Clear();
                txtpassword.Clear();
            }

            
        }

        //created by chalaka niroda//created by chalaka niroda
        //created by chalaka niroda
    }
}

