using HomeChecker.WPF.Models;
using HomeChecker.WPF.ViewModels;
using System;

namespace HomeChecker.WPF.Stores
{
    public class SelectedRoomStore
    {

        private RoomModel _selectedRoomModel;

        public RoomModel SelectedRoomModel
        {
            get { return _selectedRoomModel; }
            set 
            {
                _selectedRoomModel = value;
                SelectedRoomChanged?.Invoke();
            }
        }

        public event Action SelectedRoomChanged;

    }
}
