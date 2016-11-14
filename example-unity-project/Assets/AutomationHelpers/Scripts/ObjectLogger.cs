using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class ObjectLogger : MonoBehaviour
{
	public GameObject[] LoggedObjects = { };
	public GameObject UIMenuObject;

	// Use this for initialization
	void Start ()
	{
		SceneStartToLog ();

		Debug.Log ("Adding scripts to log position of " + LoggedObjects.Length + " Gameobject components");
		GameObject loggableObject;
		for (int i = 0 ; i < LoggedObjects.Length ; i++)
		{
			loggableObject = LoggedObjects [i];
			if (loggableObject == null)
				return;
			loggableObject.AddComponent<CoordinateLog>();
		}

		if (UIMenuObject != null)
		{
			Transform[] uiObjectChildren = { };
			uiObjectChildren = UIMenuObject.GetComponentsInChildren<Transform> ();

			Debug.Log ("Adding scripts to log position of " + uiObjectChildren.Length + " UI component");
			for (int i = 0; i < uiObjectChildren.Length; i++)
			{
				loggableObject = uiObjectChildren [i].gameObject;
				if (loggableObject == null)
					return;
				loggableObject.AddComponent<UICoordinateLog>();
			}
		}
	}

	void SceneStartToLog()
	{
		Debug.Log (string.Format("Automation: {{\"event\" : \"scene_entered\", \"scene_name\" : \"{0}\"}}", 
			SceneManager.GetActiveScene().name));
	}
}
