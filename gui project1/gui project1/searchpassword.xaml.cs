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
    /// Interaction logic for searchpassword.xaml
    /// </summary>
    public partial class searchpassword : Window
    {
        public searchpassword()
        {
            InitializeComponent();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataClasses1DataContext db = new DataClasses1DataContext();
                    password_detail t = null;
                t = db.password_details.Single(p => p.website == txturl.Text && p.master==userid.currentmaster);
                if (t != null)
                {
                    
                    datagridview.ItemsSource = db.password_details.Where(x => x.website == txturl.Text && x.master==userid.currentmaster).Select(x => new { x.name, x.email, x.password, x.website, x.note, x.datecreted, x.datemodified });
                }
                else
                {
                    MessageBox.Show("invalid url");
                }
            }
            catch
            {

            }
        }

        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
