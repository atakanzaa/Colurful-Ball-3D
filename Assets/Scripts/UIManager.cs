using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; //sahnelerle ilgili bir islem yapacagimiz zaman bu kutuphane.
using TMPro;
public class UIManager : MonoBehaviour
{
    public Image whiteeffectimage;
    private int effectcontrol = 0;

    public Animator layoutAnimator;

    
    

    //Butonlar
    public GameObject settings_Open;
    public GameObject settings_Close;
    public GameObject Layout_background;
    public GameObject sound_On;
    public GameObject sound_Off;
    public GameObject vibration_On;
    public GameObject vibration_Off;
    public GameObject iap;
    public GameObject information;

    public GameObject intro_Hand;
    public GameObject noAds;
    public GameObject shop_Button;

    public GameObject RestartScreen;
    //oyun sonu ekrani

    public GameObject continueButton;

    
    public void Start()
    {
        if (PlayerPrefs.HasKey("Sound") == false) // haskey kontrol eder yoksa sound adinda degisken olusturur.
        {
            PlayerPrefs.SetInt("Sound", 1);
        }
        if (PlayerPrefs.HasKey("Vibration") == false)
        {
            PlayerPrefs.SetInt("Vibration", 1);
        }
    }
    


    public void FirstTouch()
    {
        intro_Hand.SetActive(false);
        noAds.SetActive(false);
        shop_Button.SetActive(false);
        settings_Open.SetActive(false);
        Layout_background.SetActive(false);
        settings_Close.SetActive(false);
        sound_On.SetActive(false);
        sound_Off.SetActive(false);
        vibration_On.SetActive(false);
        vibration_Off.SetActive(false);
        iap.SetActive(false);
        information.SetActive(false);
    }
    public void RestartButtonActive()
    {
        RestartScreen.SetActive(true);
    }

    public void RestartScene()
    {
        Variables.firstTouch = 0;
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
   
    
    

    public void Settings_Open()
    {
        settings_Open.SetActive(false);
        settings_Close.SetActive(true);
        layoutAnimator.SetTrigger("slide_in");

        if (PlayerPrefs.GetInt("Sound")==1)
        {
            settings_Open.SetActive(true);
            settings_Close.SetActive(false);
            AudioListener.volume = 1;
        }
        else if (PlayerPrefs.GetInt("Sound")==2)
        {
            sound_On.SetActive(false);
            sound_Off.SetActive(true);
            AudioListener.volume = 0;
        }


         if (PlayerPrefs.GetInt("Vibration")== 1)
        {
            vibration_On.SetActive(true);
            vibration_Off.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("Vibration")== 2)
        {
            vibration_On.SetActive(false);
            vibration_Off.SetActive(true);
        }
    } 
    public void Settings_Close()
    {
        settings_Open.SetActive(true);
        settings_Close.SetActive(false);
        layoutAnimator.SetTrigger("slide_out");
        continueButton.SetActive(true);
    }

    public void Sound_On()
    {
        sound_On.SetActive(false);
        sound_Off.SetActive(true);
        AudioListener.volume = 0; //sesleri kapatir.
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














    public IEnumerator WhiteEffect()
    {
        whiteeffectimage.gameObject.SetActive(true);
        while (effectcontrol == 0)
        {
            yield return new WaitForSeconds(0.1f);
            whiteeffectimage.color += new Color(0, 0, 0, 0.1f);
            if (whiteeffectimage.color == new Color(whiteeffectimage.color.r, whiteeffectimage.color.g, whiteeffectimage.color.b, 1)) ;
            {
                effectcontrol = 1;
            }
        }
        while (effectcontrol ==1)
        {
            yield return  new WaitForSeconds(0.1f);
            whiteeffectimage.color -= new Color(0, 0, 0, 0.1f);
            if (whiteeffectimage.color == new Color(whiteeffectimage.color.r, whiteeffectimage.color.g, whiteeffectimage.color.b, 0))
            {
                effectcontrol = 2;
            }
        }
        if (effectcontrol ==2)
        {
            Debug.Log("efekt bitti.");
        }





        
    }
}
