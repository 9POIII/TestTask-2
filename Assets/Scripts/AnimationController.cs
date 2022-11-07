using System;
using System.Collections;
using UnityEngine;
using DG.Tweening;

public class AnimationController : MonoBehaviour
{
    public static AnimationController Instance;
    
    const float duration = 0.5f;
    const float strength = 0.2f;

    [SerializeField] private GameObject _player;
    private bool _canAnimate = true;
    
    private void Awake()
    {
        Instance = this;
    }

    public void DoShake()
    {
        _player = Move.Instance.Player;
        
        if (_canAnimate)
        {
            _player.transform.DOShakeRotation(duration, strength);
            _player.transform.DOShakeScale(duration, strength);

            _canAnimate = false;

            StartCoroutine(ResetTimer());
            Move.Instance.TouchToPregrada(); 
        }
    }

    IEnumerator ResetTimer()
    {
        yield return new WaitForSeconds(duration);

        _canAnimate = true;
    }
}
