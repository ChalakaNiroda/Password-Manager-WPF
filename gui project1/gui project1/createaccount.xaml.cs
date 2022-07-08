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
using System.Text.RegularExpressions;

namespace gui_project1
{
    /// <summary>
    /// Interaction logic for createaccount.xaml
    /// </summary>
    public partial class createaccount : Window
    {
        public createaccount()
        {
            InitializeComponent();
            
        }

        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            Window1 w1 = new Window1();
            w1.Show();
        }

        private void btnregister_Click(object sender, RoutedEventArgs e)
        {
            

            try
            {
               
                int evalid;
              
                    if (txtname.Text != "" && txtusername.Text != "" && txtpassword.Password!="" && txtemail.Text!="")
                    {

                       validation v1 = new validation();
                       evalid = v1.emailvalidation(txtemail.Text);
                      if(evalid==1)
                      {
                        try
                        {


                            DataClasses1DataContext db = new DataClasses1DataContext();
                            user_detail u1 = new user_detail();
                            u1.name = txtname.Text;
                            u1.email = txtemail.Text;
                            u1.username = txtusername.Text;
                            u1.master = txtpassword.Password.ToString();
                            db.user_details.InsertOnSubmit(u1);
                            db.SubmitChanges();
                            this.Hide();
                            MainWindow m1 = new MainWindow();
                            userid.currentmaster= txtpassword.Password.ToString();
                            m1.Show();
                        }
                        catch
                        {
                            MessageBox.Show("your enterd password is exists  try different password");
                        }
                       }
                       else
                       {
                        MessageBox.Show("enter valid email");
                        }

                     }
                      else
                      {
                          MessageBox.Show("fill the blanks");
                       }
    

            }
            catch
            {
                MessageBox.Show("unexpected error occur");

            }

        }
    }
}
