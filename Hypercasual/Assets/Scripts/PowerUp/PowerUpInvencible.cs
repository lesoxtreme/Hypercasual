using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpInvencible : PowerUpBase
{
	protected override void StartPowerUp()
	{
		base.StartPowerUp();
		Debug.Log(PlayerController.Instance == null ? "Instance está null!" : "Instance OK");
		PlayerController.Instance.SetPowerUpText("Invencible");
		PlayerController.Instance.SetInvencible();
	}
	protected override void EndPowerUp()
	{
		base.EndPowerUp();
		PlayerController.Instance.SetInvencible(false);
		PlayerController.Instance.SetPowerUpText("");
	}
}
