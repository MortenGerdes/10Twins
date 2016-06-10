using UnityEngine;
using System.Collections;

public class ReplaySystem : MonoBehaviour
{

    private const int bufferSize = 500;
    private MykeyFrame[] keyframes = new MykeyFrame[bufferSize];
    private Rigidbody rigid;
    private GameManager gameManager;

    // Use this for initialization
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.isRecording)
        {
            record();
        }
        else
        {
            playBack();
        }
    }

    private void playBack()
    {
        if (keyframes[bufferSize-1].frameTime == 0)
        {
            return;
        }
        int frame = Time.frameCount % bufferSize;

        rigid.isKinematic = true;
        transform.position = keyframes[frame].position;
        transform.rotation = keyframes[frame].rotation;
    }

    private void record()
    {
        int frame = Time.frameCount % bufferSize;
        float time = Time.time;

        rigid.isKinematic = false;
        keyframes[frame] = new MykeyFrame(time, transform.position, transform.rotation);
    }
}

/// <summary>
/// A Structure for storing keyframes that can be used to play back
/// </summary>
public struct MykeyFrame
{
    public float frameTime;
    public Vector3 position;
    public Quaternion rotation;

    public MykeyFrame(float time, Vector3 pos, Quaternion rot)
    {
        this.frameTime = time;
        this.position = pos;
        this.rotation = rot;
    }
}
