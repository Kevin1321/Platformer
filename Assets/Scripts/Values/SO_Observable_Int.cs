using UnityEngine;


namespace Values
{
    [CreateAssetMenu(fileName = "Observable_Int", menuName = "ScriptableObjects/Values/Observable_Int")]
    public class SO_Observable_Int : ScriptableObject
    {
        [SerializeField] private int m_Value;
        public int Value { get { return m_Value; } set { m_Value = value; OnValueChangedEvent?.Invoke(m_Value); } }


        public delegate void OnValueChanged(int value);
        public event OnValueChanged OnValueChangedEvent;


        private int originalValue;

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