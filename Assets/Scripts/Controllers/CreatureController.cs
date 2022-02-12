using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Define;

public class CreatureController : MonoBehaviour
{
    public Vector3Int CellPos { get; set; } = new Vector3Int(-10,0,10);
    //public Grid _grid;
    protected float _speed = 5.0f;
    protected bool _isMoving = false;

    protected Animator _animator;
    protected SpriteRenderer _sprite;

    CreatureState _state = CreatureState.Idle;
    public CreatureState State
    {
        get{ return _state; }
        set
        {
            if(_state == value)
                return;

            _state = value;

            UpdateAnimation();
        }
    }

    MoveDir _moveDir = MoveDir.Down;
    MoveDir _lastDir = MoveDir.Down;
    public MoveDir Dir
    {
        get
        {
            return _moveDir;
        }

        set
        {
            if (_moveDir == value)
                return;

            _moveDir = value;
            if(value != MoveDir.Idle)
                _lastDir = value;

            UpdateAnimation();
        }
    }

    void Start()
    {
        Init();
    }

    void Update()
    {
        UpdateController();
    }

    protected virtual void Init()
    {
        _animator = GetComponent<Animator>();
        _sprite = GetComponent<SpriteRenderer>();

        Vector3 pos = Managers.Map.CurrentGrid.CellToWorld(CellPos) + new Vector3(0.5f, 0.5f);
        transform.position = pos;
    }

    protected virtual void UpdateController()
    {
        UpdatePosition();
        UpdateMovingFlag();
    }

    protected virtual void UpdateAnimation()
    {
        if(_state == CreatureState.Idle)
        {
            switch (_lastDir)
            {
                case MoveDir.Up:
                    _animator.Play("IDLE_BACK");
                    //transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                    _sprite.flipX = false;
                    break;
                case MoveDir.Down:
                    _animator.Play("IDLE_FRONT");
                    _sprite.flipX = false;
                    break;
                case MoveDir.Left:
                    _animator.Play("IDLE_RIGHT");
                    _sprite.flipX = true;
                    break;
                case MoveDir.Right:
                    _animator.Play("IDLE_RIGHT");
                    _sprite.flipX = false;
                    break;
            }
        }
        else if(_state == CreatureState.Moving)
        {
            switch (_moveDir)
            {
                case MoveDir.Up:
                    _animator.Play("WALK_BACK");
                    _sprite.flipX = false;
                    break;
                case MoveDir.Down:
                    _animator.Play("WALK_FRONT");
                    _sprite.flipX = false;
                    break;
                case MoveDir.Left:
                    _animator.Play("WALK_RIGHT");
                    _sprite.flipX = true;
                    break;
                case MoveDir.Right:
                    _animator.Play("WALK_RIGHT");
                    _sprite.flipX = false;
                    break;
            }
        }
        else if(_state == CreatureState.Skill)
        {

        }
        else
        {

        }
    }

    void UpdatePosition()
    {
        if (State != CreatureState.Moving)
            return;

        Vector3 destPos = Managers.Map.CurrentGrid.CellToWorld(CellPos); //+ new Vector3(0.5f, 0.5f);
        Vector3 moveDir = destPos - transform.position;

        float dist = moveDir.magnitude;
        if (dist < Time.deltaTime * _speed)
        {
            transform.position = destPos;

            _state = CreatureState.Idle; // 애니메이션 X
            if(_moveDir == MoveDir.Idle) 
            {
                UpdateAnimation();
            }
        }
        else
        {
            transform.position += moveDir.normalized * Time.deltaTime * _speed;
            State = CreatureState.Moving;
        }
    }

    void UpdateMovingFlag()
    {
        if (State != CreatureState.Moving && _moveDir != MoveDir.Idle)
        {
            Vector3Int destPos = CellPos;
            switch (Dir)
            {
                case MoveDir.Up:
                    destPos += Vector3Int.up;
                    break;
                case MoveDir.Down:
                    destPos += Vector3Int.down;
                    break;
                case MoveDir.Left:
                    destPos += Vector3Int.left;
                    break;
                case MoveDir.Right:
                    destPos += Vector3Int.right;
                    break;

            }

            if (Managers.Map.CanGo(destPos))
            {
                if(Managers.Obj.Find(destPos) == null)
                {
                    CellPos = destPos;
                    State = CreatureState.Moving;
                }
            }
        }

    }

}
