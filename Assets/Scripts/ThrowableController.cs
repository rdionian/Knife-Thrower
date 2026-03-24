using UnityEngine;

public class ThrowableController : MonoBehaviour
{
    [SerializeField] private float minSwipeDistance = 50f;
    [SerializeField] private float throwForceMultiplier = 0.05f;
    [SerializeField] private float upwardForce = 3f;
    [SerializeField] private float spinSpeed = 400f;
    [SerializeField] private GameObject knifePrefab;
    [SerializeField] private Transform spawnPoint;

    private Vector2 swipeStart;
    private bool isSwiping;

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                swipeStart = touch.position;
                isSwiping = true;
            }

            if (touch.phase == TouchPhase.Ended && isSwiping)
            {
                Vector3 swipeDelta = touch.position - swipeStart;

                if (swipeDelta.magnitude >= minSwipeDistance)
                {
                    ThrowKnife(swipeDelta);
                }

                isSwiping = false;
            }
        }
    }

    private void ThrowKnife(Vector2 swipeDelta)
    {
        GameObject knife = Instantiate(knifePrefab, spawnPoint.position, Quaternion.identity);
        Rigidbody rb = knife.GetComponent<Rigidbody>();

        float throwForce = swipeDelta.magnitude * throwForceMultiplier;

        Vector3 throwDirection = new Vector3(swipeDelta.x * 0.3f, 1.5f, swipeDelta.y).normalized;

        rb.linearVelocity = throwDirection * throwForce;
        rb.angularVelocity = new Vector3(spinSpeed, 0, 0);

        // Add fixed upward impulse so knives arc nicely
        rb.AddForce(Vector3.up * upwardForce, ForceMode.Impulse);
    }
}
