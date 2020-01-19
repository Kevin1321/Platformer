using UnityEngine;
using Values;


namespace Player
{
    public class MB_GroundDetection : MonoBehaviour
    {
        [SerializeField] private SO_Bool IsGrounded = null;


        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (!collision.CompareTag(System.C_TagStrings.GROUND)) return;

            IsGrounded.Value = true;
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (!collision.CompareTag(System.C_TagStrings.GROUND)) return;

            IsGrounded.Value = false;
        }
    }
}