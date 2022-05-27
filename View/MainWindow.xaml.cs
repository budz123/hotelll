using Hotel.ViewModel;
using System.Windows;
using System.Windows.Controls;
using Hotel;

namespace Hotel.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static ListView AllReservationsView;
        public static ListView AllRoomsView;
        public static ListView AllClientsView;
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowVM();
            AllReservationsView = ViewAllReservations;
            AllRoomsView = ViewAllRooms;
            AllClientsView = ViewAllClietns;
        }

        private void Button_Click()
        {

        }

        private void ViewAllClietns_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
