using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ladeskab.Interfaces
{
    public interface IDoor
    {

        public void OnDoorOpen();
        public void OnDoorClose();
        public void LockDoor();
        public void UnlockDoor();
    }

    public class Door : IDoor
    {
        public void LockDoor()
        {
            throw new NotImplementedException();
        }

        public void OnDoorClose()
        {
            throw new NotImplementedException();
        }

        public void OnDoorOpen()
        {
            throw new NotImplementedException();
        }

        public void UnlockDoor()
        {
            throw new NotImplementedException();
        }
    }
}
