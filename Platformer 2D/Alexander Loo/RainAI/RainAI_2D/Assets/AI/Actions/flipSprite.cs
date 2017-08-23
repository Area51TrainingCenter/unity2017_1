using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Action;
using RAIN.Core;

[RAINAction]
public class flipSprite : RAINAction
{
    public override void Start(RAIN.Core.AI ai)
    {
        base.Start(ai);
    }

    public override ActionResult Execute(RAIN.Core.AI ai)
    {
		//Para obtener el gameObject en la variable ya guardada en el detect del AI
		GameObject player = ai.WorkingMemory.GetItem<GameObject> ("playerPosition");
		//para obtener el gameObject del AI (sin importar si es hijo o padre) 
		if (ai.Body.transform.position.x < player.transform.position.x) {
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