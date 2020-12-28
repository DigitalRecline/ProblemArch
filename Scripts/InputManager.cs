using UnityEngine;
using TigerForge;

public class InputManager : MonoBehaviour
{

    float HorizontalAxis;

    void Update()
    {
        Fire();
        PlayerHorizontalMovement();
    }

    private static void Fire()
    {
        if (Input.GetKey(KeyCode.Space))
        {           
            EventManager.EmitEvent("SHOOT");
        }
    }

    private void PlayerHorizontalMovement()
    {
        HorizontalAxis = Input.GetAxis("Horizontal");

        if (HorizontalAxis > 0 || HorizontalAxis < 0)
        {
            EventManager.SetDataGroup("HORIZONTAL_MOVEMENT", HorizontalAxis);
            EventManager.EmitEvent("HORIZONTAL_MOVEMENT");
        }
    }
}
