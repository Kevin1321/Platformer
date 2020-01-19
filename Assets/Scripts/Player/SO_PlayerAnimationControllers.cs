using System.Collections.Generic;
using UnityEngine;


namespace Player
{
    [CreateAssetMenu(fileName = "PlayerAnimationControllers", menuName = "ScriptableObjects/Player/PlayerAnimationControllers")]
    public class SO_PlayerAnimationControllers : ScriptableObject
    {
        [SerializeField] private List<RuntimeAnimatorController> m_PlayerAnimationControllers = null;
        public List<RuntimeAnimatorController> PlayerAnimationControllers { get{ return m_PlayerAnimationControllers; } }
    }
}