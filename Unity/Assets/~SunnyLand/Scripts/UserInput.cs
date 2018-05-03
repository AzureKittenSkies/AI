using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SunnyLand
{
    [RequireComponent(typeof(PlayerController))]
    public class UserInput : MonoBehaviour
    {

        #region Variables
        private PlayerController player;
        private float inputH, inputV;
        private bool isJumping = false, isCrouching = false;

        #endregion  

        void Start()
        {
            player = GetComponent<PlayerController>();

        }


        // Update is called once per frame
        void Update()
        {
            GetInput();
            player.Move(inputH);

            if (isJumping)
            {
                player.Jump();
            }

            if (isCrouching)
            {
                player.Crouch();
            }

            else
            {
                player.UnCrouch();
            }
        }

        void GetInput()
        {
            inputH = Input.GetAxis("Horizontal");
            inputV = Input.GetAxis("Vertical");
            isJumping = Input.GetKeyDown(KeyCode.Space);
            isCrouching = Input.GetKeyDown(KeyCode.LeftControl);
        }




    }
}