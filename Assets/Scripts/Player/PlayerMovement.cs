using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5.0f;
    [SerializeField] private float rotationSpeed = 10.0f;
    [SerializeField] private float jumpHeight = 1.5f; // Nueva variable
    [SerializeField] private Transform cameraTransform;

    private PlayerControls controls;
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;

    void Awake()
    {
        controls = new PlayerControls();
        controller = GetComponent<CharacterController>();
        // Esto obliga al cursor a mantenerse oculto y bloqueado todo el tiempo
        if (Cursor.lockState != CursorLockMode.Locked)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    void OnEnable() => controls.Player.Enable();
    void OnDisable() => controls.Player.Disable();

    void Update()
    {
        // 1. Gravedad y detección de suelo
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = -2f;
        }

        // 2. Lógica de Salto
        // "triggered" detecta el instante exacto en que presionas la tecla
        if (controls.Player.Jump.triggered && groundedPlayer)
        {
            // Fórmula física para una altura específica
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -2.0f * Physics.gravity.y);
        }

        // 3. Input y movimiento relativo a cámara
        Vector2 input = controls.Player.Move.ReadValue<Vector2>();
        Vector3 move = new Vector3(input.x, 0, input.y);

        if (move != Vector3.zero)
        {
            Vector3 forward = Vector3.ProjectOnPlane(cameraTransform.forward, Vector3.up);
            Vector3 right = Vector3.ProjectOnPlane(cameraTransform.right, Vector3.up);
            Vector3 moveDirection = (forward * input.y + right * input.x).normalized;

            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            controller.Move(moveDirection * speed * Time.deltaTime);
        }

        // 4. Aplicar gravedad final
        playerVelocity.y += Physics.gravity.y * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }
}