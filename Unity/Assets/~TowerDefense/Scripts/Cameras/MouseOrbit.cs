using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefence
{
    public class MouseOrbit : MonoBehaviour
    {
        #region Variables
        public Transform target;
        public float distance = 5f;
        public float xSpeed = 120f;
        public float ySpeed = 120f;
        public float yMinLimit = -20f;
        public float yMaxLimit = 80f;
        public float distanceMin = 0.5f;
        public float distanceMax = 15f;

        private float x = 0f, y = 0f;
        private Camera cam;

        #endregion

        public float ClampAngle(float angle, float min, float max)
        {
            if (angle < -360f)
            {
                angle += 360f;
            }
            if (angle > 360f)
            {
                angle -= 360f;
            }
            return Mathf.Clamp(angle, min, max);
        }




        // Use this for initialization
        void Start()
        {
            // get the current rotation of the camera
            Vector3 angles = transform.eulerAngles;
            x = angles.y;
            y = angles.x;
            cam = GetComponent<Camera>();
        }

        // Update is called once per frame
        void Update()
        {
            // if the target has been set AND left mouse button is down
            if (target && Input.GetMouseButton(1))
            {
                x += Input.GetAxis("Mouse X") * xSpeed * distance * Time.deltaTime;
                y -= Input.GetAxis("Mouse Y") * ySpeed * Time.deltaTime;

                y = ClampAngle(y, yMinLimit, yMaxLimit);

                Quaternion rotation = Quaternion.Euler(y, x, 0);
                
                float scroll = Input.GetAxis("Mouse ScrollWheel");
                distance = Mathf.Clamp(distance - scroll * 5, distanceMin, distanceMax);

                Vector3 position = rotation * new Vector3(0, 0, -distance) + target.position;

                transform.rotation = rotation;
                transform.position = position;
            }
        }
    }
}