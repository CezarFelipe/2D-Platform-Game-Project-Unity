using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{


    public PlayerController playerController;

    private PlayerAnimation playerAnimation;
    private PlayerAttack playerAttack;

    private bool crouched = false;

    private void Awake()
    {
        playerAnimation = GetComponent<PlayerAnimation>();
        playerAttack = GetComponent<PlayerAttack>();
    }


    // Update is called once per frame
    void Update()
    {
        bool paused = UIManager.instance.IsPaused();
        if (paused)
        {
            return;
        }
        playerController.Move(Input.GetAxisRaw("Horizontal"));

        if (Input.GetButtonDown("Jump"))
        {
            playerController.Jump();

            if (crouched)
            {
                playerController.PassThroughPlatform();
            }

            /*if (!crouched)
                playerController.Jump();
            else
                playerController.PassThroughPlatform();*/
        }

        if (Input.GetButtonDown("Fire1"))
        {
            playerAttack.Fire();
        }

        if (Input.GetButtonDown("Fire2"))
        {
            playerAttack.MeleeAttack();
        }

        if (Input.GetAxisRaw("Vertical") < 0)
        {

            if (!playerController.GetGrounded())
            {
                playerAnimation.SetCrouch(false);
                return;
            }



            playerAnimation.SetCrouch(true);

            playerController.DisableControls();
            crouched = true;

        }
        else if (Input.GetAxisRaw("Vertical") > -1)
        {

            if (crouched)
            {
                crouched = false;
                playerController.EnableControls();
            }

            playerAnimation.SetCrouch(false);



        }

    }
}
