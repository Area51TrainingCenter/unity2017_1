using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Action;
using RAIN.Core;

[RAINAction]
public class CabiarFlip : RAINAction
{
    public override void Start(RAIN.Core.AI ai)
    {
        base.Start(ai);
    }

    public override ActionResult Execute(RAIN.Core.AI ai)
    {
		GameObject PlayerGo =  ai.WorkingMemory.GetItem<GameObject> ("Player");
		if (ai.Body.transform.position.x > PlayerGo.transform.position.x) {
			ai.Body.GetComponent<SpriteRenderer> ().flipX = true;
		} else {
			ai.Body.GetComponent<SpriteRenderer> ().flipX = false;
		}
        return ActionResult.SUCCESS;
    }

    public override void Stop(RAIN.Core.AI ai)
    {
        base.Stop(ai);
    }
}