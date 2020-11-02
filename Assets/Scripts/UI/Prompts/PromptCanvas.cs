using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.Events;

/*
 * Blocks specified canvases when a child is active.
 * Also provides public methods to spawn prompts.
 */

public class PromptCanvas : MonoBehaviour
{
    [Header("Inspector Variables")]
    public float blockedAlpha = 0.5f;
    public List<CanvasGroup> canvasesToBlock = new List<CanvasGroup>();

    [Header("Prefab References")]
    public ConfirmationPrompt confirmationPromptTemplate;
    public NoticePrompt noticePromptTemplate;
    public InputPrompt inputPromptTemplate;

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

    public void ShowConfirmationPrompt(string text, UnityAction onYes = null, UnityAction onNo = null)
    {
        ConfirmationPrompt confirmationPrompt = Instantiate(confirmationPromptTemplate, transform);
        confirmationPrompt.text.text = text;

        if (onYes != null)
        {
            confirmationPrompt.yesButton.onClick.AddListener(onYes);
        }

        if (onNo != null)
        {
            confirmationPrompt.yesButton.onClick.AddListener(onNo);
        }
    }

    public void ShowNoticePrompt(string text, UnityAction onOk = null)
    {
        NoticePrompt noticePrompt = Instantiate(noticePromptTemplate, transform);
        noticePrompt.text.text = text;

        if (onOk != null)
        {
            noticePrompt.okButton.onClick.AddListener(onOk);
        }
    }

    public void ShowInputPrompt(string text, UnityAction onOk = null, UnityAction onCancel = null)
    {
        InputPrompt inputPrompt = Instantiate(inputPromptTemplate, transform);
        inputPrompt.inputField.placeholder.GetComponent<Text>().text = text;

        if (onOk != null)
        {
            inputPrompt.okButton.onClick.AddListener(onOk);
        }

        if (onCancel != null)
        {
            inputPrompt.okButton.onClick.AddListener(onCancel);
        }
    }
}
