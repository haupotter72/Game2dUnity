using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public UnityEvent<Vector2> OnMovementInput;
    public UnityEvent OnAttackk;

    public void OnAttack()
    {
        OnAttackk.Invoke();
    }


    private void OnMovement(InputValue movementValue)
    {
        OnMovementInput.Invoke(movementValue.Get<Vector2>());

    }

   
 

}
