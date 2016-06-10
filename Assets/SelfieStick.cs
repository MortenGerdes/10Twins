using UnityEngine;
using System.Collections;

public class SelfieStick : MonoBehaviour
{

    public float panSpeed = 3f;

    private GameObject player;
    private Vector3 armRotation;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        armRotation = transform.rotation.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        armRotation.y -= Input.GetAxis("RHori") * panSpeed;
        armRotation.x += Input.GetAxis("RVert") * panSpeed;

        transform.position = player.transform.position;
        transform.rotation = Quaternion.Euler(armRotation);
    }
}
