using System;


//This is an event bus
public class EventBus<T> where T : Event
{
    public static event Action<T> OnEvent;

    public static void Publish(T pEvent)
    {
        OnEvent?.Invoke(pEvent);
    }
}

//These are all the events on the bus
public class TowerPlaced : Event
{ 
    
}