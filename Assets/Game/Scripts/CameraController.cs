using System;
using UnityEngine;

namespace Game.Scripts
{
    public class CameraController : Singelton<CameraController>
    {
        public Transform target; // The target the camera will follow (e.g., player)
        public Vector3 offset = new Vector3(0, 5, -10); // Adjustable offset for camera position
        public float smoothSpeed = 0.125f; // Speed for smooth camera movement

        public Transform farBack, middleBack;
        public float minHeight, maxHeight;
        public bool stopFollow;

       // private float lastxPos;

       private Vector2 lastPos;

        private void Start()
        {
           // lastxPos = transform.position.x;
           lastPos = transform.position;
        }

        private void Update()
        {
            //
            // float clampedY = Mathf.Clamp(transform.position.y, minHeight, maxHeight);
            // transform.position = new Vector3(transform.position.x, clampedY, transform.position.z);
            if (!stopFollow)
            {
                transform.position = new Vector3(target.position.x, Mathf.Clamp(target.position.y, minHeight, maxHeight),
                    transform.position.z);
                Vector2  amountToMove =  new Vector2(transform.position.x - lastPos.x, transform.position.y - lastPos.y);
                farBack.position = farBack.position+new Vector3(amountToMove.x,amountToMove.y,0);
                middleBack.position  += new Vector3(amountToMove.x   , amountToMove.y, 0)*.5f;
            
            
            
                lastPos = transform.position;
               
            }
          
        }

        private void LateUpdate()
        {
            if (target != null)
            {
                // Desired position based on target and offset
                Vector3 desiredPosition = target.position + offset;

                // Smooth transition to the desired position
                Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

                // Set the camera's position to the smoothed position
                transform.position = smoothedPosition;

                // Optional: make the camera look at the target (useful for third-person view)
                transform.LookAt(target);
            }
        }
    }
}