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
using System.ComponentModel;


namespace HelloWorld
{
    /// <summary>
    /// Interaction logic for SecondWindow.xaml
    /// </summary>
    public partial class SecondWindow : Window
    {
        public SecondWindow()
        {
            InitializeComponent();

            var users = new List<Models.User>();

            users.Add(new Models.User { Name = "Dave", Password = "2DavePwd" });
            users.Add(new Models.User { Name = "Dave", Password = "1DavePwd" });
            users.Add(new Models.User { Name = "Steve", Password = "2StevePwd" });
            users.Add(new Models.User { Name = "Lisa", Password = "3LisaPwd" });
            users.Add(new Models.User { Name = "Deanna", Password = "4DeannaPwd" });

            uxList.ItemsSource = users;

            getmyview(null);
        }

        private void getmyview(string columnName)
        {
            CollectionView view =
                (CollectionView)CollectionViewSource.GetDefaultView(uxList.ItemsSource);
                view.SortDescriptions.Clear();
            if (columnName == "password")
                view.SortDescriptions.Add(new SortDescription("Password", ListSortDirection.Ascending));
            else
                view.SortDescriptions.Add(new SortDescription("Name", ListSortDirection.Ascending));
        }

        private void uxName_Click(object sender, RoutedEventArgs e)
        {
            getmyview("name");            
        }

        private void uxPassword_Click(object sender, RoutedEventArgs e)
        {
            getmyview("password");
        }
    }
}
