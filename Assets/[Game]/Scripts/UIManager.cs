using System.Collections;
using System.Collections.Generic;
using UnityEditor.Overlays;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    #region PlayerPrefs
    public void Start()
    {
        if (!PlayerPrefs.HasKey("Sound"))
        {
            PlayerPrefs.SetInt("Sound", 1);
        }

        if(!PlayerPrefs.HasKey("Vibration"))
        {
            PlayerPrefs.SetInt("Vibration", 1);
        }
    }
    #endregion


    #region Buttons & Button Functions
    public Animator layoutAnim;

    //Buttons
    public GameObject settings_Open;
    public GameObject settings_Close;
    public GameObject sound_On;
    public GameObject sound_Off;
    public GameObject vibration_On;
    public GameObject vibration_Off;
    public GameObject information;

    public void PanteonURL()
    {
        Application.OpenURL("https://www.panteon.games/");
    }
    //Button Functions
    public void Settings_Open()
    {
        settings_Open.SetActive(false); 
        settings_Close.SetActive(true);
        layoutAnim.SetTrigger("Slide_In");

        if(PlayerPrefs.GetInt("Sound") == 1)
        {
            sound_On.SetActive(true);
            sound_Off.SetActive(false);
            AudioListener.volume = 1;
        }
        else if (PlayerPrefs.GetInt("Sound") == 2)
        {
            sound_On.SetActive(false);
            sound_Off.SetActive(true);
            AudioListener.volume = 0;
        }


        if (PlayerPrefs.GetInt("Vibration") == 1)
        {
            vibration_On.SetActive(true);
            vibration_Off.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("Vibration") == 2)
        {
            vibration_On.SetActive(false);
            vibration_Off.SetActive(true);
        }
    }

    public void Settings_Close()
    {
        settings_Open.SetActive(true);
        settings_Close.SetActive(false);
        layoutAnim.SetTrigger("Slide_Out");
    }

    public void Sound_On()
    {
        sound_On.SetActive(false);
        sound_Off.SetActive(true);
        AudioListener.volume = 0;
        PlayerPrefs.SetInt("Sound", 2);
    }

    public void Sound_Off()
    {
        sound_On.SetActive(true);
        sound_Off.SetActive(false);
        AudioListener.volume = 1;
        PlayerPrefs.SetInt("Sound", 1);
    }

    public void Vibration_On()
    {
        vibration_On.SetActive(false);
        vibration_Off.SetActive(true);
        PlayerPrefs.SetInt("Vibration", 2);
    }

    public void Vibration_Off()
    {
        vibration_On.SetActive(true);
        vibration_Off.SetActive(false);
        PlayerPrefs.SetInt("Vibration", 1);
    }

    #endregion

    

    #region WhiteEffect

    public Image whiteEffectImage;
    private int effectControl = 0;
    public IEnumerator WhiteEffect()
    {
        whiteEffectImage.gameObject.SetActive(true);
        while (effectControl == 0)
        {
            yield return new WaitForSeconds(0.01f);
            whiteEffectImage.color += new Color(0, 0, 0, 0.1f);
            if (whiteEffectImage.color == new Color(whiteEffectImage.color.r, whiteEffectImage.color.g, whiteEffectImage.color.b, 1))
            {
                effectControl = 1;
            }
        }
        while (effectControl == 1)
        {
            yield return new WaitForSeconds(0.01f);
            whiteEffectImage.color -= new Color(0, 0, 0, 0.1f);
            if (whiteEffectImage.color == new Color(whiteEffectImage.color.r, whiteEffectImage.color.g, whiteEffectImage.color.b, 0))
            {
                effectControl = 0;
            }
        }
        if(effectControl == 2)
        {
            Debug.Log("Effect done");
        }

    }
    #endregion


}
