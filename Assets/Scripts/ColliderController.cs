using UnityEngine;

public class ColliderController : MonoBehaviour
{
    private GameObject _player;
    private GameObject _collider;
    
    private void Start()
    {
        _player = Move.Instance.Player;
        _collider = GameObject.FindWithTag("Collider");
    }

    private void FixedUpdate()
    {
        _collider.transform.localPosition = _player.transform.localPosition;
        _collider.transform.localRotation = _player.transform.localRotation;
    }
}
