using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    [CreateAssetMenu(fileName = "Character/CharacterAttribute")]
    public class CharacterAttribute : ScriptableObject
    {
        public float Health = 100f;
        public float Magic = 50f;
        public float Attack = 20f;
        public float Defence = 10f;
        public float MoveSpeed = 8f;
    }

}