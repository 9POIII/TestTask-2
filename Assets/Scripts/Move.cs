using System;
using System.Collections;
using UnityEngine;

public class Move : MonoBehaviour
{
    public static Move Instance;
    public GameObject Player;

    [SerializeField] private Vector3 _direction;

    public Rigidbody RbPlayer;
    public float Acceleration;

    private void Awake()
    {
        Instance = this;
    }
    
    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("player");
        RbPlayer = Player.GetComponent<Rigidbody>();
    }

    public void AddForce()
    {
        RbPlayer.AddForce(_direction.normalized * Acceleration);
    }

    public void TouchToPregrada()
    {
        var speed = RbPlayer.velocity.magnitude;
        
        RbPlayer.AddForce(_direction.normalized * speed * Acceleration * -1f);

        StartCoroutine(ValuesChanger());
        
        PointsController.Instance.MinusPoints();
    }

    public void BrakeMove(int speed)
    {
        RbPlayer.AddForce(_direction.normalized * (speed * Acceleration * -.5f));
    }

    public void FinishMove()
    {
        var speed = RbPlayer.velocity.magnitude;

        RbPlayer.AddForce(_direction.normalized * speed * Acceleration * -.5f);

        Acceleration = 0f;
        FovConroller.Instance.T = 0f;
        Rotation.Instance.Speed = 0f;
    }

    IEnumerator ValuesChanger()
    {
        var direction = _direction;
        var acceleration = Acceleration;
        
        _direction.x = 0;
        Acceleration = 0;

        yield return new WaitForSeconds(0.5f);
        
        _direction.x = direction.x;
        Acceleration = acceleration;
    }
}
