using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class CheckCollisions : MonoBehaviour
{

    // public GameObject RestartPanel;

    public int score;
    public TextMeshProUGUI CoinText;


    public PlayerController playerController;
    Vector3 PlayerStartPos;
    public GameObject speedBoosterIcon;
    public GameObject speedBoosterIconReverse;
    private InGameRanking inGameRanking;

    public CameraShake cameraShake;
    public UIManager uimanager;

    public SoundManager soundManager;

    //private int soundLimitCount;

    private void Start()
    {
        PlayerStartPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        speedBoosterIcon.SetActive(false);
        inGameRanking = FindObjectOfType<InGameRanking>();
    }




    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finish"))
        {
            Playerfinished();
            if (inGameRanking.namesTxt[6].text == "Player")
            {
                Debug.Log("You win!!");
                soundManager.completedSound();
                playerController.PlayerAnim.SetBool("win",true);
            }
            else
            {
                Debug.Log("You lose!..");
                soundManager.loseSound();
                playerController.PlayerAnim.SetBool("lose", true);
            }
        }

        if (other.CompareTag("Coin"))
        {
            Debug.Log("Coin Collected");
            AddCoin();
            soundManager.collectCoinSound();
            //Destroy(other.gameObject);
            other.gameObject.SetActive(false);
        }


            if (other.CompareTag("speedboost"))
        {
            playerController.runningSpeed += 3f;
            speedBoosterIcon.SetActive(true);
            //soundLimitCount++;
            soundManager.speedBoostSound();
            StartCoroutine(SlowAfterAWhileCoroutine());
        }
        else if (other.CompareTag("bumper"))
        {
            playerController.runningSpeed -= 3f;
            speedBoosterIconReverse.SetActive(true);
            soundManager.slowDownSound();
            StartCoroutine(RunFasterAfterHitBumper());
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("obstacle"))
        {
            cameraShake.CameraShakesCall();
            uimanager.StartCoroutine("WhiteEffect");
            soundManager.turnBackSound();
            StartCoroutine(WaitAfterDie());
            
           // GameManager.instance.RestartLevel();
            transform.position = PlayerStartPos;
        }
    }

    public void AddCoin()
    {
        score++;
        CoinText.text = "Score: " + score.ToString();
    }



    void Playerfinished()
    {
        playerController.runningSpeed = 0f;
        playerController.limitX = 0f;
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
    private IEnumerator RunFasterAfterHitBumper()
    {
        yield return new WaitForSeconds(2.0f);
        playerController.runningSpeed = playerController.runningSpeed + 3f;
        speedBoosterIconReverse.SetActive(false);
    }
    private IEnumerator WaitAfterDie()
    {
        yield return new WaitForSeconds(2.0f);
    }
}
