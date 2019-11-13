using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerController : MonoBehaviour
    {

        #region Public Fileds
        public float Gravity = 9.8f;//重力
        public GameObject PlayerModel;//玩家模型
        public float MovementSpeed = 3f;//前进速度
        public float BackSpeed = 1f;
        public float JumpSpeed = 10f;//垂直移动速度
        public float RotationSpeed = 100f;//旋转速度
        #endregion

        #region Private Fileds
        private CharacterController _playerController;//玩家控制器
        private Vector3 _moveDirection;//移动方向
        private Animator _anim;//PlayerModel上的Animator
        private bool _stop;//是否停止运动
        #endregion

        #region MonoBehavior Callbacks
        private void Start()
        {
            _playerController = GetComponent<CharacterController>();
            _anim = PlayerModel.GetComponent<Animator>();
        }

        private void Update()
        {
            Move();
            Rotate();
        }

        #endregion

        #region Private Methods
        /// <summary>
        /// z轴移动，
        /// </summary>
        void Move()
        {
            float v = Input.GetAxis("Vertical");
            if (v == 0)
            {
                _anim.SetBool("MoveBack", false);
                _anim.SetBool("MoveForward", false);
            }

            if (_playerController.isGrounded)
            {
                _moveDirection = new Vector3(0, 0, v);
                if(v > 0)
                {
                    _anim.SetBool("MoveForward", true);
                    _moveDirection = transform.TransformDirection(_moveDirection*MovementSpeed);
                }else if (v < 0)
                {
                    _anim.SetBool("MoveBack", true);
                    _moveDirection = transform.TransformDirection(_moveDirection * BackSpeed);
                }
            }
            _moveDirection.y -= Gravity * Time.deltaTime;
            _playerController.Move(_moveDirection * Time.deltaTime);

        }

        //旋转
        void Rotate()
        {
            float h = Input.GetAxis("Horizontal");

            Vector3 originEuler = transform.eulerAngles;
            Quaternion targetRotation = Quaternion.Euler(new Vector3(0, h*90, 0) + originEuler);
            transform.rotation = Quaternion.Lerp(this.transform.rotation, targetRotation, Time.deltaTime * RotationSpeed);

        }

        #endregion
    }

}