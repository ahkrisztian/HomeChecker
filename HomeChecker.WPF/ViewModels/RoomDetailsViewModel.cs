using HomeChecker.WPF.Commands;
using HomeChecker.WPF.Models;
using HomeChecker.WPF.Stores;
using HomeChecker.WPF.Stores.Actions;
using System.Windows.Input;

namespace HomeChecker.WPF.ViewModels
{
    public class RoomDetailsViewModel : ViewModelBase
    {
        private readonly SelectedRoomStore _selectedRoomStore;
        private readonly RoomsListViewModel _roomsListViewModel;

        private RoomModel SelectedRoomModel => _selectedRoomStore.SelectedRoomModel;

        public bool HasSelectedRoom => SelectedRoomModel != null;
        public string RoomName => SelectedRoomModel?.Name ?? "Unknown";


        private int _id;

        public int Id
        {
            get { return SelectedRoomModel.Id; }
            set
            {
                _id = SelectedRoomModel.Id;
                OnPropertychanged(nameof(Id));
            }
        }


        private bool _lights;

        public bool Lights
        {
            get => SelectedRoomModel?.IsLightsOn ?? false;
            set 
            { 
                _lights = value;
                OnPropertychanged(nameof(Lights)); 
                SelectedRoomModel.IsLightsOn = value;
            }
        }


        private bool _water;

        public bool Water
        {
            get => SelectedRoomModel?.IsWaterOn ?? false;
            set 
            { 
                _water = value; 
                OnPropertychanged(nameof(Water));
                SelectedRoomModel.IsWaterOn = value;
            }
        }

        private bool _doors;

        public bool Doors
        {
            get => SelectedRoomModel?.AreTheDoorsClosed ?? false;
            set 
            { 
                _doors = value; 
                OnPropertychanged(nameof(Doors));
                SelectedRoomModel.AreTheDoorsClosed = value;
            }
        }

        private bool _windows;

        public bool Windows
        {
            get => SelectedRoomModel?.AreWindowsClosed ?? false;
            set { 
                _windows = value; 
                OnPropertychanged(nameof(Windows)); 
                SelectedRoomModel.AreWindowsClosed = value;
            }
        }

        private bool _isReady;

        public bool IsReady
        {
            get => SelectedRoomModel?.IsReady ?? false;
            set
            {
                _isReady = value;
                OnPropertychanged(nameof(IsReady));
                SelectedRoomModel.IsReady = value;
            }
        }

        public ICommand ReadyCommand { get;}

        public ICommand CancelCommand { get;}

        public RoomDetailsViewModel(NavigationStore navigationStore, RoomListItemMade roomListStore, RoomListViewStore roomListViewStore, SelectedRoomStore selectedRoomStore, 
            RoomsListViewModel roomsListViewModel, RoomListViewUpdateRoom roomListViewUpdateRoom
            )
        {
            _selectedRoomStore = selectedRoomStore;

            _selectedRoomStore.SelectedRoomChanged += SelectedRoomStore_SelectedRoomChanged;

            ReadyCommand = new ReadyCommand(roomsListViewModel, this, roomListViewUpdateRoom);

            CancelCommand = new NavigateHomeCreatorCommand(navigationStore, roomListStore, roomListViewStore, selectedRoomStore, roomsListViewModel, this, roomListViewUpdateRoom);

        }

        protected override void Dispose()
        {
            _selectedRoomStore.SelectedRoomChanged -= SelectedRoomStore_SelectedRoomChanged;

            base.Dispose();
        }


        private void SelectedRoomStore_SelectedRoomChanged()
        {           
            OnPropertychanged(nameof(HasSelectedRoom));
            OnPropertychanged(nameof(RoomName));
            OnPropertychanged(nameof(Lights));
            OnPropertychanged(nameof(Water));
            OnPropertychanged(nameof(Doors));
            OnPropertychanged(nameof(Windows));
            OnPropertychanged(nameof(IsReady));
        }

    }

}
