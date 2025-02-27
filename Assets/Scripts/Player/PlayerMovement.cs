using System;
using System.Collections;
using System.Collections.Generic;
using Singletons;
using Unity.VisualScripting;
using UnityEngine.InputSystem;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerMovement : CharacterController
{
   
    
    // Start is called before the first frame update


    private PlayerInputActions playerInputActions;
    private InputAction movement;
    private InputAction aim;
    private bool aimsLeft = false;

    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
    }

    private void OnEnable()
    {
        GetComponent<AbilitySystemComponent>().abilityAdded += EnableAbility;
        GetComponent<AbilitySystemComponent>().abilityRemoved += DisableAbility;
        movement = playerInputActions.Player.Movement;
        movement.Enable();
        aim = playerInputActions.Player.Aim;
        aim.Enable();
        
        playerInputActions.Player.Jump.performed += Jump;
        playerInputActions.Player.Jump.Enable();
        
        playerInputActions.Player.Throw.performed += Throw;
        if (GetComponent<AbilitySystemComponent>().HasAbility(GameplayTags.GetGameplayTagsInstance().GameplayTagList["Throw"]))
        {
            playerInputActions.Player.Throw.Enable();
        }

        playerInputActions.Player.Bat.performed += Bat;
        if (GetComponent<AbilitySystemComponent>().HasAbility(GameplayTags.GetGameplayTagsInstance().GameplayTagList["Throw"]))
        {
            playerInputActions.Player.Bat.Enable();
        }
        
    }

    private void EnableAbility(GameplayTag gTag)
    {
        playerInputActions.FindAction(gTag.tagName).Enable();
    }

    private void DisableAbility(GameplayTag gTag)
    {
        playerInputActions.FindAction(gTag.tagName).Disable();
    }

    private void Bat(InputAction.CallbackContext obj)
    {
        BatSwing();
    }

    private void Throw(InputAction.CallbackContext obj)
    {
        armAnimator.SetTrigger("Throw");
    }

    private void Jump(InputAction.CallbackContext obj)
    {
        if (canJump)
        {
            Jump();
        }
        
    }


    // Update is called once per frame
    void Update()
    {
        horizontal = movement.ReadValue<Vector2>().x;
        animator.SetFloat("movementX", horizontal);
        armAnimator.SetFloat("movementX",horizontal);
        
        target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 aimValue = aim.ReadValue<Vector2>();
        aimValue *= 300;
        if (aimValue != Vector2.zero)
        {
            target.x = transform.position.x + (aimValue.x);
            target.y = transform.position.y + (aimValue.y);
            target.z = transform.position.z;
        }
        
        
        if (target.x < transform.position.x)
        {
            if (!aimsLeft)
            {
                armAnimator.SetTrigger("DirectionChanged");
            }
            aimsLeft = true;
            animator.SetBool("AimsLeft",true);
            
        }
        else
        {
            if (aimsLeft)
            {
                armAnimator.SetTrigger("DirectionChanged");
            }
            aimsLeft = false;
            animator.SetBool("AimsLeft",false);
            
        }
    }

    private void OnDisable()
    {
        movement.Disable();
        aim.Disable();
        playerInputActions.Player.Jump.Disable();
        playerInputActions.Player.Throw.Disable();
        playerInputActions.Player.Bat.Disable();
    }


    private void OnDrawGizmos()
    {
        //Gizmos.DrawLine(transform.position, transform.position + (Vector3.down*0.2f));
        
    }
}
