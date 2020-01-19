using UnityEngine;


namespace UI
{
    [CreateAssetMenu(fileName = "ButtonClickEvent", menuName = "ScriptableObjects/UI/ButtonClickEvent")]
    public class SO_ButtonClickEvent : ScriptableObject
    {
        public delegate void OnButtonClick();
        public event OnButtonClick OnButtonClickEvent;


        public void Invoke()
        {
            OnButtonClickEvent?.Invoke();
        }
    }
}