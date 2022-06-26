using HomeChecker.WPF.Models;
using HomeChecker.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeChecker.WPF.Stores
{
    public class RoomListItemMade
    {
        public event Action<RoomListingItemViewModel> RoomAdded;


        public void OnRoomMade(RoomListingItemViewModel room)
        {
            RoomAdded?.Invoke(room);
        }

    }
}
