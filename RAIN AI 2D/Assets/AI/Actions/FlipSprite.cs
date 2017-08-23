using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Action;
using RAIN.Core;

[RAINAction]
public class FlipSprite : RAINAction
{
    public override void Start(RAIN.Core.AI ai)
    {
        base.Start(ai);
    }

    public override ActionResult Execute(RAIN.Core.AI ai)
    {
		GameObject playerGO = ai.WorkingMemory.GetItem<GameObject> ("playerObj");
		if (ai.Body.transform.position.x < playerGO.transform.position.x) {
			ai.Body.GetComponent<SpriteRenderer> ().flipX = false;
		} else {
			ai.Body.GetComponent<SpriteRenderer> ().flipX = true;
		}
        return ActionResult.SUCCESS;
    }

    public override void Stop(RAIN.Core.AI ai)
    {
        base.Stop(ai);
    }
}