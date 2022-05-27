using Hotel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Hotel.ViewModel
{
    public  class AddClientVM : DataManegeVM
    {
        private RelayCommand addNewClient;
        public RelayCommand AddNewClient
        {
            get
            {
                return addNewClient ?? new RelayCommand(obj =>
                {
                    Window wnd = obj as Window;
                    string resultStr = "";
                    if (CliFirstName == null || CliFirstName.Replace(" ", "").Length == 0)
                    {
                        SetRedBlockControll(wnd, "FirstNameText");
                    }
                    if (CliLastName == null || CliLastName.Replace(" ", "").Length == 0)
                    {
                        SetRedBlockControll(wnd, "LastNameText");
                    }
                    if (CliPhoneNumber == null || CliPhoneNumber.Replace(" ", "").Length == 0)
                    {
                        SetRedBlockControll(wnd, "PhoneNumberText");
                    }
                    if (CliGender == null || CliGender.Replace(" ", "").Length == 0)
                    {
                        SetRedBlockControll(wnd, "ComboBoxGender");
                    }
                    if (CliPassport == null || CliPassport.Replace(" ", "").Length == 0)
                    {
                        SetRedBlockControll(wnd, "PassportText");
                    }
                    //if (UserPhone == null || UserPhone.Replace(" ", "").Length == 0)
                    //{
                    //    SetRedBlockControll(wnd, "SurNameBlock");
                    //}

                    else
                    {
                        resultStr = DataWorker.CreateClient(CliFirstName, CliLastName, CliPhoneNumber, CliGender, CliPassport, CliDateOfBrith);
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
