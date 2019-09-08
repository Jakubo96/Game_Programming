using UnityEngine;

public class ShakeCamera : MonoBehaviour
{
    public float power = 0.2f;
    public float duration = 0.2f;
    public float slowDownAmount = 1f;
    private bool shouldShake;
    private float initialDuration;

    private Vector3 startPosition;

    public bool ShouldShake
    {
        get { return shouldShake; }
        set { shouldShake = value; }
    }

    private void Start()
    {
        startPosition = transform.localPosition;
        initialDuration = duration;
    }

    private void Update()
    {
        Shake();
    }

    void Shake()
    {
        if (shouldShake)
        {
            if (duration > 0)
            {
                transform.localPosition = startPosition + Random.insideUnitSphere * power;
                duration -= Time.deltaTime * slowDownAmount;
            }
            else
            {
                shouldShake = false;
                duration = initialDuration;
                transform.localPosition = startPosition;
            }
        }
    }
}