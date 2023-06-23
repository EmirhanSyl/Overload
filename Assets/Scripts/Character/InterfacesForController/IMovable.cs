using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMovable
{
    public void HandleMovement(float horizontalInput);
    public float GetSpeed();
}
