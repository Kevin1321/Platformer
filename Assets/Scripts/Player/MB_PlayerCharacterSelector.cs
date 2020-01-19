using UnityEngine;


namespace Player
{
    public class MB_PlayerCharacterSelector : MonoBehaviour
    {
        [SerializeField] private Animator Animator = null;
        [SerializeField] private SO_PlayerAnimationControllers PlayerAnimationControllers = null;
        [SerializeField] private E_PlayerCharacter CurrentCharacter = E_PlayerCharacter.FOX;


        private void Awake()
        {
            SelectCharacter();
        }

        public void SelectCharacter()
        {
            if ((int)CurrentCharacter < PlayerAnimationControllers.PlayerAnimationControllers.Count)
                Animator.runtimeAnimatorController = PlayerAnimationControllers.PlayerAnimationControllers[(int)CurrentCharacter];
        }
    }
}