﻿using CliWrap;
using CliWrap.EventStream;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;

namespace EasyDeploy.Helpers
{
    /// <summary>
    /// 命令行交互帮助类
    /// </summary>
    public class CliWrapHelper
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="workingDirectory">工作目录</param>
        /// <param name="applicationName">应用名称</param>
        /// <param name="withArguments">参数</param>
        public CliWrapHelper(string workingDirectory, string applicationName, string[] withArguments = null)
        {
            _workingDirectory = workingDirectory;
            _applicationName = applicationName;
            _withArguments = withArguments;
        }

        /// <summary>
        /// 工作目录
        /// </summary>
        private string _workingDirectory { get; set; }

        /// <summary>
        /// 应用名称
        /// </summary>
        private string _applicationName { get; set; }

        /// <summary>
        /// 参数
        /// </summary>
        private string[] _withArguments { get; set; }

        /// <summary>
        /// 命令行
        /// </summary>
        private Command _cmd { get; set; }

        public event Action<string> StartedCommandEvent;

        public event Action<string> StandardOutputCommandEvent;

        public event Action<string> StandardErrorCommandEvent;

        public event Action<string> ExitedCommandEvent;

        /// <summary>
        /// 启动
        /// </summary>
        public bool Start()
        {
            if (!string.IsNullOrEmpty(_applicationName))
            {
                _cmd = Cli.Wrap($"{_workingDirectory}{_applicationName}");
                if (!string.IsNullOrEmpty(_workingDirectory))
                {
                    _cmd = _cmd.WithWorkingDirectory(_workingDirectory);
                }
                if (_withArguments != null)
                {
                    _cmd = _cmd.WithArguments(_withArguments);
                }
                Task.Run(async () =>
                {
                    await foreach (var cmdEvent in _cmd.ListenAsync())
                    {
                        switch (cmdEvent)
                        {
                            case StartedCommandEvent started:
                                Console.WriteLine($"Process started; ID: {started.ProcessId}");
                                StartedCommandEvent?.Invoke($"{started.ProcessId}");
                                break;
                            case StandardOutputCommandEvent stdOut:
                                Console.WriteLine($"Out> {stdOut.Text}");
                                StandardOutputCommandEvent?.Invoke($"{stdOut.Text}");
                                break;
                            case StandardErrorCommandEvent stdErr:
                                Console.WriteLine($"Err> {stdErr.Text}");
                                StandardErrorCommandEvent?.Invoke($"{stdErr.Text}");
                                break;
                            case ExitedCommandEvent exited:
                                Console.WriteLine($"Process exited; Code: {exited.ExitCode}");
                                ExitedCommandEvent?.Invoke($"{exited.ExitCode}");
                                break;
                        }
                    }
                });
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 结束
        /// </summary>
        public void Stop()
        {

        }
    }
}
