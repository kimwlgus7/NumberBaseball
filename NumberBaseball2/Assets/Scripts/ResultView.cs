using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Result
{
    public int[] Guess;
    public int Strike;
    public int Ball;
    public int Out;
}


public class ResultView : MonoBehaviour {

	int submitCount = 0;

	public Transform content;

	public GameObject ResultItem;
	public GameObject EndItem;
	public GameObject WarningItem;
	public Image[] ResultIcons;
	public Color StrikeColor;
	public Color BallColor;
	public Color OutColor;

	public void DisplayResult(Result result)
	{
		submitCount++;

		if(result.Strike ==3)
		{
			GameObject obj = Instantiate (EndItem, content);
			obj.GetComponentInChildren<Text> ().text = submitCount + "번째만에";
		}
		else
		{
			GameObject obj = Instantiate(ResultItem, content);
			obj.GetComponent<ResultItem>().Setup(submitCount, result);
		}
		for(int i=0; i<3; i++)
		{
			if (i < result.Strike)
			{
				ResultIcons[i].color = StrikeColor;
			}
			else if(i < result.Strike + result.Ball)
			{
				ResultIcons[i].color = BallColor;
			}
			else
			{
				ResultIcons[i].color = OutColor;
			}
		}

	}
	public void DisplayWarning()
	{
		Instantiate(WarningItem, content);

	}
}
