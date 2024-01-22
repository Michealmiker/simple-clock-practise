using System;
using UnityEngine;

public class Clock : MonoBehaviour
{
    [SerializeField]
    private Transform hour;
    [SerializeField]
    private Transform minute;
    [SerializeField]
    private Transform second;

    private int _hour;
    private int Hour
    {
        set
        {
            if (_hour == value)
            {
                return;
            }

            _hour = value;
            
            var trans = hour.transform;
            trans.rotation *= RotatePerHour;
        }
    }
    
    private int _minute;
    private int Minute
    {
        set
        {
            if (_minute == value)
            {
                return;
            }

            _minute = value;
            
            var trans = minute.transform;
            trans.rotation *= RotatePerMinute;
        }
    }
    
    private int _second;
    private int Second
    {
        set
        {
            if (_second == value)
            {
                return;
            }

            _second = value;
            
            var trans = second.transform;
            trans.rotation *= RotatePerSecond;
        }
    }
    
    private static readonly Quaternion RotatePerHour = Quaternion.Euler(0, DegreePerHour, 0);
    private static readonly Quaternion RotatePerMinute = Quaternion.Euler(0, DegreePerMinute, 0);
    private static readonly Quaternion RotatePerSecond = Quaternion.Euler(0, DegreePerSecond, 0);
    
    private const int HourCount = 12;
    private const int MinuteCount = 60;
    private const int SecondCount = 60;
    private const float DegreePerHour = 360f / HourCount;
    private const float DegreePerMinute = 360f / MinuteCount;
    private const float DegreePerSecond = 360f / SecondCount;

    private void Start()
    {
        hour.transform.localRotation = Quaternion.Euler(0, DegreePerHour * DateTime.Now.Hour, 0);
        minute.transform.localRotation = Quaternion.Euler(0, DegreePerMinute * DateTime.Now.Minute, 0);
        second.transform.localRotation = Quaternion.Euler(0, DegreePerSecond * DateTime.Now.Second, 0);
    }

    private void Update()
    {
        Hour = DateTime.Now.Hour;
        Minute = DateTime.Now.Minute;
        Second = DateTime.Now.Second;
    }
}