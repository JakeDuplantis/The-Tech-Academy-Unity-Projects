using UnityEngine;

public class Obstacle_Rotate : MonoBehaviour
{
    public Transform target;
    public int speed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //if no target the object with this script will rotate
        if (target == null)
        {
            target = this.gameObject.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //rotates obstacles at changable speed
        transform.RotateAround(target.transform.position, target.transform.up, speed *  Time.deltaTime);
    }
}
