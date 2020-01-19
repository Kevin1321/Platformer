using UnityEngine;
using System;


public class MB_DeathTrigger : MonoBehaviour
{
    [SerializeField] private SO_Event_GameEnd Event_GameEnd = null;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag(C_TagStrings.PLAYER)) return;
        Event_GameEnd.Invoke();
    }
}