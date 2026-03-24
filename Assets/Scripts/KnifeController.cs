using UnityEngine;

public class KnifeController : MonoBehaviour
{
    [SerializeField] private Transform tip;

    private Rigidbody rb;
    private bool hasHit = false;
    public bool HasHit => hasHit;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (hasHit) return;

        if (collision.gameObject.CompareTag("Ground"))
        {
            hasHit = true;
            Destroy(gameObject, 2f);
        }
    }

    public void StickToTarget(Transform target)
    {
        if (hasHit) return;

        hasHit = true;

        transform.rotation = target.rotation;

        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rb.isKinematic = true;

        transform.SetParent(target);
    }

    public void BounceOff()
    {
        if (hasHit) return;

        hasHit = true;
        rb.linearVelocity = new Vector3(
            Random.Range(-2f, 2f),
            Random.Range(1f, 3f),
            -Random.Range(2f, 4f)
        );
        rb.angularVelocity = new Vector3(
            Random.Range(-10f, 10f),
            Random.Range(-5f, 5f),
            0
        );

        Destroy(gameObject, 2f);
    }
}