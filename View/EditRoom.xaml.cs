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
    /// Логика взаимодействия для EditRoom.xaml
    /// </summary>
    public partial class EditRoom : Window
    {
        public EditRoom(Room EditRoom)
        {
            InitializeComponent();
            DataManegeVM.RomNumber = EditRoom.Number;
            DataManegeVM.RomFloor = EditRoom.Floor;
            DataManegeVM.RomType = EditRoom.Type;
            DataManegeVM.RomCapfcity = EditRoom.Capfcity;
            DataManegeVM.RomStatus = EditRoom.Status;
            DataManegeVM.RomPrice = EditRoom.Price;
        }
    }
}
