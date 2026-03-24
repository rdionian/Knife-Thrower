using UnityEngine;

public class TargetController : MonoBehaviour
{
    [SerializeField] private float accuracyThreshold = 0.5f;
    [SerializeField] private AccuracyCircle accuracyCircle;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Knife"))
        {
            KnifeController knife = other.GetComponent<KnifeController>();

            if (knife.HasHit) return;

            float accuracy = accuracyCircle.CurrentAccuracy;

            if (accuracy >= accuracyThreshold)
            {
                Debug.Log("Good hit! Accuracy: " + accuracy);
                knife.StickToTarget(transform);
                ScoreManager.Instance.AddScore(accuracy);
            }
            else
            {
                Debug.Log("Bad hit! Accuracy: " + accuracy);
                knife.BounceOff();
            }
        }
    }
}