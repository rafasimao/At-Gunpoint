using UnityEngine;
using System.Collections;

public class PointsController : MonoBehaviour
{

	public Transform PointsParent;
	public GameObject PointsPrefab;

	Pool _Points;

	void Start ()
	{
		Initiate();
	}
	
	void Initiate ()
	{
		_Points = new Pool(1, PointsPrefab, PointsParent, true, true);
	}
	
	void Clear ()
	{
		_Points.Clear(0f);
	}
	
	public void Reset ()
	{
		Clear();
		Initiate();
	}

	public void ShowPoints (Vector3 worldPos, int points)
	{
		PointEffectView effect = _Points.GetPooledObj<PointEffectView>();
		effect.Points = points;
		effect.WorldPosition = worldPos;

		effect.gameObject.SetActive(true);
	}

}
