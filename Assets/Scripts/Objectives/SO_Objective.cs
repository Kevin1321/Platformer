using UnityEngine;

namespace Objectives
{
    [CreateAssetMenu(fileName = "Objective", menuName = "ScriptableObjects/Objectives/Objective")]
    public class SO_Objective : ScriptableObject
    {
        public delegate void OnObjectiveComplete(bool wasSuccesful);
        public event OnObjectiveComplete OnObjectiveCompleteEvent;


        public void Invoke(bool wasSuccesful)
        {
            OnObjectiveCompleteEvent?.Invoke(wasSuccesful);
        }
    }
}
