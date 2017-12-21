using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class PlayerPrefsManager : MonoBehaviour {

	const string MASTER_VOLUME_KEY =  "master_volume";
	const string DIFFICULTY_KEY = "difficulty";
	const string LEVEL_KEY = "level_unlocked_";
	
	public static void SetMasterVolume (float volume) {
		if (volume >= 0 && volume <= 1) {
			PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
		}
		else {
			Debug.LogError("Volume out of range");
		}
	}
	
	public static float GetMasterVolume () {
		return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
	}
	
	public static void UnlockLevel (int level) {
		if (level <= SceneManager.sceneCountInBuildSettings - 1) {
			PlayerPrefs.SetInt(LEVEL_KEY + level.ToString(), 1);
		} 
		else {
			Debug.LogError("Trying to unlock a level out of build order");
		}
	}
	
	public static bool IsLevelUnlocked (int level){
		bool isUnlocked = (PlayerPrefs.GetInt(LEVEL_KEY + level.ToString()) == 1);
		if (level <= SceneManager.sceneCountInBuildSettings - 1){
			return isUnlocked;
		} 
		else {
			Debug.LogError("Trying to investigate level out of build order");
			return false;
		}
	}
	
	public static float GetDifficulty () {
		return PlayerPrefs.GetFloat(DIFFICULTY_KEY);
	}
	
	public static void SetDifficulty (float difficulty) {
		if (difficulty >= 1f && difficulty <= 3f) {
			PlayerPrefs.SetFloat(DIFFICULTY_KEY, difficulty);
		}
		else {
			Debug.LogError("Difficulty value out of range");
		}
	}
	
	
}
