using System.Collections;
using UnityEngine;

public class DissapearingPlatform : Platform
{
    public override void OnPlayerLand()
    {
        StartCoroutine(Dissapear());
    }

    IEnumerator Dissapear()
    {
        yield return new WaitForSeconds(0.2f);
        GameMaster.Instance.PlaySFX("break");
        gameObject.SetActive(false);
    }
}
