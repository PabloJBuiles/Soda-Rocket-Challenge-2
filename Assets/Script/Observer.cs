using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
public abstract class Observer : MonoBehaviour
{
    public abstract void Notify();

    public abstract void Register(AgitacionBotella _agitacion);

    public abstract void Unregister(AgitacionBotella _agitacion);
}

