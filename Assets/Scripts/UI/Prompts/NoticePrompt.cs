using UnityEngine;
using UnityEngine.UI;

/*
 * Gives the user a notice.
*/

public class NoticePrompt : MonoBehaviour
{
    [Header("Component References")]
    public Text text;
    public Button okButton;

    void Start()
    {
        okButton.onClick.AddListener(delegate { Destroy(gameObject); });
    }
}
