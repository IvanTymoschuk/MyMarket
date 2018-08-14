using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SqlConnection connection;
        SqlDataAdapter adapter;
        DataTable dataTable;
        double totalprice=0;
        public MainWindow()
        {
            InitializeComponent();
            connection = new SqlConnection(@"Data Source = (localdb)\MSSQLLocalDB;Initial Catalog = Market; Integrated Security = true");
            adapter = new SqlDataAdapter("select * from Products", connection);
            dataTable = new DataTable();
            adapter.Fill(dataTable);

            

        }
        int count = 1;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
           
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                if (int.Parse(tbCode.Text) == int.Parse(dataTable.Rows[i][0].ToString()))
                {
                    totalprice += double.Parse(dataTable.Rows[i][2].ToString())*int.Parse(tbAmount.Text);
                    listbox.Items.Add(count+"   "+dataTable.Rows[i][0] + "   " + dataTable.Rows[i][1] + "\n" +tbAmount.Text +"x"+string.Format("{0:C}",
                        double.Parse( dataTable.Rows[i][2].ToString()))+'\n'+ string.Format("{0:C}", totalprice));
                    
                    lblPrice.Content = string.Format("{0:C}", totalprice) ;
                    tbAmount.Text = "1";
                }
            }
            count++;
        }
    }
}
