using UnityEngine;

public class CounterHelper : MonoBehaviour {

	public static CounterHelper Instance;
	public GUIText countText;
	public GUIText lifeText;
	private int count;
	void Awake()
	{
		// Register the singleton
		if (Instance != null)
		{
			Debug.LogError("Multiple instances of CounterHelper!");
		}
		
		Instance = this;
	}
	// Use this for initialization
	void Start()
	{
		count = 0;
		countText.text = "Score: 0";
		lifeText.text = "Life: 10";
	}

	public void addCount()
	{
		count = count + 1;
		countText.text = "Score: "+count.ToString();
	}

	public void displayLife(int hp)
	{
		lifeText.text = "Life: " + hp.ToString ();
	}
}
