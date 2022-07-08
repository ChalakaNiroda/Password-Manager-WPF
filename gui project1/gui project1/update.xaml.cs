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
//created by chalaka niroda
namespace gui_project1
{
    /// <summary>
    /// Interaction logic for update.xaml
    /// </summary>
    public partial class update : Window
    {
        public update()
        {
            InitializeComponent();
            try
            {
                DataClasses1DataContext db = new DataClasses1DataContext();
                password_detail ps = new password_detail();
                ps = db.password_details.FirstOrDefault(x => x.website == url.userlink && x.master==userid.currentmaster);
                txtemail.Text = ps.email;
                txtname.Text = ps.name;
                txtnotes.Text = ps.note;
                txtpassword.Password = ps.password;
                txtusername.Text = ps.password;
                txtwebsite.Text = ps.website;
                txtemail.Clear();
                txtpassword.Clear();
            }
            catch
            {
                MessageBox.Show("unexpected error occurred");
            }


        }

        private void btnsave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                
                int evalid;
                if (txtname.Text != "" && txtusername.Text != "" && txtpassword.Password != "" && txtemail.Text != "")
                {
                    validation va = new validation();
                    evalid = va.emailvalidation(txtemail.Text);
                    if (evalid == 1)
                    {
                        
                        DataClasses1DataContext db = new DataClasses1DataContext();
                        password_detail ps = new password_detail();
                        ps = db.password_details.FirstOrDefault(x => x.website == url.userlink && x.master==userid.currentmaster);
                        ps.email = txtemail.Text;
                        ps.name = txtname.Text;
                        ps.username = txtusername.Text;
                        ps.password = txtpassword.Password.ToString();
                        ps.website = txtwebsite.Text;
                        ps.note = txtnotes.Text;
                        ps.datemodified = DateTime.Now;
                        db.SubmitChanges();
                        this.Close();
                        
                    }
                    else
                    {
                        MessageBox.Show("enter valid email");
                    }
                }
            }
            catch
            {
                MessageBox.Show("unexpected error occured");
            }
            //created by chalaka niroda
        }
    }
}
