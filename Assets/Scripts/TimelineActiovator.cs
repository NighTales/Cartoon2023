using UnityEngine;
using UnityEngine.Playables;

public class TimelineActiovator : MonoBehaviour
{
    [SerializeField]
    private PlayableDirector timeline;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            timeline.Play();
        }
    }
}
