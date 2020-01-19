using UnityEngine;


namespace Values
{
    [CreateAssetMenu(fileName = "Bool", menuName = "ScriptableObjects/Values/Bool")]
    public class SO_Bool : ScriptableObject
    {
        [SerializeField] private bool m_Value;
        public bool Value { get { return m_Value; } set { m_Value = value; } }


        private bool originalValue;

        private void OnEnable()
        {
            originalValue = m_Value;
        }

        public void ResetValue()
        {
            m_Value = originalValue;
        }
    }
}