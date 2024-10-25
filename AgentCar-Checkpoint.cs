using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;

public class AgentController : Agent
{
    [SerializeField] private Transform[] checkpoints;
    [SerializeField] public float moveSpeed = 6f;

    private Rigidbody rb;
    private int currentCheckpointIndex = 0;

    public override void Initialize()
    {
        rb = GetComponent<Rigidbody>();
    }

    public override void OnEpisodeBegin()
    {
        transform.localPosition = new Vector3(38.5f, 0.3f, 3f);

        currentCheckpointIndex = 0;
        for (int i = 0; i < checkpoints.Length; i++)
        {
            checkpoints[i].gameObject.SetActive(true);
        }
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(transform.localPosition);

        if (currentCheckpointIndex < checkpoints.Length)
        {
            sensor.AddObservation(checkpoints[currentCheckpointIndex].localPosition);
        }
        else
        {
            sensor.AddObservation(Vector3.zero);
        }
    }

    public override void OnActionReceived(ActionBuffers actions)
    {
        float moveRotate = actions.ContinuousActions[0];
        float moveForward = actions.ContinuousActions[1];

        rb.MovePosition(transform.position + transform.forward * moveForward * moveSpeed * Time.deltaTime);
        transform.Rotate(0f, moveRotate * moveSpeed, 0f, Space.Self);
    }

    public override void Heuristic(in ActionBuffers actionOut)
    {
        ActionSegment<float> continuousAction = actionOut.ContinuousActions;
        continuousAction[0] = Input.GetAxisRaw("Horizontal");
        continuousAction[1] = Input.GetAxisRaw("Vertical");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Checkpoint" && other.transform == checkpoints[currentCheckpointIndex])
        {
            AddReward(1f);
            other.gameObject.SetActive(false);
            currentCheckpointIndex++;
            if (currentCheckpointIndex == checkpoints.Length)
            {
                AddReward(5f);
                EndEpisode();
            }
        }
        else if (other.gameObject.tag == "Checkpoint" && other.transform != checkpoints[currentCheckpointIndex])
        {
            AddReward(-1f);
        }

        if (other.gameObject.tag == "Wall")
        {
            AddReward(-1f);
            EndEpisode();
        }
    }
}
