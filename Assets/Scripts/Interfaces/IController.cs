using System;

namespace Interfaces
{
    public interface IController
    {
        Action<int> ChangeGun{ get; set; }
        Action Shoot{ get; set; }
        Action<float> DirectionValue { get; set; }
        Action<bool> ThrustValue { get; set; }
        Action Restart{ get; set; }

    }
}