using System.Collections;
using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    [SerializeField] private HideType hideType;
    [SerializeField] private float timeLife;
    [SerializeField] private bool activeOnEnable;

    private bool isUseWaitUntil;
    private WaitUntil cacheWait;

    private void OnEnable()
    {
        if (activeOnEnable)
        {
            StartCoroutine(Destroy());
        }
        if (isUseWaitUntil)
        {
            isUseWaitUntil = false;
            StopAllCoroutines();
            StartCoroutine(Destroy(cacheWait));
        }
    }

    public void StartAutoDestroy(float timeLife)
    {
        StopAllCoroutines();
        this.timeLife = timeLife;
        StartCoroutine(Destroy());
    }

    public void StartAutoDestroy(WaitUntil wait)
    {
        cacheWait = wait;
        isUseWaitUntil = true;
        StopAllCoroutines();
        StartCoroutine(Destroy(wait));
    }

    private IEnumerator Destroy(WaitUntil wait)
    {
        yield return wait;
        if (hideType == HideType.Destroy)
        {
#if UNITY_EDITOR
            DestroyImmediate(gameObject);
#else
            Destroy(gameObject);
#endif
        }
        else if (hideType == HideType.Disable)
        {
            gameObject.SetActive(false);
        }
        else if (hideType == HideType.Pool)
        {
            PoolManager.Recycle(gameObject);
        }
    }

    private IEnumerator Destroy()
    {
        yield return new WaitForSeconds(timeLife);

        if (hideType == HideType.Destroy)
        {
#if UNITY_EDITOR
            DestroyImmediate(gameObject);
#else
            Destroy(gameObject);
#endif
        }
        else if (hideType == HideType.Disable)
        {
            gameObject.SetActive(false);
        }
        else if (hideType == HideType.Pool)
        {
            PoolManager.Recycle(gameObject);
        }
    }

    public enum HideType
    {
        Destroy, Disable, Pool
    }
}
