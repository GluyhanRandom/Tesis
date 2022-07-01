using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    public Animator animator;
    public KarmaData karmaData;

    void PortalIdle()
    {
        animator.SetTrigger("Portal_Idle");
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 9) {

            animator.SetTrigger("Portal_Close");

            if (gameObject.layer == 27)
            {
                if (collision.gameObject.layer == 9)
                {
                    collision.gameObject.transform.position = new Vector3(-95, 137, -1);
                }
            } else if (SceneManager.GetActiveScene().buildIndex == 0) {
                SceneManager.LoadScene(1);
            } else if (SceneManager.GetActiveScene().buildIndex == 1)
            {
                SceneManager.LoadScene(2);
            } else if (SceneManager.GetActiveScene().buildIndex == 2)
            {
                SceneManager.LoadScene(Random.Range(4,5));
            } else if (SceneManager.GetActiveScene().buildIndex == 4 || SceneManager.GetActiveScene().buildIndex == 5)
            {
                Application.Quit();
            }

        } 
    }
}
