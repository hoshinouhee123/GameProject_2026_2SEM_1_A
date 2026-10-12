using System.Collections;
using TMPro;
using UnityEngine;

public class InteractionUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI guideText;
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private float dialogueDuraction = 3f;

    private Coroutine dialogueRoutine;

    private void Start()
    {
        HideGuide();
        dialoguePanel.SetActive(false);
    }

    public void ShowGuide(string message)
    {
        guideText.gameObject.SetActive(true);
        guideText.text = message;
    }

    public void HideGuide()
    {
        guideText.gameObject.SetActive(false);
    }

    private IEnumerator DIalogueRoutine(string npcName, string message)
    {
        dialoguePanel.SetActive(true);
        dialogueText.text = npcName + "\n" + message;

        yield return new WaitForSeconds(dialogueDuraction);

        dialoguePanel.SetActive(false);
        dialogueRoutine = null;
    }

    public void ShowDialogue(string npcName, string message)
    {
        if (dialogueRoutine != null)
        {
            StopCoroutine(dialogueRoutine);
        }
        dialogueRoutine = StartCoroutine(DIalogueRoutine(npcName, message));
    }
}
