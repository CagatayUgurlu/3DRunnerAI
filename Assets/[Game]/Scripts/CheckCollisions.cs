using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CheckCollisions : MonoBehaviour
{
    public int score;
    public TextMeshProUGUI CoinText;
    
    public PlayerController playerController;
    public GameObject RestartPanel;

    public PlayerController PlayerController;
    Vector3 PlayerStartPos;
    public GameObject speedBoosterIcon;


    private void Start()
    {
        PlayerStartPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        speedBoosterIcon.SetActive(false);
    }

    //public int score;
    //public TextMeshProUGUI CoinText;
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("Coin"))
    //    {
    //        Debug.Log("Coin Collected");
    //        AddCoin();
    //        //Destroy(other.gameObject);
    //        other.gameObject.SetActive(false);
    //    }
    //}
    //public void AddCoin()
    //{
    //    score++;
    //    CoinText.text = "Score: " + score.ToString();
    //}

    private void OnTriggerEnter(Collider other)
    {
           
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("obstacle"))
        {
            //RestartLevel();
            transform.position = PlayerStartPos;
        }
    }

    private static void RestartLevel() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void Playerfinished()
    {
        playerController.runningSpeed = 0f;
    }
}
