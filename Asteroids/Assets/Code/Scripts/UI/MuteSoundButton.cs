using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuteSoundButton : MonoBehaviour
{
	[SerializeField] Text buttonLabel = default;
	[SerializeField] string onLabel = "Mute Sound";
	[SerializeField] string offLabel = "Unmute Sound";

	public void ToggleMute()
	{
		AudioListener.volume = 1 - AudioListener.volume;
		if(AudioListener.volume > 0)
		{
			buttonLabel.text = onLabel;
		}
		else
		{
			buttonLabel.text = offLabel;
		}
	}
}
