using System;
using System.Collections;
using UnityEngine;

public class Move : MonoBehaviour
{
    public static Move Instance;
    public GameObject Player;

    [SerializeField] private Vector3 _direction;

    public Rigidbody _rbPlayer;
    public float _acceleration;

    private void Awake()
    {
        Instance = this;
    }
    
    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("player");
        _rbPlayer = Player.GetComponent<Rigidbody>();
    }

    public void AddForce()
    {
        _rbPlayer.AddForce(_direction.normalized * _acceleration);
    }

    public void TouchToPregrada()
    {
        var speed = _rbPlayer.velocity.magnitude;
        
        _rbPlayer.AddForce(_direction.normalized * speed * _acceleration * -1f);

        StartCoroutine(ValuesChanger());
        
        PointsController.Instance.MinusPoints();
    }

    public void BrakeMove(int speed)
    {
        _rbPlayer.AddForce(_direction.normalized * speed * _acceleration * -.5f);
    }

    public void FinishMove()
    {
        var speed = _rbPlayer.velocity.magnitude;

        _rbPlayer.AddForce(_direction.normalized * speed * _acceleration * -.5f);

        _acceleration = 0f;
        FovConroller.Instance._t = 0f;
        Rotation.Instance.Speed = 0f;
    }

    IEnumerator ValuesChanger()
    {
        var direction = _direction;
        var acceleration = _acceleration;
        
        _direction.x = 0;
        _acceleration = 0;

        yield return new WaitForSeconds(0.5f);
        
        _direction.x = direction.x;
        _acceleration = acceleration;
    }
}
