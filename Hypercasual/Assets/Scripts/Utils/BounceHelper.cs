using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BounceHelper : MonoBehaviour
{
    [Header("Animation")]
	public float scaleDuration = .2f;
	public float scaleBounce = 1.2f;
	public Ease ease = Ease.OutBack;

	public void Bounce()
	{
		transform.DOScale(scaleBounce, scaleDuration).SetEase(ease).SetLoops(2, LoopType.Yoyo);
	}
	private void Update()
	{
		if(Input.GetKeyDown(KeyCode.V))
		{
			Bounce();
		}
	}
}
