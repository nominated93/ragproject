using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Define
{
    public enum MoveDir
    {
        Idle,
        Up,
        Down,
        Left,
        Right,
    }

    public enum Scene
    {
        Unknown,
        Login,
        Lobby,
        Game,
        Cave,
    }

    public enum Sound
    {
        Bgm,
        Effect,
        MaxCount,
    }

    public enum UIEvent
    {
        Click,
        Drag,
    }

    public enum CreatureState
    {
        Idle,
        Moving,
        Skill,
        Dead,
    }
}
