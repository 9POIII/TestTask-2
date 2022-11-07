using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class Rotation : MonoBehaviour, IBeginDragHandler, IDragHandler
{
    public static Rotation Instance;
    
    [SerializeField] private GameObject _player;

    public Vector3 RotationVector;
    public float Speed;

    private bool _isPressed = false;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        _player = Move.Instance.Player;
    }

    private void FixedUpdate()
    {
        var speed = (int)Move.Instance.RbPlayer.velocity.magnitude;

        /**if (Input.GetMouseButtonDown(0))
        {
            _isPressed = true;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            _isPressed = false;
        }
        if (_isPressed)
        {
            Move.Instance.AddForce();
            FovConroller.Instance.AddFov();
        }
        else
        {
            FovConroller.Instance.MinusFov();
        }**/

        if (Input.touchCount > 0)
        {
            Move.Instance.AddForce();
            Move.Instance.RbPlayer.drag = 1;
            if (speed >= 1)
            {
                FovConroller.Instance.AddFov();
            }
        }
        else if (Input.touchCount < 1)
        {
            FovConroller.Instance.MinusFov();
            Move.Instance.RbPlayer.drag = 2;
            if (speed <= 2)
            {
                Move.Instance.BrakeMove(speed);
            }
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {

    }

    public void OnDrag(PointerEventData eventData)
    {
        if (eventData.delta.x < 0)
        {
            RotationVector = Vector3.up * eventData.delta.x * -1;
        }
        else if (eventData.delta.x > 0)
        {
            RotationVector = Vector3.down * eventData.delta.x;
        }
        else
        {
            RotationVector = Vector3.zero;
        }
        
        _player.transform.Rotate(RotationVector * Speed * Time.deltaTime);
    }
}
