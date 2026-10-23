using System.Collections;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    //adds field to set load time of next level 
    [SerializeField] float LoadTime = 1f;

    public TMP_Text WinText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        WinText.gameObject.SetActive(false);
    }

    //trigger wintext when Player touches victory platform
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            WinText.gameObject.SetActive(true);
            StartCoroutine(LoadNextLevel());
        }  
    }

    //load next scene and reset to main menu after last scene
    IEnumerator LoadNextLevel()
    {
        yield return new WaitForSeconds(LoadTime);

        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex == 1) //set equal to last scene to reset
        {
            //goes back to first scene
            SceneManager.LoadScene(0);
        }
        else
        {
            //goes to the next scene in order
            SceneManager.LoadScene(currentSceneIndex + 1);
        }
    }
}
