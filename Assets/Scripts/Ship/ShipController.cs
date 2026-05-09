using UnityEngine;

namespace SpaceSurvival.Ship
{
    [RequireComponent(typeof(Rigidbody))]
    public class ShipController : MonoBehaviour
    {
        [Header("Flight Settings")]
        public float thrust = 1000f;
        public float pitchSpeed = 50f;
        public float rollSpeed = 50f;
        public float yawSpeed = 50f;
        public float strafeSpeed = 500f;

        private Rigidbody rb;
        private Vector3 thrustInput;
        private Vector3 rotationInput;

        void Awake()
        {
            rb = GetComponent<Rigidbody>();
            rb.useGravity = false;
            rb.drag = 1f;
            rb.angularDrag = 1f;
        }

        void Update()
        {
            // Thrust Input
            float forward = Input.GetAxis("Vertical"); // W/S
            float strafe = Input.GetAxis("Horizontal"); // A/D
            float vertical = 0;
            if (Input.GetKey(KeyCode.Space)) vertical = 1;
            if (Input.GetKey(KeyCode.LeftControl)) vertical = -1;

            thrustInput = new Vector3(strafe, vertical, forward);

            // Rotation Input (Mouse/Keys)
            float pitch = -Input.GetAxis("Mouse Y");
            float yaw = Input.GetAxis("Mouse X");
            float roll = 0;
            if (Input.GetKey(KeyCode.Q)) roll = 1;
            if (Input.GetKey(KeyCode.E)) roll = -1;

            rotationInput = new Vector3(pitch, yaw, roll);
        }

        void FixedUpdate()
        {
            ApplyFlightForces();
        }

        void ApplyFlightForces()
        {
            // Apply Thrust
            rb.AddRelativeForce(Vector3.forward * thrustInput.z * thrust * Time.fixedDeltaTime);
            rb.AddRelativeForce(Vector3.right * thrustInput.x * strafeSpeed * Time.fixedDeltaTime);
            rb.AddRelativeForce(Vector3.up * thrustInput.y * strafeSpeed * Time.fixedDeltaTime);

            // Apply Rotation
            rb.AddRelativeTorque(Vector3.right * rotationInput.x * pitchSpeed * Time.fixedDeltaTime);
            rb.AddRelativeTorque(Vector3.up * rotationInput.y * yawSpeed * Time.fixedDeltaTime);
            rb.AddRelativeTorque(Vector3.forward * rotationInput.z * rollSpeed * Time.fixedDeltaTime);
        }
    }
}
