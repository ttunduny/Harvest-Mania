using UnityEngine;
using TMPro;

public class Tractor : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float rotateSpeed = 60f;

    public TextMeshProUGUI scoreText;

    private float numberOfLogs = 0;

    private void Start()
    {
        UpdateScore();
    }

    // Update is called once per frame
    void Update()
    {
        //Move the truck
        float moveInput = Input.GetAxis("Vertical"); // Returns -1 (S/↓), 0, or 1 (W/↑)

        // Move only if there's input (optional: remove 'if' for tank-like continuous movement)
        if (moveInput != 0)
        {
            transform.Translate(Vector3.forward * moveInput * moveSpeed * Time.deltaTime, Space.Self);
        }

        float rotation = Input.GetAxis("Horizontal");

        //Rotate the truck
        transform.Rotate(Vector3.up * rotateSpeed * rotation * Time.deltaTime);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Log")
        {
            //Play Picking Sound
            GameManager.gameManagerInstance.PlayCollectionSound();
            numberOfLogs = numberOfLogs + 1;
            UpdateScore();

            //Update the Highscore
            GameManager.gameManagerInstance.SetHighScore(numberOfLogs);

            Destroy(other.gameObject);
        }
        if (other.tag == "LogSmall")
        {
            //Play Picking Sound
            GameManager.gameManagerInstance.PlayCollectionSound();
            numberOfLogs = numberOfLogs + 0.5f;
            UpdateScore();

            //Update the Highscore
            GameManager.gameManagerInstance.SetHighScore(numberOfLogs);

            Destroy(other.gameObject);
        }
    }


    private void UpdateScore()
    {
        scoreText.text = numberOfLogs.ToString();
    }
}
