using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndZone : MonoBehaviour
{
    //For Animation
    [SerializeField]
    private Animator anim;

    public float Countdown;
    public string SceneToLoad;

    private float activationTimer;
    private bool activated = false;

    private BoxCollider2D endCollider;

    // Use this for initialization
    void Start()
    {
        endCollider = gameObject.GetComponent<BoxCollider2D>();
        activationTimer = Countdown;

        if (SceneToLoad == null || SceneToLoad == "")
        {
            SceneToLoad = SceneManager.GetActiveScene().name.ToString();
        }
        else if (SceneManager.GetActiveScene().name == "Level1")
        {
            // Change to say level 2 --------------------------------
            SceneToLoad = "Level2";
        }
        else if (SceneManager.GetActiveScene().name == "Level2")
        {
            // Change to say level 2 --------------------------------
            SceneToLoad = "Level3";
        }
        else if (SceneManager.GetActiveScene().name == "Level3")
        {
            // Change to say level 2 --------------------------------
            SceneToLoad = "Level 4";
        }
        else if (SceneManager.GetActiveScene().name == "Level 4")
        {
            // Change to say level 2 --------------------------------
            SceneToLoad = "Victory";
        }
        else if (SceneManager.GetActiveScene().name == "Level1")
        {
            // Change to say level 2 --------------------------------
            SceneToLoad = "Level2";
        }
    }

    //get activated by collision
    public void Activate()
    {
        Debug.Log("Activate");
        if (anim != null)
        {
            anim.SetBool("victory", true);
        }
        activated = true;
    }
    
    public void Level1()
    {
        SceneManager.LoadScene("Level1");
    }

    public void Level2()
    {
        SceneManager.LoadScene("Level2");
    }

    public void Level3()
    {
        SceneManager.LoadScene("Level3");
    }

    public void Level4()
    {
        SceneManager.LoadScene("Level 4");
    }

    public void InstantSwitch()
    {
        SceneManager.LoadScene(SceneToLoad);
    }

    void Update()
    {
        //decrement the timer if activated.
        if (activated)
        {
            activationTimer -= Time.deltaTime;

            //do stuff during the countdown time
            //...
        }

        //if timer runs out 
        if (activationTimer <= 0)
        {
            // if (SceneToLoad == null || SceneToLoad == "")
            // 	SceneToLoad = SceneManager.GetActiveScene().name.ToString();

            SceneManager.LoadScene(SceneToLoad);
        }
    }
}