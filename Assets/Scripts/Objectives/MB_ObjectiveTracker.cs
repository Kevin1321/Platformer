using UnityEngine;
using System;


namespace Objectives
{
    public class MB_ObjectiveTracker : MonoBehaviour
    {
        [Header("Objectives to Track")]
        [SerializeField] private SO_Objective Objective_Timer = null;
        [SerializeField] private SO_Objective Objective_Location = null;

        [Header("Objective Completion Event")]
        [SerializeField] private SO_Event_GameEnd Event_GameEnd = null;

        
        private void OnEnable()
        {
            Objective_Timer.OnObjectiveCompleteEvent += Timer_OnObjectiveComplete;
            Objective_Location.OnObjectiveCompleteEvent += Location_OnObjectiveComplete;
            Event_GameEnd.OnGameEndEvent += OnGameEnd;
        }

        private void OnDisable()
        {
            Objective_Timer.OnObjectiveCompleteEvent -= Timer_OnObjectiveComplete;
            Objective_Location.OnObjectiveCompleteEvent -= Location_OnObjectiveComplete;
            Event_GameEnd.OnGameEndEvent -= OnGameEnd;
        }

        private void Timer_OnObjectiveComplete(bool wasSuccesful)
        {
            if (!wasSuccesful)
            {
                Event_GameEnd.Invoke();
            }
        }

        private void Location_OnObjectiveComplete(bool wasSuccesful)
        {
            if(wasSuccesful)
            {
                Event_GameEnd.Invoke();
            }
        }

        private void OnGameEnd()
        {
            Destroy(gameObject);
        }
    }
}