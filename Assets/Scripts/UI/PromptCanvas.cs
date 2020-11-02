using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class PromptCanvas : MonoBehaviour
{
    public float blockedAlpha = 0.5f;
    public List<CanvasGroup> canvasesToBlock = new List<CanvasGroup>();

    void Update()
    {
        foreach (Transform child in transform)
        {
            if (child.gameObject.activeSelf)
            {
                foreach (CanvasGroup canvasGroup in canvasesToBlock)
                {
                    canvasGroup.blocksRaycasts = false;
                    canvasGroup.alpha = blockedAlpha;
                }

                return;
            }
        }

        foreach (CanvasGroup canvasGroup in canvasesToBlock)
        {
            canvasGroup.blocksRaycasts = true;
            canvasGroup.alpha = 1f;
        }
    }
}
