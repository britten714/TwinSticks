using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;

public class GameManager : MonoBehaviour
{
    public bool recording = true;

    private bool isPaused = false;
    private float fixedDeltaTime;

    void Start()
    {
        PlayerPrefsManager.UnlockLevel(2);
        //print(PlayerPrefsManager.IsLevelUnlocked(1));
        //print(PlayerPrefsManager.IsLevelUnlocked(2));

        fixedDeltaTime = Time.fixedDeltaTime;
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

	    if (Input.GetKeyDown(KeyCode.P))
	    {
	        isPaused = !isPaused;
            if (isPaused == true)
	        {
	            PauseGame();                
	        }
	        else
	        {
	            ResumeGame();
	        }
	    }
	}

    void PauseGame()
    {
        Time.timeScale = 0;         //timeScale이 0이어도 Update()는 계속 호출된다. 다만 timeScale이 0이니까 움직이거나 하지 않는 것. 
        Time.fixedDeltaTime = 0;    //그리고 API에 따르길 timeScale 바꾸면 fixedDeltaTime도 바꿔주는 게 좋다고 함. 
    }

    void ResumeGame()
    {
        Time.timeScale = 1;
        Time.fixedDeltaTime = fixedDeltaTime;
    }

    void OnApplicationPause(bool pauseStatus)   //이건 사용자가 아닌 OS에서 게임을 멈췄을 때 그걸 어떻게 다룰 지에 대한 코드
    {
        isPaused = pauseStatus;                 //그 경우 pauseStatus == true가 되서 isPaused 역시 true가 될 것이다. 다만 그렇다고 해서 게임이 멈추지는 않는데 왜냐하면 위에서 게임을 멈추게 하려면 P를 눌러야 한다고 정했으니까. 그럼 어떻게? 여기서는 다루지 않는다. 불완전한 코드. 지금은  이런 내용있다고만 알아두자. 
        PauseGame();                            //다만 내 생각에 그냥 이것만 추가하면 되지 않을까? 아무튼 API 읽어보면 우리가 게임하다가 홈버튼 눌렀을 때 이 메서드가 작동된다고 함. OnApplicationFocus 도 나중에 함께 공부. 
    }
}
