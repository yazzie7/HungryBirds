using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Worm : MonoBehaviour
{
    public float hp = 3.5f;
    public static int WormsCount = 0;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.magnitude > hp)
        {
            Kill();
        }


        //Debug.Log(collision.relativeVelocity.magnitude); We can get the velocity it got hit by
    }

    void Start()
    {
        WormsCount++;

    }
   

    public void RestartGame()
    {
        // Reload the current scene when all worms have been consumed.
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    void Kill()
    {
        Destroy(gameObject);
       WormsCount--;
        if( WormsCount <= 0 )
        {
           RestartGame();
        }
    }
    /*public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    // Start is called before the first frame update
 */

    // Update is called once per frame
    void Update()
    {
        
    }
}
