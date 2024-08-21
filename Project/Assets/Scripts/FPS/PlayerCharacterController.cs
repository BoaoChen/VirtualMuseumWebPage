using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterController : MonoBehaviour
{
    public static PlayerCharacterController Instance;
    public Camera playerCamera;
    public float gravityDownForce = 20f;
    public float maxSpeedOnGround = 8f;
    public float moveSharpnessOnGround = 15f;
    public float cameraHeightRatio = 0.9F;
    private CharacterController characterController;
    private PlayerInputHandle inputHandler;
    private float targetCharacterHeight = 1.8f;
    public float rotationSpeed = 200f;
    private float cameraVerticalAngle = 0f;
    public Vector3 CharacterVelocity { get; set; }

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        inputHandler = GetComponent<PlayerInputHandle>();
        characterController.enableOverlapRecovery = true;
        UpdateCharacterHeight();
    }
    private void Update()
    {
        HandleCharacterMovement();
    }
    private void UpdateCharacterHeight()
    {
        characterController.height = targetCharacterHeight;
        characterController.center = Vector3.up * characterController.height * 0.5f;
        playerCamera.transform.localPosition = Vector3.up * characterController.height * 0.9f;
    }
    private void HandleCharacterMovement()
    {
        //相机水平旋转
        transform.Rotate(new Vector3(0, inputHandler.GetMouseLookHorizontal() * rotationSpeed, 0), Space.Self);
        //相机上下旋转
        cameraVerticalAngle += inputHandler.GetMouseLookVertical() * rotationSpeed;
        cameraVerticalAngle = Mathf.Clamp(cameraVerticalAngle, -89f, 89f);
        playerCamera.transform.localEulerAngles = new Vector3(-cameraVerticalAngle, 0, 0);
        Vector3 worldSpaceMoveInput = transform.TransformVector(inputHandler.GetMoveInput());
        if (characterController.isGrounded)
        {
            Vector3 targetVelocity = worldSpaceMoveInput * maxSpeedOnGround;

            CharacterVelocity = Vector3.Lerp(CharacterVelocity, targetVelocity,
                moveSharpnessOnGround * Time.deltaTime);
        }
        else
        {
            CharacterVelocity += Vector3.down * gravityDownForce * Time.deltaTime;
        }
        characterController.Move(CharacterVelocity * Time.deltaTime);
    }
}
