using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface InterfaceSubject
{
    void RegisterObserver(InterfaceObserver o);
    void RemoveObserver(InterfaceObserver o);
    void NotifyObservers();
}
