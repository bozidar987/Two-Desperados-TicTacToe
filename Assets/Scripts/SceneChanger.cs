using System.Collections;
using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.UI;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] Image fadeImage;
    [SerializeField] float fadeTime = 1.0f;
    void Start()
    {
        if (fadeImage.color.a > 0)
        {
            StartCoroutine(fadeOut());
        }
    }

    public void changeScene(string sceneName)
    {
        StartCoroutine(loadSceneAfterFadeIn(sceneName));
    }

    IEnumerator loadSceneAfterFadeIn(string sceneName)
    {
        fadeImage.gameObject.SetActive(true);
        float timer = 0f;
        float alpha = 0f;
        while (timer < fadeTime)
        {
            timer += Time.deltaTime;
            alpha = Mathf.Clamp01(timer / fadeTime);
            fadeImage.color = new Color(0, 0, 0, alpha);
            yield return null;
        }
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
        yield return null;
    }

    IEnumerator fadeOut()
    {
        float timer = 0f;
        float alpha = 0f;
        while (timer < fadeTime)
        {
            timer += Time.deltaTime;
            alpha = Mathf.Clamp01(1 - (timer / fadeTime));
            fadeImage.color = new Color(0, 0, 0, alpha);
            yield return null;
        }
        fadeImage.gameObject.SetActive(false);
        yield return null;
    }
}
