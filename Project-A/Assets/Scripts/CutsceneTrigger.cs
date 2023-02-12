using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CutsceneTrigger : MonoBehaviour
{
    [Header("Cutscene Components")]
    [SerializeField] private BoxCollider2D test;
    //[SerializeField] private PlayableDirector director;
    //[SerializeField] private GameObject controlPanel;

    //[Header("Cutscene Options")]
    //[SerializeField] private bool isTrigger = false;

    //private void Awake()
    //{
    //    director.GetComponent<PlayableDirector>();
    //    director.played += Director_Played;
    //    director.stopped += Director_Stopped;
    //}

    //private void Director_Played(PlayableDirector obj)
    //{
    //    controlPanel.SetActive(false);
    //}

    //private void Director_Stopped(PlayableDirector obj)
    //{
    //    controlPanel.SetActive(true);
    //}

    //public void StartTimeline()
    //{
    //    director.Play();
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player entered, start cutscene");
        }
    }
}
