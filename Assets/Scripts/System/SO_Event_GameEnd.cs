using UnityEngine;


namespace System
{
    [CreateAssetMenu(fileName = "Event_GameEnd", menuName = "ScriptableObjects/System/Event_GameEnd")]
    public class SO_Event_GameEnd : ScriptableObject
    {
        public delegate void OnGameEnd();
        public event OnGameEnd OnGameEndEvent;


        public void Invoke()
        {
            OnGameEndEvent?.Invoke();
        }
    }
}