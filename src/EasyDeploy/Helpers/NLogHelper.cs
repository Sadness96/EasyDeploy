﻿using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;

namespace EasyDeploy.Helpers
{
    /// <summary>
    /// NLog 帮助类
    /// </summary>
    public static class NLogHelper
    {
        private readonly static ILogger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// 保存调试日志
        /// </summary>
        /// <param name="message">消息</param>
        /// <param name="memberName">堆栈信息</param>
        /// <param name="sourceFilePath">堆栈信息</param>
        /// <param name="sourceLineNumber">堆栈信息</param>
        public static void SaveDebug(string message,
        [CallerMemberName] string memberName = "",
        [CallerFilePath] string sourceFilePath = "",
        [CallerLineNumber] int sourceLineNumber = 0)
        {
            logger.Debug($"[{Path.GetFileName(sourceFilePath)}][{memberName}] {message}");
            Console.WriteLine($"{DateTime.Now} | logDebug | {message}");
        }

        /// <summary>
        /// 保存信息日志
        /// </summary>
        /// <param name="message">消息</param>
        /// <param name="memberName">堆栈信息</param>
        /// <param name="sourceFilePath">堆栈信息</param>
        /// <param name="sourceLineNumber">堆栈信息</param>
        public static void SaveInfo(string message,
        [CallerMemberName] string memberName = "",
        [CallerFilePath] string sourceFilePath = "",
        [CallerLineNumber] int sourceLineNumber = 0)
        {
            logger.Info($"[{Path.GetFileName(sourceFilePath)}][{memberName}] {message}");
            Console.WriteLine($"{DateTime.Now} | logInfo | {message}");
        }

        /// <summary>
        /// 保存错误日志
        /// </summary>
        /// <param name="message">消息</param>
        /// <param name="memberName">堆栈信息</param>
        /// <param name="sourceFilePath">堆栈信息</param>
        /// <param name="sourceLineNumber">堆栈信息</param>
        public static void SaveError(string message,
        [CallerMemberName] string memberName = "",
        [CallerFilePath] string sourceFilePath = "",
        [CallerLineNumber] int sourceLineNumber = 0)
        {
            logger.Error($"[{Path.GetFileName(sourceFilePath)}][{memberName}] {message}");
            Console.WriteLine($"{DateTime.Now} | logError | {message}");
        }

        /// <summary>
        /// 保存痕迹日志
        /// </summary>
        /// <param name="message">消息</param>
        /// <param name="memberName">堆栈信息</param>
        /// <param name="sourceFilePath">堆栈信息</param>
        /// <param name="sourceLineNumber">堆栈信息</param>
        public static void SaveTrace(string message,
        [CallerMemberName] string memberName = "",
        [CallerFilePath] string sourceFilePath = "",
        [CallerLineNumber] int sourceLineNumber = 0)
        {
            logger.Trace($"[{Path.GetFileName(sourceFilePath)}][{memberName}] {message}");
            Console.WriteLine($"{DateTime.Now} | logTrace | {message}");
        }
    }
}
