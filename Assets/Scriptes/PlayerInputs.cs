using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputs : MonoBehaviour
{
    [SerializeField] new Camera camera;
    [SerializeField] Player player;
    bool isBlocked = false;
    public int MyProperty { get; set; }

    public bool IsBlocked { get => isBlocked; set => isBlocked = value; }

    void Start()
    {
        camera = Camera.main;
    }

    
    public Quaternion GetDirection()
    {
        Vector3 directionMouse = Input.mousePosition - camera.WorldToScreenPoint(transform.position);
        var angle = Mathf.Atan2(directionMouse.y, directionMouse.x) * Mathf.Rad2Deg;
        Quaternion direction = Quaternion.AngleAxis(90 - angle, Vector3.up);
        return direction;
    }

    public bool PressFire()
    {
        bool fireIsPressed = false;
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            fireIsPressed = true;
        }
        return fireIsPressed;
    }
}
