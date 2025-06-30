using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class PowerUpBase : ItemCollectableBase
{
	[Header("Power Up")]
	public float duration;
	protected override void OnCollect()
	{
		base.OnCollect();
		StartPowerUp();
	}
	protected virtual void StartPowerUp()
	{
		Debug.Log("Start Power Up");
		Invoke(nameof(EndPowerUp), duration);
	}
	protected virtual void EndPowerUp()
	{
		Debug.Log("End Power Up");
	}
}
