using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    [CreateAssetMenu(fileName ="Attack/AttackBase Test")]
    public class AttackBase : ScriptableObject
    {
        public AnimationClip AttackClip;

        AnimatorOverrideController _animOverrideController;

        /// <summary> 更改攻击动画 </summary>
        public void ChangeAttackAnimationClip(CharacterBase cb)
        {
            _animOverrideController = new AnimatorOverrideController(cb.Anim.runtimeAnimatorController);
            cb.Anim.runtimeAnimatorController = _animOverrideController;
            _animOverrideController["mixamo.com"] = AttackClip;
        }

    }

}