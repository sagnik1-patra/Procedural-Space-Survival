using UnityEngine;

namespace SpaceSurvival.Player
{
    [RequireComponent(typeof(Rigidbody))]
    public class GravityBody : MonoBehaviour
    {
        public Transform planet;
        private Rigidbody rb;

        void Awake()
        {
            rb = GetComponent<Rigidbody>();
            rb.useGravity = false;
            rb.constraints = RigidbodyConstraints.FreezeRotation;
        }

        void FixedUpdate()
        {
            if (planet != null)
            {
                ApplyGravity();
            }
        }

        public void ApplyGravity()
        {
            Vector3 gravityUp = (transform.position - planet.position).normalized;
            Vector3 localUp = transform.up;

            // Apply force
            rb.AddForce(gravityUp * -9.81f);

            // Align rotation
            Quaternion targetRotation = Quaternion.FromToRotation(localUp, gravityUp) * transform.rotation;
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 50 * Time.deltaTime);
        }
    }
}
