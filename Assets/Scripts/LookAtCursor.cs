using UnityEngine;

public class LookAtCursor : MonoBehaviour { 
    public void LookAt(Vector3 targetVector) {
        float lookAngle = AngleBetweenPoints(transform.position, targetVector) + 90;
        transform.eulerAngles = new Vector3(0, 0, lookAngle);
    }

    private float AngleBetweenPoints(Vector3 a, Vector3 b) {
        return Mathf.Atan2(a.y - b.y ,a.x - b.x) * Mathf.Rad2Deg;
    }

}
