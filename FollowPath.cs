using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPath : MonoBehaviour
{
    // Start is called before the first frame update
    public enum MoveType
    {
        Linear,
        Lerp,
        Physics
    }
    public MoveType[] MoveTypes;
    public MovementPath[] paths;
    public float MoveSpeed = 0.5f;
    public float Distance = 0.1f;
    public float WaitTime = 0f;
    public int LoopStart = 0;
    public bool setStart = true;
    public bool RandomPath = false;
    public bool Waiting = false;
    public bool SimpleShootOnWait = true;
    public bool MoveWithLevel = false;
    public EnemyGunManager guns;

    private MoveType CMType = MoveType.Linear;
    private float WaitTimer = 0f;
    private float stepWait = 0f;
    private float stepSpeed = 1f;
    private int step = 0;
    private int path = 0;
    private Rigidbody2D rig;
    private Vector3 goal;
    private Vector3 lvlOffset;
    private BackgroundSettings settings;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        path = -1;
        if (MoveWithLevel)
        {
            settings = GameObject.Find("Level").GetComponent<BackgroundSettings>();
        }
    }
    private void OnEnable()
    {
        step = 0;
        path = -1;
        lvlOffset = Vector3.zero;
        if (rig != null)
        {
            rig.velocity = Vector2.zero;
            rig.angularVelocity = 0;
            transform.rotation = Quaternion.identity;
            rig.isKinematic = true;
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (MoveWithLevel)
        {
            lvlOffset += settings.globalScroll * settings.scrollSpeed * Time.deltaTime;
            transform.Translate(settings.globalScroll * settings.scrollSpeed * Time.deltaTime);
        }
        if (paths.Length > 0)
        {
            if (path == -1)
            {
                Random.InitState((int)System.DateTime.Now.Ticks);
                path = Random.Range(0, LoopStart - 1);
                SetGoal();
                if (setStart)
                {
                    transform.position = paths[path].PathSequence[0].position;
                }
            }
                if (CMType == MoveType.Linear)
            {
                transform.position = Vector3.MoveTowards(transform.position, goal + lvlOffset, MoveSpeed * stepSpeed * Time.deltaTime);
            }
            if (CMType == MoveType.Lerp)
            {
                transform.position = Vector3.Lerp(transform.position, goal + lvlOffset, MoveSpeed * stepSpeed * Time.deltaTime);
            }
            if (CMType == MoveType.Physics)
            {
                if (rig != null)
                {
                    rig.isKinematic = false;
                    rig.AddForce(Vector2.ClampMagnitude((goal + lvlOffset) - transform.position, 1) * stepSpeed * MoveSpeed);
                    rig.velocity = Vector2.ClampMagnitude(rig.velocity, MoveSpeed * stepSpeed);
                }
                else
                {
                    CMType = MoveType.Linear;//if no rigidbody, default to linear movement.
                }
            }
            else if (rig != null)
            {
                rig.velocity = Vector2.zero;
                rig.isKinematic = true;
            }
            if ((transform.position - (goal + lvlOffset)).sqrMagnitude < Distance)
            {
                UpdateGoal();
            }
        }
    }
    void UpdateGoal()
    {
        Waiting = true;
        WaitTimer -= Time.deltaTime;
        if (WaitTimer < 0)
        {
            
            if (step < paths[path].PathSequence.Length - 1)
            {
                step++;//move forward in current path
            }
            else
            {
                if (RandomPath)
                {
                    path = Random.Range(LoopStart, paths.Length);
                }
                else if (path < paths.Length -1)
                {
                    path++;//next path
                    if (path < LoopStart)
                    {
                        path = LoopStart;
                    }
                }
                else
                {
                    path = LoopStart;//or restart the loop
                }
                step = 0;
            }
            SetGoal();
            Waiting = false;
            WaitTimer = WaitTime + stepWait;
        }
        else if (SimpleShootOnWait && guns != null)
        {
            guns.Fire();
        }
        
    }
    void SetGoal()
    {
        
        if (MoveTypes.Length > 0)
        {
            if (step < MoveTypes.Length)
            {
                CMType = MoveTypes[path % MoveTypes.Length];
            }
        }
        stepSpeed = paths[path].PathSequence[step].localScale.x;//using scale x to define per point speeds
        stepWait = paths[path].PathSequence[step].rotation.x;//using rotation x to define time spent waiting on path 
        goal = paths[path].PathSequence[step].position;
    }
}
