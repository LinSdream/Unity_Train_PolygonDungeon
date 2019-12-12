using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class GoblineMale : CharacterBase
    {
        protected override void Start()
        {
            base.Start();
        }

        protected override void OnUpdate()
        {
            _playerController.Move(_moveDirection * Time.deltaTime);
        }
    }

}