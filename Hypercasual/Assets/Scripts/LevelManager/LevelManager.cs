using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LevelManager : MonoBehaviour
{
	public Transform container;
	 
	public List<GameObject> levels;

	public List<LevelPieceBaseSetup> levelPieceBaseSetup;

	public float timeBetweenPieces = .3f;

	[SerializeField] private int _index;
	private GameObject _currentLevel;

	private List<LevelPieceBase> _spawnedPieces = new List<LevelPieceBase>();
	private LevelPieceBaseSetup _currSetup;

	[Header("Animation")]
	public float scaleDuration = .2f;
	public float scaleTimeBetweenPieces = .1f;
	public Ease ease = Ease.OutBack;

	private void Awake()
	{
		//SpawnNextLevel();
		CreateLevelPieces();

	}
	private void SpawnNextLevel()
	{
		if(_currentLevel != null)
		{
			Destroy(_currentLevel);
			_index++;
			if(_index >= levels.Count)
			{
				ResetLevelIndex();
			}
		}
		_currentLevel = Instantiate(levels[_index], container);
		//currentLevel.transform.localPosition = Vector3.zero;
	}

	private void ResetLevelIndex()
	{
		_index = 0;
	}

	#region Level

	private void CreateLevelPieces()
	{
		CleanSpawnedPieces();

		if (_currSetup != null)
		{
			_index++;

			if (_index >= levelPieceBaseSetup.Count)
			{
				ResetLevelIndex();
			}
		}

		_currSetup = levelPieceBaseSetup[_index];

		for(int i = 0; i < _currSetup.piecesStartNumber; i++)
		{
			CreateLevelPiece(_currSetup.levelPiecesStart);
		}

		for(int i = 0; i < _currSetup.piecesNumber; i++)
		{
			CreateLevelPiece(_currSetup.levelPieces);
		}

		for(int i = 0; i < _currSetup.piecesEndNumber; i++)
		{
			CreateLevelPiece(_currSetup.levelPiecesEnd);
		}

		//ColorManager.Instance.ChangeColorByType(_currSetup.artType);

		StartCoroutine(ScalePiecesByTime());
		
	}


	private void CreateLevelPiece(List<LevelPieceBase> list)
	{
		var piece = list[Random.Range(0, list.Count)];
		var spawnedPiece = Instantiate(piece, container);

		if(_spawnedPieces.Count > 0)
		{
			var lastPiece = _spawnedPieces[_spawnedPieces.Count-1];

			spawnedPiece.transform.position = lastPiece.endPiece.position;
		}
		/*else
		{
			spawnedPiece.transform.localPosition = Vector3.zero;
		}
		
		foreach(var p in spawnedPiece.GetComponentsInChildren<ArtPiece>())
		{
			p.ChangePiece(ArtManager.Instance.GetSetupByType(_currSetup.artType).gameObject);
		}
		*/
		_spawnedPieces.Add(spawnedPiece);
	}

	private void CleanSpawnedPieces()
	{
		for (int i= _spawnedPieces.Count -1 ; i >= 0; i--)
		{
			Destroy(_spawnedPieces[i].gameObject);
		}
		_spawnedPieces.Clear();
	}

	IEnumerator ScalePiecesByTime()
	{
		foreach(var p in _spawnedPieces)
		{
			p.transform.localScale = Vector3.zero;
		}
		yield return null;

		for(int i = 0; i < _spawnedPieces.Count; i++)
		{
			_spawnedPieces[i].transform.DOScale(1, scaleDuration).SetEase(ease);
			yield return new WaitForSeconds(scaleTimeBetweenPieces);
		}
		CoinsAnimationManager.Instance.StartAnimations();
	}

	IEnumerator CreateLevelPiecesCoroutine()
	{
		_spawnedPieces = new List<LevelPieceBase>();

		for(int i = 0; i < _currSetup.piecesNumber; i++)
		{
			CreateLevelPiece(_currSetup.levelPieces);
			yield return new WaitForSeconds(timeBetweenPieces);
		}
	}
	#endregion
}
