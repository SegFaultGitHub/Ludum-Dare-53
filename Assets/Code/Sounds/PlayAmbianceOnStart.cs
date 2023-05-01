using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAmbianceOnStart : MonoBehaviour
{
    [SerializeField] private AudioClip _clip;

    // Start is called before the first frame update
    void Start()
    {
        SoundManager.Instance.StopAmbiance();
        SoundManager.Instance.PlayAmbiance(_clip);
    }
}
