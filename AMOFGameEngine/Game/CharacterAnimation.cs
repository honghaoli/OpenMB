﻿using Mogre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AMOFGameEngine.Game
{
    public enum CharacterAnimationType
    {
        CAT_NONE,
        CAT_IDLE_TOP,
        CAT_IDLE_BASE,
        CAT_RUN_TOP,
        CAT_RUN_BASE,
        CAT_JUMP_START,
        CAT_JUMP_LOOP,
        CAT_JUMP_END,
        CAT_HANDS_RELAXED,
        CAT_HANDS_CLOSED,
        CAT_CUSTOME,
        CAT_CUSTOME_BLOCK //This animation can block the character's action
    }
    public class CharacterAnimation
    {
        private string name;
        private CharacterAnimationType type;
        private AnimationState animationState;

        public string Name
        {
            get
            {
                return name;
            }
        }

        public AnimationState AnimationState
        {
            get
            {
                return animationState;
            }
        }

        public CharacterAnimationType Type
        {
            get
            {
                return type;
            }
        }

        public bool IsValid
        {
            get
            {
                return animationState != null;
            }
        }

        public CharacterAnimation(string name, AnimationState animationState, CharacterAnimationType type)
        {
            this.name = name;
            this.animationState = animationState;
            this.type = type;
        }
    }
}
