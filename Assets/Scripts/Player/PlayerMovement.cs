using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class PlayerMovement : MonoBehaviour
{
    public bool CanMove=true;
    public float MoveSpeed = 9f;
    public float jumpHeight=2000f;
    public Transform playerBody;
    public Transform playerCam;
    public AudioSource audioWalk;

    public float mouseX;
    public float mouseY;
    public float mouseSentitivity = 100f;
    private float xRotation = 0f;
    private bool _jumped=false;

    private void Start()
    {
        Cursor.lockState=CursorLockMode.Locked;

        // starting variables
        if (StaticGlobals.GodMode)
        {
            this.gameObject.GetComponent<Vida>().godMode = true;
        }
    }
    void IsJumping()
    {

    }
    void IsMoving(bool _walking)
    {
        // SOUND
        if (audioWalk != null)
        {
            if (!audioWalk.isPlaying && _walking && !_jumped)
            {
                audioWalk.Play();
            }
            else if (!_walking)
            {
                audioWalk.Stop();
            }
        }
    }

    void JumpReset()
    {
        _jumped = false;
    }

    void Update()
    {
        /*
        if (Input.GetKey(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            CanMove = false;
            SceneManager.LoadScene("MainMenu");
        }
        */

        if (CanMove)
        {
            // Movement keys
            if (Input.GetKey(KeyCode.W))
            {
                playerBody.transform.Translate(Vector3.forward * MoveSpeed * Time.deltaTime, Space.Self);
                IsMoving(true);
            }
            if (Input.GetKey(KeyCode.S))
            {
                playerBody.transform.Translate(Vector3.back * MoveSpeed * Time.deltaTime, Space.Self);
                IsMoving(true);
            }
            if (Input.GetKey(KeyCode.A))
            {
                playerBody.transform.Translate(Vector3.left * MoveSpeed * Time.deltaTime, Space.Self);
                IsMoving(true);
            }
            if (Input.GetKey(KeyCode.D))
            {
                playerBody.transform.Translate(Vector3.right * MoveSpeed * Time.deltaTime, Space.Self);
                IsMoving(true);
            }

            if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
            {
                IsMoving(false);
            }

            /*
            // JUMP
            if (Input.GetKeyDown(KeyCode.Space))
            {
                GetComponent<Rigidbody>().AddRelativeForce(Vector3.up * jumpHeight);
                IsMoving(false);
                _jumped=true;
                Invoke(nameof(JumpReset), 1f);
            }
            */

            // MOUSE VIEW
            mouseX = Input.GetAxis("Mouse X") * mouseSentitivity * Time.deltaTime;
            mouseY = Input.GetAxis("Mouse Y") * mouseSentitivity * Time.deltaTime;
            xRotation = Mathf.Clamp(-mouseY, -90f, 90f);

            playerCam.transform.Rotate(Vector3.right * xRotation);
            playerBody.Rotate(Vector3.up * mouseX);
        }
    }
}
