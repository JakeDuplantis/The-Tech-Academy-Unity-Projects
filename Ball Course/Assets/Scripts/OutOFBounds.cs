using UnityEngine;
using UnityEngine.SceneManagement;

public class OutOFBounds : MonoBehaviour
{
    //adds a field to enter name of scene to load on out of bounds
    [SerializeField] private string loadScene;

    //loads the scene that is named, spelling must be exact
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(loadScene);
        }

    }
}
