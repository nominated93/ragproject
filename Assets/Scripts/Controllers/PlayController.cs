using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Define;

public class PlayController : CreatureController
{
    protected override void Init()
    {
        base.Init();
        DontDestroyOnLoad(this.gameObject);
    }

    protected override void UpdateController()
    {
        GetDirInput();
        base.UpdateController();
    }



    void LateUpdate() {
        Camera.main.transform.position = new Vector3(transform.position.x, transform.position.y, -10);    
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
