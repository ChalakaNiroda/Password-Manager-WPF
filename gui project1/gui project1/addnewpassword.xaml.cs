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

namespace gui_project1
{
    /// <summary>
    /// Interaction logic for addnewpassword.xaml
    /// </summary>
    public partial class addnewpassword : Window
    {
        public addnewpassword()
        {
            InitializeComponent();
        }
        //created by chalaka niroda

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            
            
        }

        private void btnregister_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int evalid;
                if(txtname.Text!="" && txtusername.Text!="" && txtpassword.Password!="" && txtemail.Text!="" )
                {
                    validation v1 = new validation();
                    evalid = v1.emailvalidation(txtemail.Text);
                    if(evalid==1)
                    {
                        DataClasses1DataContext db = new DataClasses1DataContext();
                        password_detail pw = new password_detail();
                        pw.name = txtname.Text;
                        pw.email = txtemail.Text;
                        pw.username = txtusername.Text;
                        pw.website = txtwebsite.Text;
                        pw.password = txtpassword.Password.ToString();
                        if(txtnotes.Text!="")
                        {
                            pw.note = txtnotes.Text;
                        }
                        else
                        {
                            pw.note = "";
                        }
                        DateTime now = DateTime.Now;
                        pw.datecreted=now;
                        pw.datemodified = now;
                        pw.master = userid.currentmaster;
                        db.password_details.InsertOnSubmit(pw);
                        db.SubmitChanges();
                        this.Hide();
                        
                    }
                    else
                    {
                        MessageBox.Show("enter valid email");

                    }

                }
                else
                {
                    MessageBox.Show("fill all the blanks");

                }
            }
            catch
            {
                MessageBox.Show("unexpected error occured");
            }
        }
        //created by chalaka niroda
    }
}
