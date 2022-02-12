using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Define;

public class MonsterController : CreatureController
{
    protected override void Init()
    {
        base.Init();
        State = CreatureState.Idle;
        Dir = MoveDir.Idle;
    }

    protected override void UpdateController()
    {
       // GetDirInput();
        base.UpdateController();
    }

    MoveDir _moveDir = MoveDir.Down;
    MoveDir _lastDir = MoveDir.Down;
    protected override void UpdateAnimation()
    {
        if (State == CreatureState.Idle)
        {
            switch (_lastDir)
            {
                case MoveDir.Up:
                    _sprite.flipX = false;
                    break;
                case MoveDir.Down:
                    _sprite.flipX = false;
                    break;
                case MoveDir.Left:
                    _sprite.flipX = true;
                    break;
                case MoveDir.Right:
                    _sprite.flipX = false;
                    break;
            }
        }
        else if (State == CreatureState.Moving)
        {
            switch (_moveDir)
            {
                case MoveDir.Up:
                    _sprite.flipX = false;
                    break;
                case MoveDir.Down:
                    _sprite.flipX = false;
                    break;
                case MoveDir.Left:
                    _sprite.flipX = true;
                    break;
                case MoveDir.Right:
                    _sprite.flipX = false;
                    break;
            }
        }
        else if (State == CreatureState.Skill)
        {

        }
        else
        {

        }
    }

    void GetDirInput()
    {

        if (Input.GetKey(KeyCode.W))
        {
            //transform.position += Vector3.up * Time.deltaTime * _speed;
            Dir = MoveDir.Up;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            Dir = MoveDir.Down;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            Dir = MoveDir.Left;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            Dir = MoveDir.Right;
        }
        else
        {
            Dir = MoveDir.Idle;
        }
    }
}
