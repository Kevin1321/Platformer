using UnityEngine;
using Values;
using InputHandling;

namespace Player
{
    public class MB_PlayerAnimation : MonoBehaviour
    {
        [Header("InputKey")]
        [SerializeField] private SO_InputKey Down = null;
        [SerializeField] private SO_InputKey Left = null;
        [SerializeField] private SO_InputKey Right = null;

        [Header("Ground Detection")]
        [SerializeField] private SO_Bool IsGrounded = null;

        [Header("Visual Components")]
        [SerializeField] private Animator AnimatiorComponent = null;
        [SerializeField] private SpriteRenderer SpriterRendererComponent = null;

        [Header("Rigidbody Component")]
        [SerializeField] Rigidbody2D Rigidbody2DComponent = null;


        private bool isCrouching = false;


        private void Update()
        {
            Vector2 velocity = Rigidbody2DComponent.velocity;

            if (Input.GetKeyUp(Down.InputKey))
            {
                isCrouching = false;
            }

            if (IsGrounded.Value)
            {
                //Idle
                AnimatiorComponent.SetFloat("Blend", .3f);

                if (Input.GetKey(Down.InputKey))
                {
                    isCrouching = true;
                    //Crouch
                    AnimatiorComponent.SetFloat("Blend", 0);
                }

                if (Input.GetKey(Left.InputKey))
                {
                    SpriterRendererComponent.flipX = true;

                    if (isCrouching) return;
                    
                    //Run
                    AnimatiorComponent.SetFloat("Blend", .5f);
                }

                if (Input.GetKey(Right.InputKey))
                {
                    SpriterRendererComponent.flipX = false;

                    if (isCrouching) return;
                    
                    //Run
                    AnimatiorComponent.SetFloat("Blend", .5f);
                }
            }

            if (velocity.y < -0.01f)
            {
                //Fall
                AnimatiorComponent.SetFloat("Blend", .1f);
            }
            if(velocity.y > 0.01f)
            {
                //Jump
                AnimatiorComponent.SetFloat("Blend", .4f);
            }
        }
    }
}