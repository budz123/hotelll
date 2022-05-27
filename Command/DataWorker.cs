using Hotel.Model.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Hotel.Model
{
    public static class DataWorker
    {
        #region AllTables
        //получить все Reservation
        public static List<Reservation> GetAllReservations()//depertament
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var result = db.Reservations.ToList();
                return result;
            }
        }
        //получить все Room
        public static List<Room> GetAllRooms() //postion
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var result = db.Rooms.ToList();
                return result;
            }
        }
        //получить всех Client
        public static List<Client> GetAllClients()//user
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var result = db.Clients.ToList();
                return result;
            }
        }
        #endregion

        //создать Reservations
        public static string CreateReservations(DateTime CheckInDate, DateTime CheckOutDate,Client client, Room room, string ReservationStatus, string typePayment)
        {
            string result = "Уже существует";
            using (ApplicationContext db = new ApplicationContext())
            {
                //проверяем сущесвует ли Reservations
                bool checkIsExist = db.Reservations.Any(el => el.Room == room);
                if (!checkIsExist)
                {
                    Reservation newReservation = new Reservation { CheckInDate = CheckInDate, CheckOutDate= CheckOutDate,ClientsId = client.Id,RoomsId=room.Id, ReservationStatus = ReservationStatus, typePayment = typePayment };
                    db.Reservations.Add(newReservation);
                    db.SaveChanges();
                    result = "Сделано!";
                }
                return result;
            }
        }
        public static string SwapRoomStatus(Room OldRoom,string NewReservationStatus)
        {
            string result = "Уже существует";
            using (ApplicationContext db = new ApplicationContext())
            {

                var room = db.Rooms.FirstOrDefault(d => d.Id == OldRoom.Id);
                room.Status = NewReservationStatus;               
                 db.SaveChanges();
                    result = "Сделано! " + OldRoom.Status + " Edit";
                
                
            }
            return result;
        }
        public static string SwapRoomStatusNotBloked (Room OldRoom, string NewReservationStatus)
        {
            string result = "Уже существует";
            using (ApplicationContext db = new ApplicationContext())
            {

                var room = db.Rooms.FirstOrDefault(d => d.Id == OldRoom.Id);
                room.Status = NewReservationStatus;
                db.SaveChanges();
                result = "Сделано! " + OldRoom.Status + " Edit";


            }
            return result;
        }
        //содать Rooms
        public static string CreateRooms(string Number, int Floor, string Type, int Capfcity, string Status,string Price)
        {
            string result = "Уже существует";
            using (ApplicationContext db = new ApplicationContext())
            {
                //проверяем сущесвует ли Rooms
                bool checkIsExist = db.Rooms.Any(el => el.Number == Number);
                if (!checkIsExist)
                {
                    Room newRooms = new Room
                    {
                        Number = Number,
                        Floor = Floor,
                        Type = Type,
                        Capfcity = Capfcity,
                        Status = Status,
                        Price = Price,
                    };
                    db.Rooms.Add(newRooms);
                    db.SaveChanges();
                    result = "Сделано!";
                }
                return result;
            }
        }
        //создать Client
        public static string CreateClient(string FirstName, string LastName, string PhoneNumber, string Gender, string Passport, DateTime DateOfBrith)
        {
            string result = "Уже существует";
            using (ApplicationContext db = new ApplicationContext())
            {
                //check the user is exist
                bool checkIsExist = db.Clients.Any(el => el.FirstName == FirstName && el.LastName == LastName);
                if (!checkIsExist)
                {
                    Client newClient = new Client
                    {
                        FirstName = FirstName,
                        LastName = LastName,
                        PhoneNumber = PhoneNumber,
                        Gender = Gender,
                        Passport = Passport,
                        DateOfBrith = DateOfBrith,
                    };
                    db.Clients.Add(newClient);
                    db.SaveChanges();
                    result = "Сделано!";
                }
                return result;
            }
        }
        //Delete Reservations
        public static string DeleteReservations(Reservation Reservation)
        {
            string result = "Такого Резервирование не существует";
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Reservations.Remove(Reservation);
                db.SaveChanges();
                result = "Сделано! Резервирование " + Reservation.Client + " Удалено";
            }
            return result;
        }
        //удаление Room
        public static string DeleteRoom(Room Room)
        {
            string result = "Такой Комната не существует";
            using (ApplicationContext db = new ApplicationContext())
            {
                //check position is exist
                db.Rooms.Remove(Room);
                db.SaveChanges();
                result = "Сделано! Комната " + Room.Number + " Удалена";
            }
            return result;
        }
        //удаление Client
        public static string DeleteClients(Client Client)
        {
            string result = "Такого Клиент не существует";
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Clients.Remove(Client);
                db.SaveChanges();
                result = "Сделано! Клиент " + Client.FirstName + " Удален";
            }
            return result;
        }
        //редактирование Reservation
        public static string EditReservations(Reservation oldReservation, DateTime newCheckInDate, DateTime newCheckOutDate, Client newclient, Room newroom, string newReservationStatus, string newtypePayment)
        {
            string result = "Такого Резервирование не существует";
            using (ApplicationContext db = new ApplicationContext())
            {
                Reservation reservation = db.Reservations.FirstOrDefault(d => d.Id == oldReservation.Id);
                reservation.CheckInDate = newCheckInDate;
                reservation.CheckOutDate = newCheckOutDate;
                reservation.ClientsId= newclient.Id;
                reservation.RoomsId = newroom.Id;
                reservation.ReservationStatus = newReservationStatus;
                reservation.typePayment = newtypePayment;
                db.SaveChanges();
                result = "Сделано! Резервирование " + reservation.CheckInDate + " изменено";
            }
            return result;
        }
        //редактирование Room
        public static string EditRoom(Room oldRoom, string newNumber, int newFloor, string newType, int newCapfcity, string newStatus, string newPrice)
        {
            string result = "Такой Комната не существует";
            using (ApplicationContext db = new ApplicationContext())
            {
                Room Room = db.Rooms.FirstOrDefault(p => p.Id == oldRoom.Id);
                Room.Number = newNumber;
                Room.Floor = newFloor;
                Room.Type = newType;
                Room.Capfcity = newCapfcity;
                Room.Status = newStatus;
                Room.Price = newPrice;
                db.SaveChanges();
                result = "Сделано! Комната " + Room.Number + " изменена";
            }
            return result;
        }
        //редактирование EditClient
        public static string EditClient(Client oldClient, string newFirstName, string newLastName, string newPhoneNumber, string newGender, string newPassport, DateTime newDateOfBrith)
        {
            string result = "Такого Клиента не существует";
            using (ApplicationContext db = new ApplicationContext())
            {
                //check user is exist
                Client client = db.Clients.FirstOrDefault(p => p.Id == oldClient.Id);
                if (client != null)
                {
                    client.FirstName = newFirstName;
                    client.LastName = newLastName;
                    client.PhoneNumber = newPhoneNumber;
                    client.Gender = newGender;
                    client.Passport = newPassport;
                    client.DateOfBrith = newDateOfBrith;
                    db.SaveChanges();
                    result = "Сделано! Клиент " + client.LastName + client.FirstName + " изменен";
                }
            }
            return result;
        }

        //получение Room по id 
        public static Room GetRoomById(int id)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Room pos = db.Rooms.FirstOrDefault(p => p.Id == id);
                return pos;
            }
        }
        //получение Reservation по id 
        public static Reservation GetReservationById(int id)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Reservation pos = db.Reservations.FirstOrDefault(p => p.Id == id);
                return pos;
            }
        }
        public static Client GetclientById(int id)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Client pos = db.Clients.FirstOrDefault(p => p.Id == id);
                return pos;
            }
        }
        //получение всех пользователей по id 
        public static List<Client> GetAllclientId(int id)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                List<Client> users = (from client in GetAllClients() where client.Id == id select client).ToList();
                return users;
            }
        }
        //получение всех Room по id 
        public static List<Room> GetAllRoomsById(int id)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                List<Room> ooms = (from Room in GetAllRooms() where Room.Id == id select Room).ToList();
                return ooms;
            }
        }
        public static List<Room> GetAllRoomsAndReservationsById()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                List<Room> Reservations = (from Room in GetAllRooms() where Room.Status != "Reservation" select Room).ToList();
                return Reservations;
            }
        }

    }
}
