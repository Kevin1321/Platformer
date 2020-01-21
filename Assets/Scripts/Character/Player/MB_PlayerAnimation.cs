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


        private readonly float crouch = 0;
        private readonly float fall = .1f;
        private readonly float hurt = .2f;
        private readonly float idle = .3f;
        private readonly float jump = .4f;
        private readonly float run = .5f;

        private readonly string animationState = "Blend";

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
                AnimatiorComponent.SetFloat(animationState, idle);

                if (Input.GetKey(Down.InputKey))
                {
                    isCrouching = true;
                    AnimatiorComponent.SetFloat(animationState, crouch);
                }

                if (Input.GetKey(Left.InputKey))
                {
                    SpriterRendererComponent.flipX = true;

                    if (isCrouching) return;
                    
                    AnimatiorComponent.SetFloat(animationState, run);
                }

                if (Input.GetKey(Right.InputKey))
                {
                    SpriterRendererComponent.flipX = false;

                    if (isCrouching) return;
                    
                    AnimatiorComponent.SetFloat(animationState, run);
                }
            }

            if (velocity.y < -0.01f)
            {
                AnimatiorComponent.SetFloat(animationState, fall);
            }
            if(velocity.y > 0.01f)
            {
                AnimatiorComponent.SetFloat(animationState, jump);
            }
        }
    }
}