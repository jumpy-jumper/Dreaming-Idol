using UnityEngine;

public class FramerateLimiter : MonoBehaviour
{
    public int target;

    void Awake()
    {
        Application.targetFrameRate = target;
    }
}
