﻿using Hotel.Model;
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
    /// Логика взаимодействия для EditClient.xaml
    /// </summary>
    public partial class EditClient : Window
    {
        public EditClient(Client EditClient)
        {
            InitializeComponent();

            DataManegeVM.CliFirstName = EditClient.FirstName;
            DataManegeVM.CliLastName = EditClient.LastName;
            DataManegeVM.CliPhoneNumber = EditClient.PhoneNumber;
            DataManegeVM.CliGender = EditClient.Gender;
            DataManegeVM.CliPassport = EditClient.Passport;
            DataManegeVM.CliDateOfBrith = EditClient.DateOfBrith;
        }
    }
}
