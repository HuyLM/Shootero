using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarBase : MonoBehaviour {
    [SerializeField] protected Image imgCurrentValueLerp;
    [SerializeField] protected Image imgCurrentValueReal;
    [SerializeField] protected float updateSpeedSecond;

    protected float maxWidth;
    protected float thisSpeed;
    protected bool isComplete;
    protected virtual void Start() {
        maxWidth = imgCurrentValueLerp.rectTransform.rect.width;
    }

    protected void FillBar(Image img, float fillAmount) {
        //Rect rect = imgCurrentHp.rectTransform.rect;
        //rect.width = fillAmount * maxWidth;
        img.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, fillAmount * maxWidth);
        //imgCurrentHp.rectTransform.sizeDelta = new Vector2(fillAmount * maxWidth, imgCurrentHp.rectTransform.sizeDelta.y);

    }

    protected virtual void HandleBarChanged(float pct) {
        if(!gameObject.activeInHierarchy) {
            return;
        }
        StopAllCoroutines();
        StartCoroutine(ChangingBar(pct));
        FillBar(imgCurrentValueReal, pct);
    }

    protected IEnumerator ChangingBar(float pct) {
        isComplete = false;
        yield return GameSystem.Common.Utilities.YieldHelper.WaitForEndOfFrame();
        WaitForSeconds deltaTime = new WaitForSeconds(Time.fixedDeltaTime);
        float preChange = imgCurrentValueLerp.rectTransform.rect.width / maxWidth;
        thisSpeed = Mathf.Abs(pct - preChange) * updateSpeedSecond;
        float elapsed = 0f;
        while(elapsed < updateSpeedSecond) {
            elapsed += Time.fixedDeltaTime;
            float fillAmount = Mathf.Lerp(preChange, pct, elapsed / thisSpeed);
            FillBar(imgCurrentValueLerp, fillAmount);
            yield return deltaTime;
        }
        FillBar(imgCurrentValueLerp, pct);
        isComplete = true;

    }

    public void ForceFillBar(float pct) {
        FillBar(imgCurrentValueLerp, pct);
        FillBar(imgCurrentValueReal, pct);

    }
}
