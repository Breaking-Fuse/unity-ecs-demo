using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public class Rotator : MonoBehaviour
{
    public float speed;
    public string direction;
}

class RotatorSystem : ComponentSystem
{
    struct Components
    {
        public Rotator rotator;
        public Transform transform;
    }

    protected override void OnUpdate()
    {
        float deltaTime = Time.DeltaTime;

        Entities.ForEach((Transform transform, Rotator rotator) => {
            if (rotator.direction == "horizontal")
            {
                transform.Rotate(0f, rotator.speed * deltaTime, 0f);
            }
            else if (rotator.direction == "vertical")
            {
                transform.Rotate(rotator.speed * deltaTime, 0f, 0f);
            }
            
        });
    }
}
