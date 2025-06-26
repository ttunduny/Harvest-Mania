using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset = new Vector3(0, 3, -5);
    [SerializeField] private float followSpeed = 5f;
    [SerializeField] private float rotationSpeed = 3f;

    void LateUpdate()
    {
        if (target == null) return;

        // Follow position smoothly
        Vector3 targetPosition = target.position +
                                (target.right * offset.x) +
                                (target.up * offset.y) +
                                (target.forward * offset.z);

        transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);

        // Rotate to look at the tractor smoothly
        Quaternion targetRotation = Quaternion.LookRotation(target.position - transform.position, target.up);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}