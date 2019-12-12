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

        [Header("运动参数")]
        public float Gravity = 9.8f;//重力

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
        protected Vector3 _moveDirection = Vector3.zero;//移动方向
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

        protected virtual void Update()
        {
            _moveDirection.y -= Gravity * Time.deltaTime;
            OnUpdate();
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

        protected virtual void OnUpdate() { }
        #endregion

    }

}