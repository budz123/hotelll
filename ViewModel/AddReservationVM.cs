using Hotel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Hotel.ViewModel
{
    public class AddReservationVM : DataManegeVM
    {
        private RelayCommand addNewReservation;
        public RelayCommand AddNewReservation
        {
            get
            {
                return addNewReservation ?? new RelayCommand(obj =>
                {
                    Window wnd = obj as Window;
                    string resultStr = "";
                    if (ResCheckInDate == null)
                    {
                        SetRedBlockControll(wnd, "DatePickerCheckInDate");
                    }
                    if (ResCheckInDate == null)
                    {
                        SetRedBlockControll(wnd, "DatePickerCheckOutDate");
                    }
                    if (ResRoom == null)
                    {
                        SetRedBlockControll(wnd, "ComboBoxRoomIDText");
                    }
                    if (ResReservationStatus == null || ResReservationStatus.Replace(" ", "").Length == 0)
                    {
                        SetRedBlockControll(wnd, "ComboBoxReservationStatusText");
                    }
                    if (RestypePayment == null || RestypePayment.Replace(" ", "").Length == 0)
                    {
                        SetRedBlockControll(wnd, "ComboBoxTypePaymentText");
                    }
                    if (ResClient == null)
                    {
                        SetRedBlockControll(wnd, "ComboBoxClientIDText");
                    }
                    else
                    {
                        
                        resultStr = DataWorker.CreateReservations(ResCheckInDate, ResCheckOutDate, ResClient, ResRoom, ResReservationStatus, RestypePayment);
                        DataWorker.SwapRoomStatus(ResRoom, "Reservation");
                        UpdateAllDataView();

                        ShowMessageToUser(resultStr);
                        SetNullValuesToProperties();
                        wnd.Close();
                    }
                }
                );
            }
        }
    }
}
