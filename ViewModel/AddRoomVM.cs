using Hotel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Hotel.ViewModel
{
    public class AddRoomVM : DataManegeVM
    {
        private RelayCommand addNewRoom;
        public RelayCommand AddNewRoom
        {
            get
            {
                return addNewRoom ?? new RelayCommand(obj =>
                {
                    Window wnd = obj as Window;
                    string resultStr = "";
                    if (RomNumber == null || RomNumber.Replace(" ", "").Length == 0)
                    {
                        SetRedBlockControll(wnd, "NumberText");
                    }
                    if (RomFloor == 0)
                    {
                        SetRedBlockControll(wnd, "ComboBoxFloorText");
                    }
                    if (RomType == null || RomType.Replace(" ", "").Length == 0)
                    {
                        SetRedBlockControll(wnd, "ComboBoxTypeText");
                    }
                    if (RomCapfcity == 0)
                    {
                        SetRedBlockControll(wnd, "ComboBoxCapfcityText");
                    }
                    if (RomStatus == null || RomStatus.Replace(" ", "").Length == 0)
                    {
                        SetRedBlockControll(wnd, "ComboBoxStatusText");
                    }
                    if (RomPrice == null || RomNumber.Replace(" ", "").Length == 0)
                    {
                        SetRedBlockControll(wnd, "PriceText");
                    }


                    else
                    {
                        resultStr = DataWorker.CreateRooms(RomNumber, RomFloor, RomType, RomCapfcity, RomStatus, RomPrice);
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
