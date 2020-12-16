using System.Collections.Generic;
using System;

namespace Proyecto
{
    public interface IPowerUpable<IPowerUp>
    {
        void addPowerUp(IPowerUp powerUp);
        void removePowerUp(IPowerUp powerUp);
    }
}