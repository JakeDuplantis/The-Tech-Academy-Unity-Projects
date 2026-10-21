using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ball_move : MonoBehaviour
{
    [SerializeField] float LoadTime = 1f;

    public TMP_Text ScoreText;
    public TMP_Text WinText;


    public float speed;
    private Rigidbody rigb;
    private int Score;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Score = 0;
        setScoreText();
        rigb = GetComponent<Rigidbody>();
        WinText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveHoriz = Input.GetAxis("Horizontal");
        float moveVert = Input.GetAxis("Vertical");

        //Vector3 is used to add a force from all (x, y, z) axis directions.
        Vector3 movement = new Vector3(moveHoriz,0.0f, moveVert); 
        rigb.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("CubePickUp"))
        {
            other.gameObject.SetActive(false); //Destroy(gameObject);
            Score++;
            setScoreText();
        }
    }

    void setScoreText()
    {
        ScoreText.text = "Score: " + Score.ToString();

        //activate winText when when all cubes collected
        if (Score >= 12)// needs to equal number of collectables
        {
            WinText.gameObject.SetActive(true);
            //start loading level when all cubes collected
            StartCoroutine(LoadNextLevel());
        }
    }

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
