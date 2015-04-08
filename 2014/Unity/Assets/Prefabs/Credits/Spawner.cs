using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {
    public GameObject Andi;
    public GameObject Roman;
    public GameObject Michi;
    public GameObject Domi;
    public GameObject EndText;

	// Use this for initialization
	void Start () {
        StartCoroutine("credits");
	}
	
	// Update is called once per frame
    IEnumerator credits()
    {
        yield return new WaitForSeconds(1);
        Instantiate(Andi, transform.position, Andi.transform.rotation);
        yield return new WaitForSeconds(10);
        Instantiate(Roman, transform.position, Roman.transform.rotation);
        yield return new WaitForSeconds(10);
        Instantiate(Michi, transform.position, Michi.transform.rotation);
        yield return new WaitForSeconds(10);
        Instantiate(Domi, transform.position, Domi.transform.rotation);
        yield return new WaitForSeconds(10);
        Instantiate(EndText, new Vector3 (transform.position.x , transform.position.y, EndText.transform.position.z) , transform.rotation);
        yield return new WaitForSeconds(20);
        Application.LoadLevel(0);

    }
}
