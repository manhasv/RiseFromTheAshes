using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    CharacterController controller;
    public float speed = 12f;
    public float jumpHeight = 5f;
    public float gravity = 9.81f;
    public float airControl = 10f;
    Vector3 input, moveDirection;

    public AudioClip jumpSFX;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVeritcal = Input.GetAxis("Vertical");

        input = (transform.right * moveHorizontal + transform.forward * moveVeritcal).normalized;
        input *= speed;

        if (controller.isGrounded)
        {
            moveDirection = input;

            if (Input.GetButton("Jump"))
            {
                moveDirection.y = Mathf.Sqrt(2 * jumpHeight * gravity);
                AudioSource.PlayClipAtPoint(jumpSFX, transform.position);
            }
            else
            {
                moveDirection.y = 0.0f;
            }
        }
        else
        {
            input.y = moveDirection.y;
            moveDirection = Vector3.Lerp(moveDirection, input, airControl * Time.deltaTime);
        }

        moveDirection.y -= gravity * Time.deltaTime;

        controller.Move(moveDirection * Time.deltaTime);
    }
}
