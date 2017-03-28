using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GeneratorGenerator : MonoBehaviour {

	public GameObject generator;
	List<GameObject> genList = new List<GameObject>();
	int totalFloors = 0;
	Vector3 totalVector;
	Vector3 center;
	float cameraHeight;

	// Use this for initialization
	void Start () {
		GameObject genNow = Instantiate (generator, transform.position, Quaternion.identity);
		genList.Add (genNow);
		totalVector =  new Vector3 (0f, 0f, 0f);
		center =  new Vector3 (0f, 0f, 0f);
		cameraHeight = Camera.main.transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.R)){
			SceneManager.LoadScene("mainGenerator");
		}

		totalFloors = 0;
		totalVector = new Vector3 (0f, 0f, 0f);
		foreach (GameObject genNow in genList) {
			totalFloors += genNow.GetComponent<Generator> ().manyFloors;
			totalVector += genNow.GetComponent<Generator> ().totalTransform;
		}

		if (!(totalFloors == 0)) {
			center = new Vector3 (totalVector.x / totalFloors, 0, totalVector.z/totalFloors);
			Camera.main.transform.position = center + Vector3.up * cameraHeight;
		}

		if (totalFloors > 500) {
			foreach (GameObject genNow in genList) {
				Destroy (genNow);
			}
			genList.Clear ();
		}
	}

	public void MakeGen(Vector3 location, Quaternion direction){
		GameObject genNow = Instantiate (generator, location, direction);
		genList.Add (genNow);
	}
}
