using Hotel.Model;
using Hotel.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Hotel.ViewModel
{
   public class MainWindowVM : DataManegeVM
    {
        protected RelayCommand deleteItem;
        public RelayCommand DeleteItem
        {
            get
            {
                return deleteItem ?? new RelayCommand(obj =>
                {
                    string resultStr = "Ничего не выбрано";
                    //если Clients
                    if (SelectedTabItem.Name == "ClientsTab" && SelectedClient != null)
                    {
                        resultStr = DataWorker.DeleteClients(SelectedClient);
                        UpdateAllDataView();
                    }
                    //если RoomsT
                    if (SelectedTabItem.Name == "RoomsTab" && SelectedRoom != null)
                    {
                        resultStr = DataWorker.DeleteRoom(SelectedRoom);
                        UpdateAllDataView();
                    }
                    //если Reservations
                    if (SelectedTabItem.Name == "ReservationsTab" && SelectedReservation != null)
                    {
                       
                       DataWorker.SwapRoomStatusNotBloked(SelectedReservation.ResRoom,"not booked");
                        resultStr = DataWorker.DeleteReservations(SelectedReservation);
                        UpdateAllDataView();
                    }
                    //обновление
                    SetNullValuesToProperties();
                    ShowMessageToUser(resultStr);
                }
                    );
            }
        }
        private RelayCommand openAddNewReservationWnd;
        public RelayCommand OpenAddNewReservationWnd
        {
            get
            {
                return openAddNewReservationWnd ?? new RelayCommand(obj =>
                {
                    OpenAddReservationWindowMethod();
                }
                    );
            }
        }
        private RelayCommand openAddNewRoomWnd;
        public RelayCommand OpenAddNewRoomnWnd
        {
            get
            {
                return openAddNewRoomWnd ?? new RelayCommand(obj =>
                {
                    OpenAddRoomWindowMethod();
                }
                );
            }
        }
        private RelayCommand openAddNewClientWnd;
        public RelayCommand OpenAddNewClientWnd
        {
            get
            {
                return openAddNewClientWnd ?? new RelayCommand(obj =>
                {
                    OpenAddClientWindowMethod();
                }
                );
            }
        }
        private RelayCommand openEditItemWnd;
        public RelayCommand OpenEditItemWnd
        {
            get
            {
                return openEditItemWnd ?? new RelayCommand(obj =>
                {
                    string resultStr = "Ничего не выбрано";
                    //если Клиент
                    if (SelectedTabItem.Name == "ClientsTab" && SelectedClient != null)
                    {
                        OpenEditClientWindowMethod(SelectedClient);
                    }
                    //если Комната
                    if (SelectedTabItem.Name == "RoomsTab" && SelectedRoom != null)
                    {
                        OpenEditRoomWindowMethod(SelectedRoom);
                    }
                    //если Резервирование
                    if (SelectedTabItem.Name == "ReservationsTab" && SelectedReservation != null)
                    {
                        OpenEditReservationWindowMethod(SelectedReservation);
                    }

                }
                    );
            }
        }
        private void OpenAddClientWindowMethod()
        {
            AddClient newClientWindow = new AddClient();
            SetCenterPositionAndOpen(newClientWindow);
        }
        private void OpenAddRoomWindowMethod()
        {
            AddRoom newRoomWindow = new AddRoom();
            SetCenterPositionAndOpen(newRoomWindow);
        }
        private void OpenAddReservationWindowMethod()
        {
            AddReservation newReservationWindow = new AddReservation();
            SetCenterPositionAndOpen(newReservationWindow);
        }
        private void OpenVhodWindowMethod()
        {
            VhodWindow newVhodWindow = new VhodWindow();
            SetCenterPositionAndOpen(newVhodWindow);
        }
        //окна редактирования
        private void OpenEditReservationWindowMethod(Reservation Reservation)
        {
            EditReservation editDepartmentWindow = new EditReservation(Reservation);
            SetCenterPositionAndOpen(editDepartmentWindow);
        }
        private void OpenEditRoomWindowMethod(Room Room)
        {
            EditRoom editPositionWindow = new EditRoom(Room);
            SetCenterPositionAndOpen(editPositionWindow);
        }
        private void OpenEditClientWindowMethod(Client Client)
        {
            EditClient editUserWindow = new EditClient(Client);
            SetCenterPositionAndOpen(editUserWindow);
        }

    }
}
