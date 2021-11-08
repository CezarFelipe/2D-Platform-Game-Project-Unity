using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shaker : MonoBehaviour
{

    public static Shaker instance;

    private float power;
    private float duration;
    private bool shouldShake;
    private bool canFreeze;

    public float timeFrameFreeze = 0.25f;

    private Vector3 startPosition;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (shouldShake)
        {
            if (canFreeze)
            {
                StartCoroutine(FrameFreeze());
            }
            if(duration > 0)
            {
                transform.localPosition = startPosition + (Random.insideUnitSphere * power) * Time.deltaTime;
                duration -= Time.deltaTime;
            }
            else
            {
                canFreeze = true;
                shouldShake = false;
                duration = 0;
                transform.localPosition = startPosition;
            }
        }
    }
    IEnumerator FrameFreeze()
    {
        canFreeze = false;
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(timeFrameFreeze);
        Time.timeScale = 1;
    }
    public void SetValues(float powerValue, float durationValue)
    {
        power = powerValue;
        duration = durationValue;
        shouldShake = true;
        canFreeze = true;
    }
}
