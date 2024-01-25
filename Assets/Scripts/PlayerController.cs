using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using TMPro;

public class player_controller : MonoBehaviour
{
    public float speed = 0;

    public TextMeshProUGUI countText;
    public GameObject winTextObject;

    private Rigidbody rb;
    private float movementX;
    private float movementY;
    private int count;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winTextObject.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);
    }
    
    void OnMove(InputValue inputValue)
    {
        Vector2 movement = inputValue.Get<Vector2>();
        movementX = movement.x;
        movementY = movement.y;
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
            if (count >= 3)
        {
            winTextObject.SetActive(true);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
            SceneManager.LoadScene(0);
        }
    }
}
