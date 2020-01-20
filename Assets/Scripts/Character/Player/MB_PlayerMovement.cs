using UnityEngine;
using Values;
using InputHandling;

namespace Player
{
    public class MB_PlayerMovement : MonoBehaviour
    {
        [Header("InputKeys")]
        [SerializeField] private SO_InputKey Down = null;
        [SerializeField] private SO_InputKey Jump = null;
        [SerializeField] private SO_InputKey Left = null;
        [SerializeField] private SO_InputKey Right = null;

        [Header("Ground Detection")]
        [SerializeField] private SO_Bool IsGrounded = null;

        [Header("Rigidbody Component")]
        [SerializeField] Rigidbody2D Rigidbody2DComponent = null;


        private readonly float runSpeed = 2;
        private readonly float crouchSpeed = 1;
        private readonly float jumpForce = 250;

        private bool isCrouching = false;
        private bool isFacingLeft = false;


        private void Update()
        {
            if (Input.GetKeyUp(Down.InputKey))
            {
                isCrouching = false;
            }
        }

        private void FixedUpdate()
        {
            Vector2 velocity = Rigidbody2DComponent.velocity;

            if (IsGrounded.Value)
            {
                if (Input.GetKey(Down.InputKey))
                {
                    isCrouching = true;
                }

                if (Input.GetKey(Left.InputKey))
                {
                    isFacingLeft = true;

                    if (isCrouching)
                    {
                        velocity.x = -crouchSpeed;
                    }
                    else
                    {
                        velocity.x = -runSpeed;
                    }
                     
                    Rigidbody2DComponent.velocity = velocity;
                }

                if (Input.GetKey(Right.InputKey))
                {
                    isFacingLeft = false;

                    if (isCrouching)
                    {
                        velocity.x = crouchSpeed;
                    }
                    else
                    {
                        velocity.x = runSpeed;
                    }

                    Rigidbody2DComponent.velocity = velocity;
                }

                if (Input.GetKey(Jump.InputKey))
                {
                    Vector2 jumpForceVector = new Vector2(0, jumpForce);

                    if (isCrouching)
                    {
                        jumpForceVector *= 1.3f;

                        if (isFacingLeft)
                        {
                            jumpForceVector.x = -100;

                        }
                        else
                        {
                            jumpForceVector.x = 100;
                        }
                    }

                    Rigidbody2DComponent.AddForce(jumpForceVector);
                }
            }
        }
    }
}