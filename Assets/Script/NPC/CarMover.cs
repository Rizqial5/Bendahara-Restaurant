using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestBR.NPC
{
    public class CarMover : MonoBehaviour
    {

        

        public float speed = 1.0f;
        private Rigidbody2D rb2D;
        private Transform targetLocation;

        void Start()
        {
            rb2D = GetComponent<Rigidbody2D>();
        }

        void FixedUpdate()
        {
            MoveCar(targetLocation);
        }

        private void MoveCar(Transform targetPosition)
        {
            Vector3 direction = ((Vector2)targetPosition.position - rb2D.position).normalized;

            Vector2 velocity = direction * speed  ;

            rb2D.MovePosition(rb2D.position + velocity * Time.fixedDeltaTime);

            
            if (Vector2.Distance(rb2D.position, (Vector2)targetPosition.position) < 0.1f)
            {
                rb2D.velocity = Vector2.zero;
                rb2D.position = (Vector2)targetPosition.position;

                Destroy(gameObject, 0.5f);
            }
        }

        public void SetTarget(Transform target)
        {
            targetLocation = target; 
        }
    }
}
