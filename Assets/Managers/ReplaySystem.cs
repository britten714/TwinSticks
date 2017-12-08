using UnityEngine;

public class ReplaySystem : MonoBehaviour
{
    private const int bufferFrames = 100;
    private MyKeyFrame[] keyFrames = new MyKeyFrame[bufferFrames];  //bufferFrames가 value 였으면 이렇게 못한다. 컴파일 할 때 bufferFrames가 무슨 값을 갖는지 모르니까. 근데 const니까 가능하다. 
    private Rigidbody rigidbody;
    private GameManager manager;

	void Start ()
	{
	    rigidbody = GetComponent<Rigidbody>();
	    manager = GameObject.FindObjectOfType<GameManager>();
	}
		
	void Update ()
	{
	    if (manager.recording)
	    {
	        Record();
	    }
	    else
	    {
	        PlayBack();
	    }
	}

    public void PlayBack()
    {
        rigidbody.isKinematic = true;
        int frame = Time.frameCount % bufferFrames;
        print("Reading frame: " + frame);
        transform.position = keyFrames[frame].position;
        transform.rotation = keyFrames[frame].rotation;
    }

    private void Record()
    {
        rigidbody.isKinematic = false;
        int frame = Time.frameCount % bufferFrames;
        float time = Time.time;
        //print("Writing frame: " + frame);
        keyFrames[frame] = new MyKeyFrame(time, transform.position, transform.rotation);
    }
}

/// <summary>   //슬래시 3번하면 이렇게 써머리 만들 수 있다. 코딩할 때 나오는 것처럼. 
/// A structure for storing time, position and rotation
/// </summary>
public struct MyKeyFrame
{
    public float frameTime;
    public Vector3 position;
    public Quaternion rotation;

    public MyKeyFrame(float time, Vector3 pos, Quaternion rot)
    {
        frameTime = time;
        position = pos;
        rotation = rot;
    }
}
