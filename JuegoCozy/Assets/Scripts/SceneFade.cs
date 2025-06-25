using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class SceneFade : MonoBehaviour
{

    private Image sceneFadeImage;
    private TextMeshProUGUI textMesh;

    //[SerializeField] private AudioClip suenaAuto;

    
    private void Awake()
    {
        sceneFadeImage = GetComponent<Image>();
        textMesh = GetComponentInChildren<TextMeshProUGUI>();
    }

    public IEnumerator FadeInCoroutine(float duration)
    {
        Color startColor = new Color(sceneFadeImage.color.r, sceneFadeImage.color.g, sceneFadeImage.color.b, 1);
        Color targetColor = new Color(sceneFadeImage.color.r, sceneFadeImage.color.g, sceneFadeImage.color.b, 0);

        //Color textStartColor = new Color(textMesh.color.r, textMesh.color.g, textMesh.color.b, 1);
        //Color textTargetColor = new Color(textMesh.color.r, textMesh.color.g, textMesh.color.b, 0);


      //  yield return fadeCoroutine(startColor, targetColor, duration);
        yield return fadeCoroutine(startColor, targetColor, duration);


        gameObject.SetActive(false);
    }

    public IEnumerator FadeOutCoroutine(float duration)
    {
        Color startColor = new Color(sceneFadeImage.color.r, sceneFadeImage.color.g, sceneFadeImage.color.b, 0);
        Color targetColor = new Color(sceneFadeImage.color.r, sceneFadeImage.color.g, sceneFadeImage.color.b, 1);

       // Color textStartColor = new Color(textMesh.color.r, textMesh.color.g, textMesh.color.b, 0);
       // Color textTargetColor = new Color(textMesh.color.r, textMesh.color.g, textMesh.color.b, 1);


        gameObject.SetActive(true);

        //yield return fadeCoroutine (startColor, targetColor, duration);
        yield return fadeCoroutine(startColor, targetColor, duration);

       // float elapsedTime = 0f;
        //SFXScript.instance.suenaClip(suenaAuto, transform, 1f, 2f, loop: false);
       

        //while (elapsedTime < blackImageDuration)
        //{
            /*if (elapsedTime >= 7)
            {
                textMesh.text = "5:00 PM";
            }
            else
            {
                textMesh.text = "8:00 AM";
            }*/

          //  print(elapsedTime);

          //  elapsedTime += Time.deltaTime;
        //
            
            //yield return null;  // Esperar hasta el siguiente frame
//        }

       


    }

    private IEnumerator fadeCoroutine(Color startColor, Color targetColor, float duration)
    {
        float elapsedTime = 0;
        float elapsedPercentage = 0;
        while (elapsedPercentage < 1)
        {
            elapsedPercentage = elapsedTime / duration;
            sceneFadeImage.color = Color.Lerp(startColor, targetColor, elapsedPercentage);

        //    textMesh.color = Color.Lerp(textStartColor, textTargetColor, elapsedPercentage);



            yield return null;
            elapsedTime += Time.deltaTime;
        }

       
    }
}
