using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //called when start button is pressed in main menu
    public void LoadFirstLevel()
    {
        //loads scene at index
        SceneManager.LoadScene(1);
    }

}
