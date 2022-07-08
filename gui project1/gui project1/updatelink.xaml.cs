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
    /// Interaction logic for updatelink.xaml
    /// </summary>
    public partial class updatelink : Window
    {
        public updatelink()
        {
            InitializeComponent();
        }

        private void btnlinkfinder_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataClasses1DataContext db = new DataClasses1DataContext();
                password_detail t = null;
                t = db.password_details.Single(p => p.website == txturl.Text && p.master==userid.currentmaster);
                if (t != null)
                {
                    url.userlink = txturl.Text;
                    this.Close();
                    update u1 = new update();
                    u1.Show();
                }
                else
                {
                    MessageBox.Show("invalid url");
                }
            }
            catch
            {

            }
            //created by chalaka niroda//created by chalaka niroda
            //created by chalaka niroda
        }
    }
}
