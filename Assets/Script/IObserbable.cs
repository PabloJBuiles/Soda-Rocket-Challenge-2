using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IObserbable
{
    Observer[] Observers();
    bool HasRegisteredObservers();
    
    void RegisterObservers();
    void UnregisterObservers();
    void NotifyObservers();
}
