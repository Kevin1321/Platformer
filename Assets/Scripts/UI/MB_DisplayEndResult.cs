using UnityEngine;
using Values;
using TMPro;


public class MB_DisplayEndResult : MonoBehaviour
{
    [Header("TextMeshPro Component")]
    [SerializeField] private TMP_Text TMP_Text = null;
    
    [Header("Display Values")]
    [SerializeField] private SO_Observable_Int CurrentPoints = null;
    [SerializeField] private SO_Observable_Int CurrentPlayTimeLeft = null;


    private void Awake()
    {
        TMP_Text.text = CalculateEndResult();
        CurrentPoints.ResetValue();
        CurrentPlayTimeLeft.ResetValue();
    }

    private string CalculateEndResult()
    {
        return (CurrentPoints.Value + CurrentPlayTimeLeft.Value).ToString();
    }
}