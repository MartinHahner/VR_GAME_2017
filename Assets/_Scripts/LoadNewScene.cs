using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadNewScene : MonoBehaviour {

  public void LoadByIndex(int sceneIndex){

  	SceneManager.LoadScene(sceneIndex);

  }

}
