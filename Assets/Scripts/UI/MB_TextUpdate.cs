using UnityEngine;
using Values;
using TMPro;


public class MB_TextUpdate : MonoBehaviour
{
    [Header("TextMeshPro Component")]
    [SerializeField] private TMP_Text TMP_Text = null;

    [Header("Display Value")]
    [SerializeField] private SO_Observable_Int DisplayValue = null;


    private void Awake()
    {
        TMP_Text.text = DisplayValue.Value.ToString();
    }

    private void OnEnable()
    {
        DisplayValue.OnValueChangedEvent += DisplayValue_OnValueChanged;
    }

    private void OnDisable()
    {
        DisplayValue.OnValueChangedEvent -= DisplayValue_OnValueChanged;
    }

    private void DisplayValue_OnValueChanged(int value)
    {
        TMP_Text.text = value.ToString();
    }
}