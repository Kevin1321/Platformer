using UnityEngine;
using System;


namespace Player
{
    public class MB_PlayerDisable : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D Rigidbody2DComponent = null;
        [SerializeField] private SO_Event_GameEnd Event_GameEnd = null;


        private void OnEnable()
        {
            Event_GameEnd.OnGameEndEvent += OnGameEnd;
        }

        private void OnDisable()
        {
            Event_GameEnd.OnGameEndEvent -= OnGameEnd;
        }

        private void OnGameEnd()
        {
            Rigidbody2DComponent.simulated = false;
        }
    }
}