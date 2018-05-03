using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SunnyLand
{
    // PlayerAnim depends on PlayerController
    [RequireComponent(typeof(PlayerController))]
    public class PlayerAnim : MonoBehaviour
    {
        private PlayerController player;

        #region Unity
        // Use this for initialization
        void Start()
        {
            player = GetComponent<PlayerController>();
            // Subscribe Anim's functions to Player Events
            player.onJump += OnJump;
            player.onMove += OnMove;
            player.onClimb += OnClimb;
        }

        // Update is called once per frame
        void Update()
        {

        }

        #endregion

        #region Custom
        void OnJump()
        {

        }

        void OnMove(float input)
        {

        }

        void OnClimb(float input)
        {

        }

        #endregion


    }
}