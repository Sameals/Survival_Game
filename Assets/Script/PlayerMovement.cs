using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] CharacterController controller;
    [SerializeField] float speed = 10f;
    [SerializeField] float jumpHeight = 3.5f;
    [SerializeField] private AudioClip[] audioClipArray;

    Vector2 horizontalInput;
    bool jump;
    [SerializeField] float gravity = -30f; //-9.81
    Vector3 verticalVelocity = Vector3.zero;
    [SerializeField] LayerMask groundMask;
    bool isGrounded;
    bool isWalking;

    private void Update()
    {
        
        isGrounded = Physics.CheckSphere(transform.position, 0.1f, groundMask);
        if (isGrounded)
        {
            verticalVelocity.y = 0f;
        }
        Vector3 horizontalVelocity = (transform.right * horizontalInput.x + transform.forward * horizontalInput.y) * speed;
        controller.Move(horizontalVelocity * Time.deltaTime);
        
        //jump
        if (jump)
        {
            if(isGrounded)
            {
                verticalVelocity.y = Mathf.Sqrt(-2 * jumpHeight * gravity);
            }
            jump = false;
        }

        verticalVelocity.y += gravity * Time.deltaTime;
        controller.Move(verticalVelocity * Time.deltaTime);
    }
    public void ReceiveInput(Vector2 _horizontalInput)
    {
        horizontalInput = _horizontalInput;
        //Debug.Log(horizontalInput);
        if (isWalking)
        {
            PlaySound(audioClipArray, Camera.main.transform.position);
        }
        
    }
    public void OnJumpPressed()
    {
        jump = true;
    }
    private void PlaySound(AudioClip[] audioClipArray, Vector3 position, float volume = 1f)
    {
        AudioSource.PlayClipAtPoint(audioClipArray[Random.Range(0,audioClipArray.Length)], position, volume);
    }
}
