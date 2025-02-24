using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HungryBird : MonoBehaviour
{
    public GameObject newBird;
    public Rigidbody2D rb;
    private bool isPressed = false;
    public float delay = 0.13f;
    public float maxDistanceDragged = 2.1f;
    private Worm wormClass;
    public Rigidbody2D Hook;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()

    {
        if (isPressed)
        {
            Vector2 positionMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (Vector3.Distance(positionMouse,Hook.position ) > maxDistanceDragged)
            {
                rb.position = Hook.position + (positionMouse - Hook.position).normalized * maxDistanceDragged;
            }
            else
            {
                rb.position = positionMouse;
            }

        }

    }
    void OnMouseDown()
    {
        Debug.Log("Mouse click");
        isPressed = true;
        rb.isKinematic = true;

    }

    void OnMouseUp()
    {
        isPressed=false;
        rb.isKinematic = false;
        StartCoroutine(Release());
    }

    IEnumerator Release()
    {
        yield return new WaitForSeconds(delay);

        GetComponent<SpringJoint2D>().enabled = false;

        this.enabled = false;

        yield return new WaitForSeconds(delay + 1.5f);
        if (newBird != null)
        {
            newBird.SetActive(true);
        }
        else
        {
            //wormClass.RestartGame();
            Worm.WormsCount = 0; //we use this to make sure to reset , if we fail in one level its gonna reset the amount of enemies and not add more on to that..
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
 }
