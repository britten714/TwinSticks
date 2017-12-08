using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;

public class GameManager : MonoBehaviour
{
    public bool recording = true;

    void Start()
    {
        PlayerPrefsManager.UnlockLevel(2);
        print(PlayerPrefsManager.IsLevelUnlocked(1));
        print(PlayerPrefsManager.IsLevelUnlocked(2));
    }

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
