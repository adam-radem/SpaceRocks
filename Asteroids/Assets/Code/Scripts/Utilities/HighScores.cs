using System.IO;
using System.Collections.Generic;
using UnityEngine;

public static class HighScores
{
	public struct HighScore
	{
		public string playerName;
		public int scoreValue;
	}

	const int kMaxScoreEntries = 10;
	static List<HighScore> scores;

	public static HighScore[] Scores => scores.ToArray();

	static string SavePath => Path.Combine(Application.persistentDataPath, "scores.bin");
	static HighScores()
	{
		LoadScores();
	}

	public static void ResetScores()
	{
		scores = new List<HighScore>()
		{
			new HighScore() { playerName = "ACR", scoreValue = 10000 },
			new HighScore() { playerName = "ACR", scoreValue = 5000 },
			new HighScore() { playerName = "ACR", scoreValue = 3000 },
			new HighScore() { playerName = "ACR", scoreValue = 2000 },
			new HighScore() { playerName = "ACR", scoreValue = 1000 },
			new HighScore() { playerName = "ACR", scoreValue = 500 },
			new HighScore() { playerName = "ACR", scoreValue = 400 },
			new HighScore() { playerName = "ACR", scoreValue = 300 },
			new HighScore() { playerName = "ACR", scoreValue = 200 },
			new HighScore() { playerName = "ACR", scoreValue = 100 },
		};
		SaveScores();
	}

	static void LoadScores()
	{
		if (File.Exists(SavePath))
		{
			byte[] data = File.ReadAllBytes(SavePath);
			ReadScores(data);
		}
		else
		{
			ResetScores();
		}
	}

	static void SaveScores()
	{
		byte[] data = WriteScores();
		File.WriteAllBytes(SavePath, data);
	}

	static void ReadScores(byte[] data)
	{
		using (MemoryStream stream = new MemoryStream(data))
		{
			using (BinaryReader reader = new BinaryReader(stream))
			{
				int tableLength = reader.ReadInt32();
				scores = new List<HighScore>(tableLength);
				for (int i = 0; i != tableLength; ++i)
				{
					var name = reader.ReadString();
					var score = reader.ReadInt32();
					scores.Add(new HighScore
					{
						playerName = name,
						scoreValue = score
					});
				}
			}
		}
	}

	static byte[] WriteScores()
	{
		using (MemoryStream stream = new MemoryStream())
		{
			using (BinaryWriter writer = new BinaryWriter(stream))
			{
				writer.Write(scores.Count);
				for (int i = 0; i != scores.Count; ++i)
				{
					var score = scores[i];
					writer.Write(score.playerName);
					writer.Write(score.scoreValue);
				}
			}
			return stream.ToArray();
		}
	}

	public static bool IsHighScore(int score)
	{
		return GetScoreIndex(score) >= 0;
	}

	public static int GetScoreIndex(int score)
	{
		for (int i = 0; i != scores.Count; ++i)
		{
			if (score > scores[i].scoreValue)
			{
				return i;
			}
		}
		return -1;
	}

	public static bool ReportScore(string name, int score)
	{
		if (scores.Count < kMaxScoreEntries)
		{
			scores.Add(new HighScore { playerName = name, scoreValue = score });
			SaveScores();
			return true;
		}

		for (int i = 0; i != scores.Count; ++i)
		{
			if (score > scores[i].scoreValue)
			{
				scores.Insert(i, new HighScore { playerName = name, scoreValue = score });
				scores.RemoveAt(kMaxScoreEntries);
				SaveScores();
				return true;
			}
		}

		return false;
	}
}