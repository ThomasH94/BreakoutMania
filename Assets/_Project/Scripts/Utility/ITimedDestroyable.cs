using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITimedDestroyable
{
    float TimeBeforeDestroy { get; set; }
    void DestroyAfterSetTime();
    void OnDestroy();
}