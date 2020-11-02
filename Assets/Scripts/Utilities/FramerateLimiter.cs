using UnityEngine;

/*
 * Attach to GameObject to limit framerate on Awake.
 */

public class FramerateLimiter : MonoBehaviour
{
    public int target;

    void Awake()
    {
        Application.targetFrameRate = target;
    }
}
