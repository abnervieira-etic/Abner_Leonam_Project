using TMPro;
using UnityEngine;
using System.Collections;
public class UImanager : MonoBehaviour
{  
    [SerializeField] private TMP_Text modifierText;
    [SerializeField] private TMP_Text goalText;
    public TMP_Text MOtext { get => modifierText; set => modifierText = value; }
    public static UImanager instance;
    void Awake()
    {
        instance = this;
        goalText.gameObject.SetActive(false);
    }
  
    void Start()
    {
        modifierText.gameObject.SetActive(false);
        goalText.gameObject.SetActive(false);
    }
    public void CallGoal()
    {
        StartCoroutine(Goal()); 
    }

    public void CallModifierTxt(string name, float duration)
    {
        StartCoroutine(ShowModifier(name, duration));
    }

    public IEnumerator ShowModifier(string name, float duration)
    {
        modifierText.text = name;
        modifierText.gameObject.SetActive(true);
        yield return new WaitForSeconds(duration);
        modifierText.gameObject.SetActive(false);
    }

    public void HideModifier()
    {
        modifierText.gameObject.SetActive(false);
    }

    IEnumerator Goal()
    {
        goalText.gameObject.SetActive(true);
        yield return new WaitForSeconds(2f);
        goalText.gameObject.SetActive(false);
    }
}
