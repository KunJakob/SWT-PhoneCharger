using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoorSimulator
{
    public interface IDoor
    {
        public bool IsDoorUnlocked { get; set; }
        public void LockDoor();
        public void UnlockDoor();
    }
}
