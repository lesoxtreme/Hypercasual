using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtPiece : MonoBehaviour
{
	public GameObject currentArt;
	public GameObject piece;

	public void ChangePiece()
	{
		if(currentArt != null) Destroy(currentArt);

		currentArt = Instantiate(piece, transform);
		currentArt.transform.localPosition = Vector3.zero;
	}
}
