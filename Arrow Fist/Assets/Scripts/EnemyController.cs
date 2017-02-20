using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum EnemyState{PATROL,CHASE}

public class EnemyController : MonoBehaviour {

	public Vector2 patrolArea;
	public float timeToUpdatePatrol;
	public float minDistanceToPatrol;
	private Vector3 startEnemyPosition;

	private EnemyState currentState;

	Animator playerAnimator;
	private Transform playerTransform;
	private NavMeshAgent agent;
	private Animator enemyAnimator;
	private Vector3 destination;
	AnimatorStateInfo currentStateAnimation;
	public float timeAnimation;

	void Start () 
	{
		playerAnimator = GetComponent<Animator>();
		agent = GetComponent<NavMeshAgent>();
		playerTransform = GameObject.FindGameObjectWithTag ("Player").transform; 
		enemyAnimator = GetComponent<Animator>();
		currentState = EnemyState.PATROL;
		startEnemyPosition = transform.position;
		StartCoroutine("UpdatePatrolDestination");

	}
	

	void Update () 
	{
		//currentStateAnimation = playerAnimator.GetCurrentAnimatorStateInfo (0);

		if (agent.velocity.sqrMagnitude == 0) {
			
			enemyAnimator.SetFloat ("speed", 0f);

		} else 
		{
			enemyAnimator.SetFloat("speed",1f);
		}

		if ((playerTransform.position - transform.position).sqrMagnitude > (minDistanceToPatrol * minDistanceToPatrol)) 
		{	
			if (currentState != EnemyState.PATROL) 
			{
				StartCoroutine ("UpdatePatrolDestination");		
			}
			currentState = EnemyState.PATROL;

		}else if((playerTransform.position - transform.position).sqrMagnitude <= 0.1f )
		{
												
			GameState.instance.ChangeState (States.GAME_OVER);

		}else
		{
			StopCoroutine ("UpdatePatrolDestination");
			currentState = EnemyState.CHASE;
			destination = playerTransform.position;
		}

		agent.SetDestination(destination);
	}

	IEnumerator UpdatePatrolDestination()
	{

		destination = new Vector3 (startEnemyPosition.x + Random.Range(-patrolArea.x,patrolArea.x), 
									startEnemyPosition.y,
									startEnemyPosition.z + Random.Range(-patrolArea.y,patrolArea.y));

		yield return new WaitForSeconds (timeToUpdatePatrol);

		if (currentState == EnemyState.PATROL) 
		{
			StartCoroutine("UpdatePatrolDestination");
		}
	}

	IEnumerator delayAnimation()
	{
		yield return new WaitForSeconds(timeAnimation);
	}
}

