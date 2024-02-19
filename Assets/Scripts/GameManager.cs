using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public UIManager uimanager;
  
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && gameObject.CompareTag("FinishLine"))
        {
            Debug.Log("Oyun Bitti.");
               
        }
    }
   
   

}
