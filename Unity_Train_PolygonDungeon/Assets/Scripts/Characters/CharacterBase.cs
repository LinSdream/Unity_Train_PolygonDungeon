using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    
    public class CharacterBase : MonoBehaviour
    {

        #region Public Fields
        public CharacterAttribute BaseAtribute;
        public GameObject PlayerModel;//玩家模型
        public AttackBase AttackModel;

        [HideInInspector]public float HP;
        [HideInInspector] public float MP;
        [HideInInspector] public float ATK;
        [HideInInspector] public float DefenceValue;
        [HideInInspector] public float MoveSpeedValue;
        [HideInInspector] public Animator Anim {
            get
            {
                return _anim;
            }
        }
        #endregion

        #region Protected Fields
        protected Animator _anim;
        protected CharacterController _playerController;//玩家控制器
        #endregion 
        #region MonoBehaviour Callbacks
        private void Awake()
        {
            HP = BaseAtribute.Health;
            MP = BaseAtribute.Magic;
            ATK = BaseAtribute.Attack;
            DefenceValue = BaseAtribute.Defence;
            MoveSpeedValue = BaseAtribute.MoveSpeed;

            Init();
        }

        protected virtual void Start()
        {
            _playerController = GetComponent<CharacterController>();
            _anim = PlayerModel.GetComponent<Animator>();
            AttackModel.ChangeAttackAnimationClip(this);
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