using Hotel.View;
using Hotel.Model;
using Hotel.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Hotel.ViewModel
{
    public class DataManegeVM : INotifyPropertyChanged
    {
        //все Reservation
        private List<Reservation> allReservationts = DataWorker.GetAllReservations();
        public List<Reservation> AllReservationts
        {
            get { return allReservationts; }
            set
            {

                allReservationts = value;
                NotifyPropertyChanged("AllReservations");
            }
        }
        private List<Room> notReservationts = DataWorker.GetAllRoomsAndReservationsById();
        public List<Room> NotReservations
        {
            get { return notReservationts; }
            //эй скейтер мальчик летний ветер

            set
            {

                notReservationts = value;
                NotifyPropertyChanged("AllRooms");
            }
        }

        //все Room
        private List<Room> allRooms = DataWorker.GetAllRooms();
        public List<Room> AllRooms
        {
            get
            {
                return allRooms;
            }
            set
            {
                allRooms = value;
                NotifyPropertyChanged("AllRooms");
            }
        }
        //все сотрудники
        private List<Client> allClient = DataWorker.GetAllClients();
        public List<Client> AllClient
        {
            get
            {
                return allClient;
            }
            set
            {
                allClient = value;
                NotifyPropertyChanged("AllClients");
            }
        }

        //свойства для Reservations

        public static DateTime ResCheckInDate { get; set; }
        public static DateTime ResCheckOutDate { get; set; }
        public static Client ResClient { get; set; }
        public static Room ResRoom { get; set; }
        public static string ResReservationStatus { get; set; }
        public static string RestypePayment { get; set; }
        //свойства для Room
        public static string RomNumber { get; set; }
        public static int RomFloor { get; set; }
        public static string RomType { get; set; }
        public static int RomCapfcity { get; set; }
        public static string RomStatus { get; set; }
        public static string RomPrice { get; set; }

        //свойства для Client
        public static string CliFirstName { get; set; }

        public static string CliLastName { get; set; }

        public static string CliPhoneNumber { get; set; }

        public static string CliGender { get; set; }

        public static string CliPassport { get; set; }

        public static DateTime CliDateOfBrith { get; set; }

        //свойства для выделенных элементов
        public TabItem SelectedTabItem { get; set; }
        public static Client SelectedClient { get; set; }
        public static Room SelectedRoom { get; set; }
        public static Reservation SelectedReservation { get; set; }


        
        protected void SetCenterPositionAndOpen(Window window)
        {
            window.Owner = Application.Current.MainWindow;
            window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            window.ShowDialog();
        }

        //#endregion
        protected void SetRedBlockControll(Window wnd, string blockName)
        {
            Control block = wnd.FindName(blockName) as Control;
            block.BorderBrush = Brushes.Red;
        }

        #region UPDATE VIEWS
        protected void SetNullValuesToProperties()
        {
            //для пользователя
           CliFirstName = null;
            CliLastName = null;
            CliGender = null;
            CliPassport = null;
            CliPhoneNumber = null;
            CliDateOfBrith = DateTime.Today;
            //для позиции
           RomCapfcity = 0;
            RomFloor = 0;
            RomNumber = null;
            RomPrice = null;
            RomStatus = null;
            RomType = null;
            //для отдела
            ResCheckInDate = DateTime.Today;
            ResCheckOutDate = DateTime.Today;
            ResClient = null;
            ResRoom = null;
            ResReservationStatus = null;
            RestypePayment = null;
        }
        protected void UpdateAllDataView()
        {
            UpdateAllReservationsView();
            UpdateAllRoomsView();
            UpdateAllClientsView();
        }

        private void UpdateAllReservationsView()
        {
            AllReservationts = DataWorker.GetAllReservations();
            MainWindow.AllReservationsView.ItemsSource = null;
            MainWindow.AllReservationsView.Items.Clear();
            MainWindow.AllReservationsView.ItemsSource = AllReservationts;
            MainWindow.AllReservationsView.Items.Refresh();
        }
        private void UpdateAllRoomsView()
        {
            AllRooms = DataWorker.GetAllRooms();
            MainWindow.AllRoomsView.ItemsSource = null;
            MainWindow.AllRoomsView.Items.Clear();
            MainWindow.AllRoomsView.ItemsSource = AllRooms;
            MainWindow.AllRoomsView.Items.Refresh();
        }
        private void UpdateAllClientsView()
        {
            AllClient = DataWorker.GetAllClients();
            MainWindow.AllClientsView.ItemsSource = null;
            MainWindow.AllClientsView.Items.Clear();
            MainWindow.AllClientsView.ItemsSource = AllClient;
            MainWindow.AllClientsView.Items.Refresh();
        }
        #endregion

        protected void ShowMessageToUser(string message)
        {
            MessageView messageView = new MessageView(message);
            SetCenterPositionAndOpen(messageView);
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
