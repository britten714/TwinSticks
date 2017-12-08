using UnityEngine;

public class SelfieStick : MonoBehaviour
{
    public float panSpeed = 10f;

    private GameObject player;
    private Vector3 armRotation;
	
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
	    armRotation = transform.rotation.eulerAngles;       //Transform의 Rotation값을 가져오려면 그냥 transform.rotation만 하면 안 되고 뒤에 eulerAngles 붙여야 한다. 그냥 transform.rotation만 하면 Quaternion 가져온다. 
	}
		
	void Update ()
	{
	    armRotation.y += Input.GetAxis("RHoriz") * panSpeed;
	    armRotation.z += Input.GetAxis("RVert") * panSpeed;
	    transform.position = player.transform.position;
        transform.rotation = Quaternion.Euler(armRotation);     //Vector3를 Quaternion으로 바꿀 때는 이 메서드 사용. 
	}
}
