using System.Net.NetworkInformation;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class GameManager : MonoBehaviour
{
    public bool recording = true;

	void Update () {
	    if (CrossPlatformInputManager.GetButton("Fire1"))
	    {
	        recording = false;
	    }
	    else
	    {
	        recording = true;
	    }
	}
}
