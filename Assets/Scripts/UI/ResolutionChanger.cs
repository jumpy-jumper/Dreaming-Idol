using UnityEngine;

public class ResolutionChanger : MonoBehaviour
{
    public void ChangeResolution(int y)
    {
        int x = y / 9 * 16;
        Screen.SetResolution(x, y, FullScreenMode.Windowed);
    }
}
