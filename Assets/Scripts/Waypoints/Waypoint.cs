using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] private List<Waypoint> waypoints = new List<Waypoint>();
    
    public List<Waypoint> Waypoints { get { return waypoints; } }

    public Vector3 WorldPosition()
        => this.transform.position;
    public Vector3 WorldRotation()
        => this.transform.localRotation.eulerAngles;
}
