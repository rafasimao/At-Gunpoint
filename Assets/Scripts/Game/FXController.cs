using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FXController : MonoBehaviour 
{

	public GameObject[] FXPrefabs;
	public enum FXTypes {Explosion=0, Break=1};

	Pool[] _FX;
	List<ParticleSystem> _ActiveFX;

	void Start ()
	{
		_FX = new Pool[FXPrefabs.Length];
		for (int i=0; i<FXPrefabs.Length; i++)
			_FX[i] = new Pool(1, FXPrefabs[i], transform);

		_ActiveFX = new List<ParticleSystem>();
	}

	void LateUpdate ()
	{
		for (int i=_ActiveFX.Count-1; i>-1; i--)
		{
			if (!_ActiveFX[i].IsAlive())
			{
				_ActiveFX[i].gameObject.SetActive(false);
				_ActiveFX.RemoveAt(i);
			}
		}
	}

	public void Play (FXTypes type, Vector3 pos)
	{
		ParticleSystem fx = _FX[(int)type].GetPooledObj<ParticleSystem>();
		if (fx != null)
		{
			fx.gameObject.SetActive(true);

			pos.y = fx.transform.position.y;
			fx.transform.position = pos;
			fx.time = 0f;
			fx.Play();

			_ActiveFX.Add(fx);
		}
	}

}
