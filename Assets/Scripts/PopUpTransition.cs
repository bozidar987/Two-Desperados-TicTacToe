using System.Collections;
using UnityEngine;

public class PopUpTransition : MonoBehaviour
{ 
    [SerializeField] float targetScaleMultiplier = 1.2f;
    [SerializeField] float scaleDuration = 0.2f;
    [SerializeField] float returnDelay = 0.05f;
    [SerializeField] float returnDuration = 0.1f;

    Vector2 originalScale = new Vector2(1.0f, 1.0f);
    Vector2 targetScale = new Vector2(1.0f, 1.0f);

    private void OnEnable()
    {
        originalScale = transform.localScale;
        targetScale = originalScale * targetScaleMultiplier;
        transform.localScale = Vector2.zero;
        StartCoroutine(popupOpenAnimation());
    }

    public void closePopup()
    {
        originalScale = transform.localScale;
        targetScale = originalScale * targetScaleMultiplier;
        StartCoroutine(popupCloseAnimation());
    }

    IEnumerator popupOpenAnimation()
    {
        float timer = 0f;
        while (timer < scaleDuration)
        {
            transform.localScale = Vector3.Lerp(Vector2.zero,targetScale, timer / scaleDuration);
            timer += Time.deltaTime;
            yield return null;
        }
        transform.localScale = targetScale;

        yield return new WaitForSeconds(returnDelay);

        timer = 0f;
        while (timer < returnDuration)
        {
            transform.localScale = Vector3.Lerp(targetScale, originalScale, timer / returnDuration);
            timer += Time.deltaTime;
            yield return null;
        }
        transform.localScale = originalScale;
    }

    IEnumerator popupCloseAnimation()
    {
        float timer = 0f;
        while (timer < returnDuration)
        {
            transform.localScale = Vector3.Lerp(originalScale, targetScale, timer / returnDuration);
            timer += Time.deltaTime;
            yield return null;
        }
        transform.localScale = targetScale; 
        
        yield return new WaitForSeconds(returnDelay);

        timer = 0f;
        while (timer < scaleDuration)
        {
            transform.localScale = Vector3.Lerp(targetScale, Vector2.zero, timer / scaleDuration);
            timer += Time.deltaTime;
            yield return null;
        } 

        transform.localScale = originalScale;
        gameObject.SetActive(false);
    }
}
