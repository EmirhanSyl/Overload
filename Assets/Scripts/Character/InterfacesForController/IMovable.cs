using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMovable
{
    public void HandleMovement(float horizontalInput, bool isStop);
    public float GetSpeed();
}
