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
    /// Interaction logic for delete.xaml
    /// </summary>
    public partial class delete : Window
    {
        public void dataview()
        {

            DataClasses1DataContext db = new DataClasses1DataContext();
            datagrid.ItemsSource = from passwords in db.password_details
                                       where passwords.master==userid.currentmaster
                                       select passwords;
        }
        
        public delete()
        {
            InitializeComponent();
            dataview();

        }

        private void DataGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
           
        }

        private void btndelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txturl.Text != "")
                {
                    DataClasses1DataContext db = new DataClasses1DataContext();
                    password_detail t = null;
                    t = db.password_details.Single(p => p.website==txturl.Text && p.master==userid.currentmaster);
                    if (t != null)
                    {
                        var delete = from passwords in db.password_details
                                     where passwords.website == txturl.Text
                                     select passwords;
                        db.password_details.DeleteAllOnSubmit(delete);
                        db.SubmitChanges();
                        dataview();
                    }
                    else
                    {
                        MessageBox.Show("invalid url");
                    }
                 }
                else
                {
                    MessageBox.Show("fill in the blanks");
                }



            }
            catch
            {
                MessageBox.Show("unexpected error occured");

            }
            
           
        }

        private void datagrid_CurrentCellChanged(object sender, EventArgs e)
        {
            
        }

        private void datagrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
           
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
