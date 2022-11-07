using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    private GameObject _player;
    
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("player");
    }

    private void LateUpdate()
    {
        gameObject.transform.position = new Vector3(_player.transform.position.x - 8, _player.transform.position.y + 9.5f,
            _player.transform.position.z);
    }
}
