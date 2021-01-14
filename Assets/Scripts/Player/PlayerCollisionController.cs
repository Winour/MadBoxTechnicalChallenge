using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionController : MonoBehaviour
{
#warning Load this with addressables or from a CDN or from BackEnd
    [Header("Coins")]
    [SerializeField] private string _coinsTag;

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.CompareTag(_coinsTag))
        {
        }
    }
}
