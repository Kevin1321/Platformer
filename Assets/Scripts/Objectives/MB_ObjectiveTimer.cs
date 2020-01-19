using UnityEngine;
using Values;

namespace Objectives
{
    public class MB_ObjectiveTimer : MonoBehaviour
    {
        [SerializeField] private SO_Objective Objective_Timer = null;

        [SerializeField] private SO_Observable_Int CurrentPlayTimeLeft = null;


        private float second = 0;

        private bool isTimeUp = false;


        private void Update()
        {
            if (isTimeUp) return;

            second += Time.deltaTime;

            if(second > 1)
            {
                CurrentPlayTimeLeft.Value--;
                second = 0;
            }

            if (CurrentPlayTimeLeft.Value > 0) return;
            Objective_Timer.Invoke(false);
            isTimeUp = true;
        }
    }
}