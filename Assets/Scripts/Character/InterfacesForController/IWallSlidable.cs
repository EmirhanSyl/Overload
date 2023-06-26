using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWallSlidable
{
    public void WallSlidingEndWithMovement();
    public void WallSlidingEndWithJump();
    public bool IsWallSliding(); 
}
