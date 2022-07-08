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
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
//created by chalaka niroda
//created by chalaka niroda

namespace gui_project1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public  void dataview()
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            datagridview.ItemsSource = db.password_details.Where(x => x.master == userid.currentmaster).Select(x => new {x.name,x.email,x.password, x.website, x.note,x.datecreted,x.datemodified });
        }
        public MainWindow()
        {
            InitializeComponent();

            if (userid.currentmaster ==null)
            {
                this.Hide();
                Window1 w1 = new Window1();
                w1.Show();
            }
            dataview();
          


        }

        private void datagridview_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            addnewpassword a1 = new addnewpassword();
            a1.Show();
            
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            searchpassword s1 = new searchpassword();
            s1.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            dataview();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            updatelink ul = new updatelink();
            ul.Show();

        }

        private void btndelete1_Click(object sender, RoutedEventArgs e)
        {
            delete d = new delete();
            d.Show();

        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            this.Close();
            Window1 log = new  Window1();
            log.Show();
            url.userlink = null;
            userid.currentmaster = null;

        }

        private void Grid_GotFocus(object sender, RoutedEventArgs e)
        {
            
            
        }
    }
    //created by chalaka niroda
}
