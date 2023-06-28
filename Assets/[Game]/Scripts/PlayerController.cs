using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float runningSpeed;
    public float xSpeed;
    public float limitX;
    private Touch touch;

    public Animator PlayerAnim;
    public GameObject Player;
    void Start()
    {
        PlayerAnim = Player.GetComponentInChildren<Animator>();
    }


    void Update()
    {
        SwipeCheck();

    }

    private void SwipeCheck()
    {
        float newX = 0;
        float touchXDelta = 0;

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            touch = Input.GetTouch(0);
            //Debug.Log(Input.GetTouch(0).deltaPosition.x / Screen.width);
            touchXDelta = Input.GetTouch(0).deltaPosition.x / Screen.width;


        }
        else if (Input.GetMouseButton(0)) // Buradaki yazdýðýmýz else if telefonun çalýþmadýðý durumda (unity remote çalýþmadýðý durumda) oyundan elimizle kontrol etmek için.
        {

            touchXDelta = Input.GetAxis("Mouse X");
        }
        newX = transform.position.x + xSpeed * touchXDelta * Time.deltaTime;
        newX = Mathf.Clamp(newX, -limitX, limitX);

        //Vector3 newPosition = new Vector3(transform.position.x, transform.position.y, (1) transform.position.z);
        //Vector3 newPosition = new Vector3( (2) transform.position.x, transform.position.y, (1) transform.position.z + runningSpeed * Time.deltaTime);
        Vector3 newPosition = new Vector3(newX, transform.position.y, transform.position.z + runningSpeed * Time.deltaTime);
        transform.position = newPosition;



    }
        
    
}
