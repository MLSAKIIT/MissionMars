using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private float movementX;
    private float movementY;
    public float speed;
    public TextMeshProUGUI countText;
    public GameObject winText;
    public AudioClip collectcoin;
    private int count;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;

        SetCountText();
        winText.SetActive(false);
        
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;

    }


    void SetCountText()
    {
        countText.text = "Score : " + count.ToString();
        if (count >= 12)
            winText.SetActive(true);
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp")){
            AudioSource audio = GetComponent<AudioSource>();
            audio.clip = collectcoin;
            if (other.gameObject.activeSelf)
                audio.Play();

            other.gameObject.SetActive(false);

            count++;
            SetCountText();
        }
        

    }
}
