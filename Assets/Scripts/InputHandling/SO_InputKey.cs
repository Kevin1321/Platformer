using UnityEngine;


namespace InputHandling
{
    [CreateAssetMenu(fileName = "InputKey", menuName = "ScriptableObjects/InputHandling/InputKey")]
    public class SO_InputKey : ScriptableObject
    {
        [SerializeField] private KeyCode m_InputKey = KeyCode.None;
        public KeyCode InputKey { get{ return m_InputKey; } }
    }
}