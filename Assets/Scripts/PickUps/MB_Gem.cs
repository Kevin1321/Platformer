using UnityEngine;
using Values;


public class MB_Gem : MonoBehaviour
{
    [SerializeField] private SO_Observable_Int CurrentPoints = null;

    [SerializeField] private int rewardPoints = 0;

    private bool hasBeenPickedUp = false;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (hasBeenPickedUp) return;
        CurrentPoints.Value += rewardPoints;
        hasBeenPickedUp = true;
    }
}
