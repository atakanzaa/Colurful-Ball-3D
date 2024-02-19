using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems; 

public class PlayerController : MonoBehaviour
{
    public CameraShake camerashake;
    public UIManager uimanager;


    public GameObject cam;
    public GameObject vectorBack;
    public GameObject vectorForward;

    private Touch touch;
    [Range(15,40)]
    public float speed;
    public float forwardSpeed;
    private bool speedballforward = false;
    private bool firstTouchControl = false;

    private Rigidbody rb;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    public void Update()
    {
        if(Variables.firstTouch == 1 && speedballforward == false)
        {
            transform.position += new Vector3(0, 0, forwardSpeed * Time.deltaTime);
            vectorBack.transform.position += new Vector3(0, 0, forwardSpeed * Time.deltaTime);
            vectorForward.transform.position += new Vector3(0, 0, forwardSpeed * Time.deltaTime);
        }






        if(Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            if(touch.phase == TouchPhase.Began)
            {

                if (!EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
                {
                    if (firstTouchControl==false)
                    {
                        Variables.firstTouch = 1;
                        uimanager.FirstTouch();
                        firstTouchControl = true;
                    }
                    
                }
               
            }
            
            else if(touch.phase == TouchPhase.Moved)
            {
                
                if (!EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
                {
                    rb.velocity = new Vector3(touch.deltaPosition.x * speed * Time.deltaTime,
                                           transform.position.y,
                                           touch.deltaPosition.y * speed * Time.deltaTime);

                    if (firstTouchControl == false)
                    {
                        Variables.firstTouch = 1;
                        uimanager.FirstTouch();
                        firstTouchControl = true;
                    }

                }
            }
            else if(touch.phase == TouchPhase.Ended)
            {
                //rb.velocity = new Vector3(0, 0, 0);
                rb.velocity = Vector3.zero;
            }
        }

    }

    public GameObject[] FractureItems;
    public void OnCollisionEnter(Collision hit)
    {
        if (hit.gameObject.CompareTag("Obstacles"))
        {
            camerashake.CameraShakesCall();
            uimanager.StartCoroutine("WhiteEffect");

            gameObject.transform.GetChild(0).gameObject.SetActive(false);
            foreach (GameObject item in FractureItems)
            {
                item.GetComponent<SphereCollider>().enabled = true;
                item.GetComponent<Rigidbody>().isKinematic = false;
            }
            StartCoroutine("TimeScaleControl");
        }
    }
    public IEnumerator TimeScaleControl()
    {
        speedballforward = true;
        yield return new WaitForSecondsRealtime(0.4f);
        Time.timeScale = 0.4f;
        yield return new WaitForSecondsRealtime(0.6f);
        uimanager.RestartButtonActive();
        rb.velocity = Vector3.zero;
    }



}
