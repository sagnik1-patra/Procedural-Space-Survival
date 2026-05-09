using UnityEngine;

namespace SpaceSurvival.Player
{
    [RequireComponent(typeof(Rigidbody))]
    public class FirstPersonController : MonoBehaviour
    {
        public float mouseSensitivity = 100f;
        public float walkSpeed = 6f;
        public float jumpForce = 220f;
        public LayerMask groundedMask;

        private Transform cameraTransform;
        private Rigidbody rb;
        private float verticalLookRotation;
        private bool grounded;

        void Awake()
        {
            rb = GetComponent<Rigidbody>();
            cameraTransform = GetComponentInChildren<Camera>().transform;
        }

        void Update()
        {
            // Rotation
            transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime);
            verticalLookRotation += Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
            verticalLookRotation = Mathf.Clamp(verticalLookRotation, -90, 90);
            cameraTransform.localEulerAngles = Vector3.left * verticalLookRotation;

            // Jump
            if (Input.GetKeyDown(KeyCode.Space) && grounded)
            {
                rb.AddForce(transform.up * jumpForce);
            }

            // Ground check
            Ray ray = new Ray(transform.position, -transform.up);
            grounded = Physics.Raycast(ray, 1.1f, groundedMask);
        }

        void FixedUpdate()
        {
            // Movement
            Vector3 moveDir = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
            Vector3 targetMoveAmount = moveDir * walkSpeed;
            rb.MovePosition(rb.position + transform.TransformDirection(targetMoveAmount) * Time.fixedDeltaTime);
        }
    }
}
