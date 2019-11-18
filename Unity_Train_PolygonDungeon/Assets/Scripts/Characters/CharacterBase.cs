using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    
    public class CharacterBase : MonoBehaviour
    {

        #region Public Fields
        public CharacterAttribute BaseAtribute;
        
        [HideInInspector]public float HP;
        [HideInInspector] public float MP;
        [HideInInspector] public float AttackValue;
        [HideInInspector] public float DefenceValue;
        [HideInInspector] public float MoveSpeedValue;
        #endregion

        #region MonoBehaviour Callbacks
        private void Awake()
        {
            HP = BaseAtribute.Health;
            MP = BaseAtribute.Magic;
            AttackValue = BaseAtribute.Attack;
            DefenceValue = BaseAtribute.Defence;
            MoveSpeedValue = BaseAtribute.MoveSpeed;

            Init();
        }

        protected virtual void Start()
        {

        }

        protected virtual void Update()
        {
            
        }
        #endregion

        #region Virtual Methods
        /// <summary> Awake 初始化 </summary>
        protected virtual void Init() { }

        /// <summary> Attack方法 </summary>
        public virtual void Attack() { }
        #endregion

    }

}