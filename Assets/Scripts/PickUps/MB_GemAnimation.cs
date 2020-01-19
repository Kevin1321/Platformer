using UnityEngine;


public class MB_GemAnimation : MonoBehaviour
{
    [SerializeField] private Animator Animator = null;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Animator.SetBool("OnPickUp", true);
    }

    public void OnPickUp()
    {
        Destroy(gameObject);
    }
}
