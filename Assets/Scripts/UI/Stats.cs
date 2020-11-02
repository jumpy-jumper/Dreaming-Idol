using UnityEngine;
using UnityEngine.UI;

public class Stats : MonoBehaviour
{
    public int updateWait;
    public Text framerate;

    int actTime;

    private void Start()
    {
        actTime = 0;
    }

    private void Update()
    {
        if (actTime % updateWait == 0)
        {
            framerate.text = "FPS: " + (int)(1f / Time.deltaTime);
        }

        actTime++;
    }
}
