using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MissionCompleteEffect : MonoBehaviour 
{
	public Image MissionBackground;
	public Color FromColor, ToColor;

	public float TransitionTime;
	public float CutTransitionPercent;

	public float GrowTime, ReduceTime;
	public Vector3 GrownSize;

	bool _IsPlaying;
	int _State;

	float _Timer, _InitialTime;

	public void Play ()
	{
		MissionBackground.color = FromColor;
		_IsPlaying = true;
		_Timer = 0f;
		_State = 0;
		_InitialTime = Time.realtimeSinceStartup;
	}

	void Update ()
	{
		if (_IsPlaying)
		{
			switch (_State)
			{
			case 0:
				if (LerpColor())
					GoToNextState();
				break;
			case 1:
				if (LerpSize(Vector3.one, GrownSize, GrowTime))
					GoToNextState();
				break;
			case 2:
				if (LerpSize(GrownSize, Vector3.one, ReduceTime))
					GoToNextState();
				break;
			default:
				_IsPlaying = false;
				break;
			}
		}
	}

	void GoToNextState ()
	{
		_State++;
		_Timer = 0f;
		_InitialTime = Time.realtimeSinceStartup;

		if (_State>2)
			_IsPlaying = false;
	}

	float UpdateTimer (float transitionTime)
	{
		//_Timer += Time.deltaTime;
		_Timer = Time.realtimeSinceStartup - _InitialTime;
		return _Timer/transitionTime;
	}

	bool LerpColor ()
	{
		float transition = UpdateTimer(TransitionTime);

		if (transition<CutTransitionPercent)
		{
			MissionBackground.color = Color.Lerp(FromColor, ToColor, transition);
			return false;
		}
		else 
		{
			MissionBackground.color = ToColor;
			return true;
		}
	}

	bool LerpSize (Vector3 from, Vector3 to, float time)
	{
		float transition = UpdateTimer(time);

		transform.localScale = Vector3.Lerp(from,to,transition);

		return (transition>=1f);
	}


}
