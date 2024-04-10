using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallsAnimation : MonoBehaviour
{
    public GameObject enviorment;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Ball")) return;
        foreach (Transform child in enviorment.transform)
        {
            child.transform.DOShakePosition(0.2f, 0.3f, 100);
        }

    }

}
