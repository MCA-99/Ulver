using System.Collections;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    private Vector2 velocity;

    public float smoothTimeY;
    public float smoothTimeX;

    public GameObject target;   

    public bool bounds;

    public Vector3 minCameraPos;
    public Vector3 maxCameraPos;

    void Awake() {
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void FixedUpdate() {
        float posX = Mathf.SmoothDamp(transform.position.x, target.transform.position.x, ref velocity.x, smoothTimeX);
        float posY = Mathf.SmoothDamp(transform.position.y, target.transform.position.y, ref velocity.y, smoothTimeY);

        transform.position = new Vector3 (posX, posY, transform.position.z);

        if (bounds) {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, minCameraPos.x, maxCameraPos.x),
            Mathf.Clamp(transform.position.y, minCameraPos.y, maxCameraPos.y),
            Mathf.Clamp(transform.position.z, minCameraPos.z, maxCameraPos.z));
        }
    }
}