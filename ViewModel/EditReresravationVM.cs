using Hotel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Hotel.ViewModel
{
    public class EditReresravationVM : DataManegeVM
    {
        private RelayCommand editReservation;
        public RelayCommand EditReservation
        {
            get
            {
                return editReservation ?? new RelayCommand(obj =>
                {
                    Window window = obj as Window;
                    string resultStr = "Не выбран резервирование";
                    if (SelectedReservation != null)
                    {
                        resultStr = DataWorker.EditReservations(SelectedReservation, ResCheckInDate, ResCheckOutDate, ResClient, ResRoom, ResReservationStatus, RestypePayment);
                        DataWorker.SwapRoomStatus(ResRoom, "Reservation");
                        UpdateAllDataView();
                        SetNullValuesToProperties();
                        ShowMessageToUser(resultStr);
                        window.Close();
                    }
                    else ShowMessageToUser(resultStr);

                }
                );
            }
        }
    }
}
