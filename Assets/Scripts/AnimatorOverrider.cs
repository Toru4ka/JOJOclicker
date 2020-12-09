using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MonoBehaviours
{
    public class AnimatorOverrider : MonoBehaviour
    {
        private Animator _animator;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public void SetAnimations(AnimatorOverrideController overriderController)
        {
            _animator.runtimeAnimatorController = overriderController;
        }
    }
}
