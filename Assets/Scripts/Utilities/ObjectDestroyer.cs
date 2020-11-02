using UnityEngine;

/*
 * Provides method to destroy given GameObject.
 */

public class ObjectDestroyer : MonoBehaviour
{
    public void Destroy(GameObject obj)
    {
        GameObject.Destroy(obj);
    }
}
