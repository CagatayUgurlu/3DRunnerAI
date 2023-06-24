using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class CheckCollisions : MonoBehaviour
{

   // public GameObject RestartPanel;

    public PlayerController playerController;
    Vector3 PlayerStartPos;
    public GameObject speedBoosterIcon;
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
        if (other.CompareTag("Finish"))
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


        if (other.CompareTag("speedboost"))
        {
            playerController.runningSpeed += 3f;
            speedBoosterIcon.SetActive(true);
            StartCoroutine(SlowAfterAWhileCoroutine());
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("obstacle"))
        {
            GameManager.instance.RestartLevel();
            transform.position = PlayerStartPos;
        }
    }
    



    void Playerfinished()
    {
        playerController.runningSpeed = 0f;
        transform.Rotate(transform.rotation.x, 180, transform.rotation.z, Space.Self);
        GameManager.instance.RestartPanel.SetActive(true);
        GameManager.instance.isGameOver = true;
    }

    private IEnumerator SlowAfterAWhileCoroutine()
    {
        yield return new WaitForSeconds(2.0f);
        playerController.runningSpeed = playerController.runningSpeed - 3f;
        speedBoosterIcon.SetActive(false);
    }
}
