using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour {

	public GameObject floor;
	public GameObject aF;
	public GameObject eF;
	public GameObject iF;
	public GameObject oF;
	public GameObject uF;
	public GameObject tF;
	public GameObject nF;
	public GameObject sF;
	public GameObject hF;
	public GameObject rF;
	public GameObject dF;
	public GameObject lF;


	List<GameObject> floorList = new List<GameObject> ();

	public int manyFloors = 0;

	float rightChance, leftChance, genChance;

	public Vector3 totalTransform;

	void Start(){
		rightChance = Random.Range (1.75f, 2.75f);
		leftChance = Random.Range (1.75f, 2.75f);
		genChance = Random.Range (.1f, .2f);
		totalTransform = new Vector3 (0f, 0f, 0f);
	}
	
	// Update is called once per frame
	void Update () {


		//do the rotation and movement
		float rotateAmount = Random.Range(0f, 10f);
		if (rotateAmount < genChance) {
			//make a new gen
			GameObject.FindGameObjectWithTag ("gengen").GetComponent<GeneratorGenerator> ().MakeGen (transform.position, Quaternion.identity);
			rotateAmount = 0f;
		} else if (rotateAmount < genChance + leftChance) {
			rotateAmount = 1f;
		} else if (rotateAmount < genChance + leftChance + rightChance) {
			rotateAmount = 3f;
		} else {
			rotateAmount = 0f;
		}
			
		transform.Rotate(0f, rotateAmount * 90f, 0f);
		transform.Translate(5f, 0f, 0f);
			

		Ray ray = new Ray (transform.position + Vector3.down, Vector3.up);

		RaycastHit rayHit = new RaycastHit();

		//if a raycast at the current location, aimed upwards, doesn't hit anything, make a new floor
		if (Physics.Raycast (ray, out rayHit, 5f)) {
		} else {
			GameObject floorNow;
			float chance = Random.Range (0f, 80.591f);
			if (chance < 12.702f) {
				floorNow = Instantiate (eF, transform.position, Quaternion.identity);
			} else if (chance < 20.869f) {
				floorNow = Instantiate (aF, transform.position, Quaternion.identity);
			} else if (chance < 28.376f) {
				floorNow = Instantiate (oF, transform.position, Quaternion.identity);
			} else if (chance < 35.342f) {
				floorNow = Instantiate (iF, transform.position, Quaternion.identity);
			} else if (chance < 38.1f) {
				floorNow = Instantiate (uF, transform.position, Quaternion.identity);
			} else if (chance < 47.156f) {
				floorNow = Instantiate (tF, transform.position, Quaternion.identity);
			} else if (chance < 53.805f){
				floorNow = Instantiate (nF, transform.position, Quaternion.identity);
			} else if (chance < 60.232f){
				floorNow = Instantiate (sF, transform.position, Quaternion.identity);
			} else if (chance < 66.326f){
				floorNow = Instantiate (hF, transform.position, Quaternion.identity);
			} else if (chance < 72.313f){
				floorNow = Instantiate (rF, transform.position, Quaternion.identity);
			} else if (chance < 76.566f){
				floorNow = Instantiate (dF, transform.position, Quaternion.identity);
			} else if (chance < 80.591f){
				floorNow = Instantiate (lF, transform.position, Quaternion.identity);
			} else {
				floorNow = Instantiate (floor, transform.position, Quaternion.identity);
			}


			floorList.Add (floorNow);
			totalTransform += transform.position;
			manyFloors = floorList.Count;
		}

	}
}
