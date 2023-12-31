﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ETFHelper_WPF.Services;

public class ProcessService : IDisposable
{
    #region ველები

    private static readonly int WaitingTime = 2000;
    private IEnumerable<string> _processNames;
    private CancellationTokenSource _tokenSource;
    private Process _activeProcess;
    private int _processId;

    #endregion


    #region კონსტრუქტორი


    public  ProcessService(string  processName)
        : this(new string[] { processName })
    {

    }


    /// <summary>
    /// Initializes a new instance of the <see cref="ProcessService"/> class.
    /// </summary>
    /// <param name="processNames">The process names.</param>
    public ProcessService(IEnumerable<string> processNames)
    {
        _processNames = processNames;
        _tokenSource = new CancellationTokenSource();
    }


    #endregion



    #region ივენთები

    /// <summary>
    /// The process  ended.
    /// </summary>
    public event EventHandler ProcessClosed;

    #endregion

    #region მეთოდები

    /// <summary>
    ///  Gets my process  by identifier.
    /// </summary>
    /// <param name="processId">The process  identifier.</param>
    /// <returns>The process.</returns>
    public static  Process?  GetProcessById(int processId)
    {
        try
        {
            return Process.GetProcessById(processId);
        }
        catch
        {
            return null;
        }
    }


    
    /// <summary>
    /// Gets the  current process  identifier.
    /// </summary>
    public static int  CurrentProcessId => Process.GetCurrentProcess().Id;



    /// <summary>
    /// Waits for process.
    /// </summary>
    /// <returns>The process.</returns>
    public virtual async Task<int> WaitForProcess()
    {
        var process = GetProcess();

        while (process is null)
        {
            await  Task.Delay(WaitingTime);
            process = GetProcess();
        }

        WaitForExit();
        return WaitForWindowHandle();
    }

    /// <summary>
    /// Performs application-defined tasks  associated  with freeing,  releasing, or  resetting unmanaged resources
    /// </summary>
    public  void Dispose()
    {
        Dispose(true);
    }

    /// <summary>
    /// Called  when [exit]
    /// </summary>
    protected  virtual void OnExit()
    {

    }

    /// <summary>
    /// Releases  unmanaged  and -  optionally - managed resources
    /// </summary>
    /// <param name="disposing"></param>
    protected  virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
           _tokenSource.Cancel(); 

            _activeProcess?.Dispose();
        }
    }

    /// <summary>
    /// Gets the process.
    /// </summary>
    /// <returns>The  process.</returns>
    private Process? GetProcess()
    {
        if (_activeProcess != null)
        {
            _activeProcess.Dispose();   
        }

        foreach(var processName in _processNames)
        {
            var process = Process.GetProcessesByName(processName).FirstOrDefault();
            if (process != null)
            {
                _activeProcess = process;
                return process;
            }
        }

        return null;
    }


    /// <summary>
    /// Waits for exit.
    /// </summary>
    private  async void  WaitForExit()
    {
        await Task.Run(() =>
        {
            try
            {
                var token = _tokenSource.Token;

                if (token.IsCancellationRequested)
                {
                    return;
                }

                var process = GetProcess();
                while (process != null)
                {
                    process.WaitForExit(WaitingTime);
                    process = GetProcess();
                }

            }
            catch
            {

            }

            OnExit();
            ProcessClosed?.Invoke(this, EventArgs.Empty);
        });
    }

    private  int WaitForWindowHandle()
    {
        Process currentProcess; 

        try
        {
            do
            {
                var process = GetProcess();
                Thread.Sleep(200);
                currentProcess = process ?? throw new InvalidOperationException();
            }
            while (currentProcess.MainWindowHandle == IntPtr.Zero);

            _processId = currentProcess.Id;
        }
        catch { 
        
            _processId = WaitForWindowHandle();
        }

        return _processId;  
    }

    #endregion


}
