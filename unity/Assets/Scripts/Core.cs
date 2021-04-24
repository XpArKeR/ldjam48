using System;

public class Core
{
    private static ShipBase ship;
    public static ShipBase Ship
    {
        get
        {
            return ship;
        }
        set
        {
            if (ship != value)
            {
                ship = value;
            }
        }
    }
}
