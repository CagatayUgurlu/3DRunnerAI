using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class CheckCollisions : MonoBehaviour
{
    public int score;
    public TextMeshProUGUI CoinText;
    

    public GameObject RestartPanel;

    public PlayerController playerController;
    Vector3 PlayerStartPos;
    public GameObject speedBoosterIcon;
    public float speedBoost;

    private InGameRanking inGameRanking;


    private void Start()
    {
        PlayerStartPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        speedBoosterIcon.SetActive(false);
        inGameRanking = FindObjectOfType<InGameRanking>();
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
        
        if (other.CompareTag("SpeedBoost"))
        {
            playerController.runningSpeed = playerController.runningSpeed + speedBoost;
            speedBoosterIcon.SetActive(true);
            StartCoroutine(SlowAfterAWhileCoroutine());
        }
        else if (other.CompareTag("Finish"))
        {
            Playerfinished();
            if (inGameRanking.namesTxt[6].text == "Player")
            {
                Debug.Log("You win!!");
                //playerController.PlayerAnim.SetBool
            }
            else
            {
                Debug.Log("You lose!..");
            }
        }
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

    private IEnumerator SlowAfterAWhileCoroutine()
    {
        yield return new WaitForSeconds(2.0f);
        playerController.runningSpeed = playerController.runningSpeed - speedBoost;
        speedBoosterIcon.SetActive(false);
    }
}
