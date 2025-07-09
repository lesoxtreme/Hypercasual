using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]

public class LevelPieceBaseSetup : ScriptableObject
{
	public ArtManager.ArtType artType;

	[Header("Pieces")]
	public List<LevelPieceBase> levelPiecesStart;
	public List<LevelPieceBase> levelPieces;
	public List<LevelPieceBase> levelPiecesEnd;

	public int piecesStartNumber = 3;
	public int piecesNumber = 8;
	public int piecesEndNumber = 1;
}
