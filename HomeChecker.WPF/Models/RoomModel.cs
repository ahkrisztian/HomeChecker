using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeChecker.WPF.Models
{
    public class RoomModel
    {      
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsLightsOn { get; set; } = false;
        public bool IsWaterOn { get; set; } = false;

        public bool AreWindowsClosed { get; set; } = false;
        public bool AreTheDoorsClosed { get; set; } = false;
        public bool IsReady { get; set; } = false;

        public RoomModel(string name, bool isLightsOn, bool isWaterOn, bool areWindowsClosed, bool areTheDoorsClosed, int id, bool isReady)
        {
            Name = name;
            IsLightsOn = isLightsOn;
            IsWaterOn = isWaterOn;
            AreWindowsClosed = areWindowsClosed;
            AreTheDoorsClosed = areTheDoorsClosed;
            Id = id;
            IsReady = isReady;
        }
    }
}
