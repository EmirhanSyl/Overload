using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IJumpable
{
    public void HandleJump();
    public bool IsJumping();
    public bool IsFalling();
}
