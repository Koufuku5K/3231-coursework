using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseControl : MonoBehaviour
{
    public float mouseSens = 200f;

    public float rotateX = 0f;

    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        //Hide mouse cursor
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSens * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSens * Time.deltaTime;

        rotateX -= mouseY;
        rotateX = Mathf.Clamp(rotateX, -85f, 85f);
        transform.localRotation = Quaternion.Euler(rotateX, 0f, 0f);

        player.Rotate(Vector3.up * mouseX);
    }
}
