using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToAcidBehaviour : Task {

    public GameObject acid;

    public override void doBehaviour(BehaviorManager manger)
    {
        manger.agent.destination = acid.transform.position;
    }

    public override bool checkBehavior(BehaviorManager manager)
    {
        if(manager.health < 25)
        {
            return true;
        }
        return false;
    }

    public override void updateBehavior(BehaviorManager manager)
    {
        if(checkBehavior(manager))
        {

        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
