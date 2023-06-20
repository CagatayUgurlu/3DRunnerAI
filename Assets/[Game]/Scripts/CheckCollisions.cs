using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CheckCollisions : MonoBehaviour
{
    public PlayerController playerController;
    public GameObject RestartPanel;
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
            RestartLevel();
        }
    }

    private static void RestartLevel() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
