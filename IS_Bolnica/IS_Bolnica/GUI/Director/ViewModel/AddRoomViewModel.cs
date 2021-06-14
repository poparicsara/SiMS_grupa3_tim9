using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IS_Bolnica.Director.Commands;
using IS_Bolnica.Services;
using Model;

namespace IS_Bolnica.Director.ViewModel
{
    public class AddRoomViewModel
    {
        private RoomService roomService = new RoomService();
        private string Id { get; set; }
        private Object Ward { get; set; }
        private Object Purpose { get; set; }
        private RelayCommand saveCommand;

        public AddRoomViewModel()
        {
            saveCommand = new RelayCommand(Save);
        }

        public RelayCommand SaveCommand
        {
            get { return saveCommand; }
        }

        private void Save()
        {
            RoomPurpose purpose = new RoomPurpose {Name = this.Purpose.ToString()};
            Room newRoom = new Room {Id = (int)Int64.Parse(this.Id), HospitalWard = Ward.ToString(), RoomPurpose = purpose, Inventory = new List<Inventory>()};
            roomService.AddRoom(newRoom);
        }

    }
}
