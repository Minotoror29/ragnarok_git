using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerState : State
{
    protected Player _player;

    public PlayerState(Player player)
    {
        _player = player;
    }
}
