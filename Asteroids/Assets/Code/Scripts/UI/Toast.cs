using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Toast : AnimatorBehavior
{
	static GameObject ToastPrefab { get; set; }

    [SerializeField] Text textDisplay = default;

    void SetText(string text)
	{
		textDisplay.text = text;
	}

	void SetLifeTime(float lifetime)
	{
		Destroy(gameObject, lifetime);
		Invoke("Dismiss", lifetime - 0.5f);
	}

	void Dismiss()
	{
		animator.SetTrigger("Dismiss");
	}

	public static void Show(string text, float lifetime)
	{
		if (!ToastPrefab) {
			ToastPrefab = Resources.Load<GameObject>("Toast");
		}

		var newToast = Instantiate(ToastPrefab);
		var toast = newToast.GetComponent<Toast>();

		toast.SetText(text);
		toast.SetLifeTime(lifetime);
	}
}
