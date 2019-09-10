using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteract
{
    bool canUse { get; set; }

    void Interaction();
}
