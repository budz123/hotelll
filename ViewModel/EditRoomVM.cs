using Hotel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Hotel.ViewModel
{
    public class EditRoomVM : DataManegeVM
    {
        private RelayCommand editRoom;
        public RelayCommand EditRoom
        {
            get
            {
                return editRoom ?? new RelayCommand(obj =>
                {
                    Window window = obj as Window;
                    string resultStr = "Не выбрана комната";
                  
                    if (SelectedRoom != null)
                    {

                        resultStr = DataWorker.EditRoom(SelectedRoom, RomNumber, RomFloor, RomType, RomCapfcity, RomStatus, RomPrice);

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
