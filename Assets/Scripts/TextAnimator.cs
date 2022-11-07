using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class TextAnimator : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(Animator());
    }

    private IEnumerator Animator()
    {
        gameObject.SetActive(true);
        var position = UIPointsController.Instance.EndPoint.transform.position;
        transform.DOMove(new Vector3(position.x, position.y, position.z), UIPointsController.Instance.Duration);

        yield return new WaitForSeconds(UIPointsController.Instance.Duration);
        
        Destroy(gameObject);
    }
}
