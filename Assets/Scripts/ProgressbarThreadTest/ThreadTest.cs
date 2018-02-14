using System;
using System.Threading;
using UnityEngine;
using ProgressBar;

public class ThreadTest : MonoBehaviour
{

    public Action<float> progressbar;
    public ProgressBarBehaviour progress;

    private void Thread_A()
    {
        for (float i = 0; i < 5; i++)
        {
            Debug.Log("Thread A :" + (i / 5));
            progressbar?.Invoke(i / 5 * 100);
            Thread.Sleep(1);
        }
    }

    private void Thread_B()
    {
        for (int i = 0; i < 5; i++)
        {
            Debug.Log("Thread B :" + i);
        }
        Thread.Sleep(100);
    }

    public void OnClick()
    {
        var Th_A = new Thread(Thread_A);
        Th_A.IsBackground = true;
        var Th_B = new Thread(Thread_B);
        Th_B.IsBackground = true;
        Th_A.Start();
        //Th_B.Start();

        progressbar += progress.IncrementValue;
    }
}
