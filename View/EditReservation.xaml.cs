using Hotel.Model;
using Hotel.ViewModel;
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

namespace Hotel.View
{
    /// <summary>
    /// Логика взаимодействия для EditReservation.xaml
    /// </summary>
    public partial class EditReservation : Window
    {
        public EditReservation(Reservation EditReservation)
        {
            InitializeComponent();
            DataManegeVM.ResCheckInDate = EditReservation.CheckInDate;
            DataManegeVM.ResCheckOutDate = EditReservation.CheckOutDate;
            DataManegeVM.ResClient = EditReservation.ResClient;
            DataManegeVM.ResRoom = EditReservation.ResRoom;
            DataManegeVM.ResReservationStatus = EditReservation.ReservationStatus;
            DataManegeVM.RestypePayment = EditReservation.typePayment;

        }
    }
}
