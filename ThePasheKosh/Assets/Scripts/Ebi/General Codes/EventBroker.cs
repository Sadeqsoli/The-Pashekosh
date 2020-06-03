using System.Collections;
using System.Collections.Generic;
using System;

public class EventBroker
{
    // a sample event : 
    // We can use "Action" if its void or "Func" if it retruns something
    // Remember that "event" on its own needs a delegate
    public static event Action ProjectileOutOfBounds;

    public static void CallProjectileOutOfBounds()
    {
        ProjectileOutOfBounds?.Invoke();
    }
}
