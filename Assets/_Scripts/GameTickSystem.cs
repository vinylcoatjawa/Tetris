using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTickSystem : MonoBehaviour
{
    
    public const float TICK_TIMER_MAX = 0.5f;

    int _tick;
    float _tickTimer; 
    // Update is called once per frame
    void Awake()
    {
        _tick = 0;
    }
    void Update()
    {
        _tickTimer += Time.deltaTime;
        if (_tickTimer >= TICK_TIMER_MAX){
            _tickTimer -= TICK_TIMER_MAX;
            _tick++;
            //Debug.Log($"Tick: {_tick}");
        }
    }
}
