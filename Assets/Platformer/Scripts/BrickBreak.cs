using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickBreak : MonoBehaviour
{
    private Camera mainCamera;
    private GameManager gameManager;

    void Start()
    {
        mainCamera = Camera.main;
        gameManager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Check if left mouse button was clicked
        {
            RaycastHit hit;
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                GameObject hitObject = hit.transform.gameObject;

                if (hitObject.CompareTag("Brick")) // Check if the object is a brick
                {
                    Destroy(hitObject); 
                    // Add coin logic 
                }
                else if (hitObject.CompareTag("QuestionBox")) // Check if the object is a question box
                {
                    gameManager.AddCoin();
                }
            }
        }
    }
}
