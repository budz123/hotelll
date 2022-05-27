using Hotel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Hotel.ViewModel
{
    public class EditClientVM : DataManegeVM
    {
        private RelayCommand editClient;
        public RelayCommand EditClient
        {
            get
            {
                return editClient ?? new RelayCommand(obj =>
                {
                    Window window = obj as Window;
                    string resultStr = "Не выбран Клиент";
                   

                    if (SelectedClient != null)
                    {

                        resultStr = DataWorker.EditClient(SelectedClient, CliFirstName, CliLastName, CliPhoneNumber, CliGender, CliPassport, CliDateOfBrith);

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
