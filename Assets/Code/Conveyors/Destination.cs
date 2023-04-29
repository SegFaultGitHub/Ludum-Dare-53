using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destination : MonoBehaviour
{

    public ScoreManagement score;
    private float destroyDelay = 3f;

    public GameObject door;
    public GameObject convoyers;

    // Start is called before the first frame update
    void Start()
    {
        score = GameObject.FindGameObjectWithTag("ScoreManagement").GetComponent<ScoreManagement>();
        StartCoroutine(OpenAnimation());
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

    private IEnumerator OpenAnimation()
    {
        LeanTween.moveLocalY(door, door.transform.localPosition.y + 1.3f, 1f).setEaseOutBack();

        yield return new WaitForSeconds(1f);

        LeanTween.moveLocalZ(convoyers, convoyers.transform.localPosition.z - 2f, 1f).setEaseOutBack();
    }
}
