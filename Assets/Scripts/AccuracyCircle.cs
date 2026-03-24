using UnityEngine;
using UnityEngine.UI;

public class AccuracyCircle : MonoBehaviour
{
    [SerializeField] private float maxScale = 2f;
    [SerializeField] private float minScale = 0.5f;
    [SerializeField] private float pulseSpeed = 1f;

    private RectTransform rectTransform;
    public float CurrentAccuracy { get; private set; }

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        float scale = Mathf.Lerp(minScale, maxScale,
            (Mathf.Sin(Time.time * pulseSpeed) + 1f) / 2f);

        rectTransform.localScale = new Vector3(scale, scale, 1f);

        // 1 = perfect, 0 = worst
        CurrentAccuracy = 1f - ((scale - minScale) / (maxScale - minScale));
    }
}