using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    //lär behöva vara public för att kunna ändra i en eventuell options meny
    public float mouseSensitivity = 1000f;

    [SerializeField] private Transform playerTransform;

    private float xRotation = 0f;

    PlayerInputController playerInput;


    private void OnEnable()
    {
        playerInput.Enable();
    }

    private void OnDisable()
    {
        playerInput.Disable();
    }

    private void Awake()
    {
        playerInput = new PlayerInputController();
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }


    void Update()
    {

        Vector2 mouseDeltaInput = playerInput.Grounded.MouseDelta.ReadValue<Vector2>();

        float mouseX = mouseDeltaInput.x * mouseSensitivity * Time.deltaTime;
        float mouseY = mouseDeltaInput.y * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerTransform.Rotate(Vector3.up * mouseX);


        //funkar inte längre för det använder gamla input systemet, kan dock nog ha det som grund

        //float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        //float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        //xRotation -= mouseY;
        //xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        //transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        //playerTransform.Rotate(Vector3.up * mouseX);
    }
}
