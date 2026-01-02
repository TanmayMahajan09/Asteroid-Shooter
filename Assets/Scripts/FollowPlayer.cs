using UnityEngine;

public class FollowPlayer : MonoBehaviour {
    [SerializeField] private Vector3 ownPosition = new Vector3(0,0,0);
    [SerializeField] private GameObject playerObject;

    private void Update() {
        transform.position = playerObject.transform.position  +  ownPosition;
    }
}

