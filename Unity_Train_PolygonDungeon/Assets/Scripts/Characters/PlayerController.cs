using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerController : CharacterBase
    {
        #region Public Fileds
        
        public float BackSpeed = 1f;
        public float JumpSpeed = 10f;//垂直移动速度
        public float RotationSpeed = 100f;//旋转速度
        #endregion

        #region Private Fileds
        
        private bool _stop;//是否停止运动
        #endregion

        #region MonoBehavior Callbacks
        protected override void Start()
        {
            base.Start();
        }

        protected override void OnUpdate()
        {
            Move();
            Rotate();
            Attack();
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
                if (v > 0)
                {
                    _anim.SetBool("MoveForward", true);
                    _moveDirection = transform.TransformDirection(_moveDirection * MoveSpeedValue);
                }
                else if (v < 0)
                {
                    _anim.SetBool("MoveBack", true);
                    _moveDirection = transform.TransformDirection(_moveDirection * BackSpeed);
                }
            }
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

        #region Override Methods
        public override void Attack()
        {
            if (Input.GetMouseButton(0))
            {
                _anim.SetTrigger("Attack");
            }
        }
        #endregion
    }

}

