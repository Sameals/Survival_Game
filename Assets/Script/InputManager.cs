using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] PlayerMovement movement;
    [SerializeField] MouseLook mouseLook;
    [SerializeField] Gun gun;
    [SerializeField] GameManager gameManager;

    PlayerControllers controls;
    PlayerControllers.PlayerActions player;

    Vector2 horizontalInput;
    Vector2 mouseInput;

    private void Awake()
    {
        controls = new PlayerControllers();
        player = controls.Player;
        //

        player.Movement.performed += ctx => horizontalInput = ctx.ReadValue<Vector2>();

        player.Jump.performed += _ => movement.OnJumpPressed();

        player.MouseX.performed += ctx => mouseInput.x = ctx.ReadValue<float>();

        player.MouseY.performed += ctx => mouseInput.y = ctx.ReadValue<float>();

        player.Shoot.performed += _ => gun.Shoot();

        player.Pause.performed += _ => gameManager.PauseGame();
    }
    private void Update()
    {
        movement.ReceiveInput(horizontalInput);
        mouseLook.ReceiveInput(mouseInput);
    }
    private void OnEnable()
    {
        controls.Enable();
    }
    private void OnDisable()
    {
        controls.Disable();
    }
}
