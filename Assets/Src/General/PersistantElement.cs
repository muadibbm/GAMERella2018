using UnityEngine;

public class PersistantElement : MonoBehaviour {

    public string nameToSave; // needs to be unique across the game
    public MonoBehaviour targetScript;

	private void Awake () {
        this.targetScript.enabled = PlayerPrefs.GetInt(this.nameToSave, 0) == 1;
	}

    private void OnEnable() {
        PlayerPrefs.SetInt(this.nameToSave, 1);
    }
}
