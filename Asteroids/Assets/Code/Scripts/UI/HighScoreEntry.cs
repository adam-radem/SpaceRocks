using UnityEngine;
using UnityEngine.UI;

public class HighScoreEntry : MonoBehaviour
{
	[SerializeField] InputField inputField = default;
	[SerializeField] Text textDisplay = default;
	string playerName = default;

	private void OnEnable()
	{
		int position = HighScores.GetScoreIndex(Scorekeeper.CurrentScore);
		textDisplay.transform.SetSiblingIndex(position);

		inputField.Select();
		UpdateDisplay();
	}

	public void NameChanged(string inputName)
	{
		playerName = inputName;
		UpdateDisplay();
	}

	public void NameFinalized(string inputName)
	{
		playerName = inputName;
		UpdateDisplay();
		HighScores.ReportScore(playerName, Scorekeeper.CurrentScore);
		inputField.interactable = false;
	}

	void UpdateDisplay()
	{
		string nameDisplay = (playerName + "___").Substring(0, 3);
		var display = $"{nameDisplay}................ {Scorekeeper.CurrentScore:N0}";
		textDisplay.text = display;
	}
}