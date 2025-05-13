using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Sample {
public class GhostScript : MonoBehaviour
{
    private Animator _anim;
    private CharacterController _ctrl;
    private Vector3 _moveDirection = Vector3.zero;
    // Cache hash values
    private static readonly int IdleState = Animator.StringToHash("Base Layer.idle");
    private static readonly int MoveState = Animator.StringToHash("Base Layer.move");
    private static readonly int SurprisedState = Animator.StringToHash("Base Layer.surprised");
    private static readonly int AttackState = Animator.StringToHash("Base Layer.attack_shift");
    private static readonly int DissolveState = Animator.StringToHash("Base Layer.dissolve");
    private static readonly int AttackTag = Animator.StringToHash("Attack");
    // dissolve
    [FormerlySerializedAs("MeshR")] [SerializeField] private SkinnedMeshRenderer[] meshR;
    private float _dissolveValue = 1;
    private bool _dissolveFlg = false;
    private const int MaxHp = 3;
    private int _hp = MaxHp;
    private Text _hpText;

    // moving speed
    [FormerlySerializedAs("Speed")] [SerializeField] private float speed = 4;

    void Start()
    {
        _anim = this.GetComponent<Animator>();
        _ctrl = this.GetComponent<CharacterController>();
        _hpText = GameObject.Find("Canvas/HP").GetComponent<Text>();
        _hpText.text = "HP " + _hp.ToString();
    }

    void Update()
    {
        Status();
        Gravity();
        Respawn();
        // this character status
        if(!_playerStatus.ContainsValue( true ))
        {
            Move();
            PlayerAttack();
            Damage();
        }
        else if(_playerStatus.ContainsValue( true ))
        {
            int statusName = 0;
            foreach(var i in _playerStatus)
            {
                if(i.Value == true)
                {
                    statusName = i.Key;
                    break;
                }
            }
            if(statusName == Dissolve)
            {
                PlayerDissolve();
            }
            else if(statusName == Attack)
            {
                PlayerAttack();
            }
            else if(statusName == Surprised)
            {
                // nothing method
            }
        }
        // Dissolve
        if(_hp <= 0 && !_dissolveFlg)
        {
            _anim.CrossFade(DissolveState, 0.1f, 0, 0);
            _dissolveFlg = true;
        }
        // processing at respawn
        else if(_hp == MaxHp && _dissolveFlg)
        {
            _dissolveFlg = false;
        }
    }

    //---------------------------------------------------------------------
    // character status
    //---------------------------------------------------------------------
    private const int Dissolve = 1;
    private const int Attack = 2;
    private const int Surprised = 3;
    private Dictionary<int, bool> _playerStatus = new Dictionary<int, bool>
    {
        {Dissolve, false },
        {Attack, false },
        {Surprised, false },
    };
    //------------------------------
    private void Status ()
    {
        // during dissolve
        if(_dissolveFlg && _hp <= 0)
        {
            _playerStatus[Dissolve] = true;
        }
        else if(!_dissolveFlg)
        {
            _playerStatus[Dissolve] = false;
        }
        // during attacking
        if(_anim.GetCurrentAnimatorStateInfo(0).tagHash == AttackTag)
        {
            _playerStatus[Attack] = true;
        }
        else if(_anim.GetCurrentAnimatorStateInfo(0).tagHash != AttackTag)
        {
            _playerStatus[Attack] = false;
        }
        // during damaging
        if(_anim.GetCurrentAnimatorStateInfo(0).fullPathHash == SurprisedState)
        {
            _playerStatus[Surprised] = true;
        }
        else if(_anim.GetCurrentAnimatorStateInfo(0).fullPathHash != SurprisedState)
        {
            _playerStatus[Surprised] = false;
        }
    }
    // dissolve shading
    private void PlayerDissolve ()
    {
        _dissolveValue -= Time.deltaTime;
        for(int i = 0; i < meshR.Length; i++)
        {
            meshR[i].material.SetFloat("_Dissolve", _dissolveValue);
        }
        if(_dissolveValue <= 0)
        {
            _ctrl.enabled = false;
        }
    }
    // play a animation of Attack
    private void PlayerAttack ()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            _anim.CrossFade(AttackState,0.1f,0,0);
        }
    }
    //---------------------------------------------------------------------
    // gravity for fall of this character
    //---------------------------------------------------------------------
    private void Gravity ()
    {
        if(_ctrl.enabled)
        {
            if(CheckGrounded())
            {
                if(_moveDirection.y < -0.1f)
                {
                    _moveDirection.y = -0.1f;
                }
            }
            _moveDirection.y -= 0.1f;
            _ctrl.Move(_moveDirection * Time.deltaTime);
        }
    }
    //---------------------------------------------------------------------
    // whether it is grounded
    //---------------------------------------------------------------------
    private bool CheckGrounded()
    {
        if (_ctrl.isGrounded && _ctrl.enabled)
        {
            return true;
        }
        Ray ray = new Ray(this.transform.position + Vector3.up * 0.1f, Vector3.down);
        float range = 0.2f;
        return Physics.Raycast(ray, range);
    }
    //---------------------------------------------------------------------
    // for slime moving
    //---------------------------------------------------------------------
    private void Move ()
    {
        // velocity
        if(_anim.GetCurrentAnimatorStateInfo(0).fullPathHash == MoveState)
        {
            if (Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.DownArrow) && !Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow))
            {
                MOVE_Velocity(new Vector3(0, 0, -speed), new Vector3(0, 180, 0));
            }
            else if (Input.GetKey(KeyCode.DownArrow) && !Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow))
            {
                MOVE_Velocity(new Vector3(0, 0, speed), new Vector3(0, 0, 0));
            }
            else if (Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.DownArrow) && !Input.GetKey(KeyCode.RightArrow))
            {
                MOVE_Velocity(new Vector3(speed, 0, 0), new Vector3(0, 90, 0));
            }
            else if (Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.DownArrow) && !Input.GetKey(KeyCode.LeftArrow))
            {
                MOVE_Velocity(new Vector3(-speed, 0, 0), new Vector3(0, 270, 0));
            }
        }
        KEY_DOWN();
        KEY_UP();
    }
    //---------------------------------------------------------------------
    // value for moving
    //---------------------------------------------------------------------
    private void MOVE_Velocity (Vector3 velocity, Vector3 rot)
    {
        _moveDirection = new Vector3 (velocity.x, _moveDirection.y, velocity.z);
        if(_ctrl.enabled)
        {
            _ctrl.Move(_moveDirection * Time.deltaTime);
        }
        _moveDirection.x = 0;
        _moveDirection.z = 0;
        this.transform.rotation = Quaternion.Euler(rot);
    }
    //---------------------------------------------------------------------
    // whether arrow key is key down
    //---------------------------------------------------------------------
    private void KEY_DOWN ()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            _anim.CrossFade(MoveState, 0.1f, 0, 0);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            _anim.CrossFade(MoveState, 0.1f, 0, 0);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            _anim.CrossFade(MoveState, 0.1f, 0, 0);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            _anim.CrossFade(MoveState, 0.1f, 0, 0);
        }
    }
    //---------------------------------------------------------------------
    // whether arrow key is key up
    //---------------------------------------------------------------------
    private void KEY_UP ()
    {
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            if(!Input.GetKey(KeyCode.DownArrow) && !Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow))
            {
                _anim.CrossFade(IdleState, 0.1f, 0, 0);
            }
        }
        else if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            if(!Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow))
            {
                _anim.CrossFade(IdleState, 0.1f, 0, 0);
            }
        }
        else if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            if(!Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.DownArrow) && !Input.GetKey(KeyCode.RightArrow))
            {
                _anim.CrossFade(IdleState, 0.1f, 0, 0);
            }
        }
        else if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            if(!Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.DownArrow) && !Input.GetKey(KeyCode.LeftArrow))
            {
                _anim.CrossFade(IdleState, 0.1f, 0, 0);
            }
        }
    }
    //---------------------------------------------------------------------
    // damage
    //---------------------------------------------------------------------
    private void Damage ()
    {
        // Damaged by outside field.
        if(Input.GetKeyUp(KeyCode.S))
        {
            _anim.CrossFade(SurprisedState, 0.1f, 0, 0);
            _hp--;
            _hpText.text = "HP " + _hp.ToString();
        }
    }
    //---------------------------------------------------------------------
    // respawn
    //---------------------------------------------------------------------
    private void Respawn ()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            // player HP
            _hp = MaxHp;
            
            _ctrl.enabled = false;
            this.transform.position = Vector3.zero; // player position
            this.transform.rotation = Quaternion.Euler(Vector3.zero); // player facing
            _ctrl.enabled = true;
            
            // reset Dissolve
            _dissolveValue = 1;
            for(int i = 0; i < meshR.Length; i++)
            {
                meshR[i].material.SetFloat("_Dissolve", _dissolveValue);
            }
            // reset animation
            _anim.CrossFade(IdleState, 0.1f, 0, 0);
        }
    }
}
}