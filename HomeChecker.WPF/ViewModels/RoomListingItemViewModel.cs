using HomeChecker.WPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeChecker.WPF.ViewModels
{
    public class RoomListingItemViewModel : ViewModelBase
    {
        public RoomModel RoomModel { get; set; }

        public string RoomName  => RoomModel.Name;
        public bool Checked =>  RoomModel.IsReady;

        public RoomListingItemViewModel(RoomModel roomModel)
        {
            RoomModel = roomModel;
        }
    }
}
