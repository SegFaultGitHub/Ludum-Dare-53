using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destination : MonoBehaviour
{

    public ScoreManagement score;
    private float destroyDelay = 3f;

    // Start is called before the first frame update
    void Start()
    {
        score = GameObject.FindGameObjectWithTag("ScoreManagement").GetComponent<ScoreManagement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Box"))
        {
            Debug.Log("Box delivered !");
            score.AddScore();
            Destroy(collision.gameObject, destroyDelay);
        }
    }
}
