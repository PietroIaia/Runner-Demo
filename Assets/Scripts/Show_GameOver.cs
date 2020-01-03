using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Show_GameOver : MonoBehaviour
{
    public GameObject GameOver_Screen;
    private CanvasGroup uiElement;
    public GameObject go;
    private Death death;

    void Start()
    {
        go = GameObject.Find("Character");
        death = go.GetComponent<Death>();

        uiElement = GameOver_Screen.GetComponent<CanvasGroup>();
    }
    void Update()
    {
        if(death.dead)
        {
            StartCoroutine(FadeCanvasGroup(uiElement, uiElement.alpha, 1));
            uiElement.interactable = true;
        }
    }
    public IEnumerator FadeCanvasGroup(CanvasGroup cg, float start, float end, float lerpTime = 0.5f)
    {
        float _timeStartedLerping = Time.unscaledTime;
        float timeSinceStarted = Time.unscaledTime - _timeStartedLerping;
        float percentageComplete = timeSinceStarted / lerpTime;

        while(true)
        {
            timeSinceStarted = Time.unscaledTime - _timeStartedLerping;
            percentageComplete = timeSinceStarted / lerpTime;

            float currentValue = Mathf.Lerp(start, end, percentageComplete);

            cg.alpha = currentValue;
            if(percentageComplete >= 1) break;
            
            yield return new WaitForSecondsRealtime(0.000001f);
        }
    }  
}
