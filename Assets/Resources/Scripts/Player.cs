using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public void Fire(InputAction.CallbackContext context)
    {
        Shoot();
    }
    void Shoot()
    {
        Debug.Log("You shot!");
    }

    private void Update()
    {
        if (Input.mousePosition.y > 0)
        {

            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 5.23f;

            Vector3 objectPos = UnityEngine.Camera.main.WorldToScreenPoint(transform.position);

            mousePos.x = mousePos.x - objectPos.x;
            mousePos.y = mousePos.y - objectPos.y;

            float angle = Mathf.Atan2(mousePos.x, mousePos.y) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, angle - 90, 0));
        }
    }
}
