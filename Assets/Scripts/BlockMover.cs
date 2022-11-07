using System.Collections;
using System.Data;
using UnityEngine;

public class BlockMover : MonoBehaviour
{
    [SerializeField] private Vector3 _direction;
    [SerializeField] private float _acceleration;
    [SerializeField] private BoxCollider _collider;
    [SerializeField] private AudioSource _audioSource;

    private Rigidbody _rb;
    private int _counterOfTriggers = 0;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collider") && _counterOfTriggers == 0)
        {
            _counterOfTriggers = 1;
            
            _rb.useGravity = true;
            _rb.AddForce(_direction.normalized * _acceleration);
            
            AnimationController.Instance.DoShake();
            
            SoundPlayer.Instance.BlockBumping();
                
            StartCoroutine(TurnOffCollision());
        }
        if (other.gameObject.name == "Trigger")
        {
            Destroy(gameObject);
        }
    }

    IEnumerator TurnOffCollision()
    {
        yield return new WaitForSeconds(3);
        _collider.enabled = false;
    }
}
