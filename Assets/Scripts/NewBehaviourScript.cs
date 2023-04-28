using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float windPower = 10;
    public float throwAway = 3;

    Vector3 heading, direction;
    float distance, remapDistance;


    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Spinable")
        {
            Pull(other);
        }
    }

    private void Pull(Collider col)
    {
        heading = transform.position - col.transform.position;
        distance = heading.magnitude;
        direction = heading / distance;
        remapDistance = distance.Remap(0, 10, 1, 0);

        if (remapDistance > 0.8f)
        {
            direction = -direction;
            remapDistance = throwAway;
        }

        col.attachedRigidbody.AddForce(direction * windPower * 10 * remapDistance);
    }

}

public static class ExtensionMethods
{
    public static float Remap(this float value, float from1, float to1, float from2, float to2)
    {
        return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
    }
}








