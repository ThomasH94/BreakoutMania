using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILimitable
{
    int Uses { get; set; }
    void Use();
}
