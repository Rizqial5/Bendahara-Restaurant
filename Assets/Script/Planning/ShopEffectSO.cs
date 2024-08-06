using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestBR.Planning
{
    public class ShopEffectSO : ScriptableObject
    {
        [SerializeField] private EffectEnum effectEnum;
        public virtual void ActivateEffect()
        {

        }

        public virtual string GetEffectDescription()
        {
            return string.Empty;
        }

        public virtual void SetDurationTimer()
        {

        }

        public virtual void ResetValues()
        {

        }

        public EffectEnum GetEffectEnum()
        {
            return effectEnum;
        }


    }
}
