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
        if (Input.GetMouseButtonDown(0)) 
        {
            RaycastHit hit;
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                GameObject hitObject = hit.transform.gameObject;

                if (hitObject.CompareTag("Brick")) // Check if the object is a brick
                {
                    Destroy(hitObject); 
                    gameManager.AddScore(100);
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
