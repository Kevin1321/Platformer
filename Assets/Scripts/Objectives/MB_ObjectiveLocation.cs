using UnityEngine;
using System;


namespace Objectives
{
    public class MB_ObjectiveLocation : MonoBehaviour
    {
        [SerializeField] SO_Objective Objective_Location = null;


        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (!collision.CompareTag(C_TagStrings.PLAYER)) return;
            Objective_Location.Invoke(true);    
        }
    }
}