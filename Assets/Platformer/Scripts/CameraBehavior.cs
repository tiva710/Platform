using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    // public float scrollSpeed = 5.0f;
    // public Transform player;
    // // Update is called once per frame
    // void Update()
    // {
    //     if (Input.GetKey(KeyCode.RightArrow))
    //     {
    //         transform.Translate(new Vector3(scrollSpeed * Time.deltaTime, 0, 0));
    //     }
    //
    //     if (Input.GetKey(KeyCode.LeftArrow))
    //     {
    //         transform.Translate(new Vector3(-scrollSpeed * Time.deltaTime, 0, 0));
    //     }
    // }
    
    public Transform player; // Assign your player GameObject in the Inspector
    public float smoothSpeed = 0.125f;
    public float yOffset; // You can set this in the Inspector to adjust the height of the camera
    public float zOffset; // Set this to how far back you want the camera to be
    
    private Vector3 velocity = Vector3.zero;
    
    void Start()
    {
        // Set the initial camera position based on the yOffset and zOffset
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }
    
    void LateUpdate()
    {
        Vector3 targetPosition = new Vector3(player.position.x, transform.position.y, transform.position.z);
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothSpeed);
    }
}
