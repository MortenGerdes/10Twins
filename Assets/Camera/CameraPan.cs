using UnityEngine;
using System.Collections;

public class CameraPan : MonoBehaviour
{
    Camera cam;
    GameObject player;
    // Use this for initialization
    void Start()
    {
        cam = GetComponent<Camera>();
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
       // print("RHoriz: " + Input.GetAxis("RHori"));
       // print("RVert: " + Input.GetAxis("RVert"));
    }

    void LateUpdate()
    {
        cam.transform.LookAt(player.transform);
    }
}
