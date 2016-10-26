using System;
using System.Diagnostics;

namespace Caliburn.Micro.Logging
{
	internal class TraceLog : LogBase
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="TraceLog"/> class.
		/// </summary>
		/// <param name="type">The type.</param>
		public TraceLog(Type type)
			: base(type)
		{
		}

		/// <summary>
		/// Logs the exception.
		/// </summary>
		/// <param name="exception">The exception.</param>
		public override void Error(Exception exception)
		{
			Trace.WriteLine(CreateLogMessage("Exception = {0}", exception), ErrorCategory);
		}

		/// <summary>
		/// Logs the message as error.
		/// </summary>
		/// <param name="format">The format.</param>
		/// <param name="args">The args.</param>
		public override void Error(string format, params object[] args)
		{
			Trace.WriteLine(CreateLogMessage(format, args), ErrorCategory);
		}

		/// <summary>
		/// Logs the exception, with the additional message.
		/// </summary>
		/// <param name="exception">The exception.</param>
		/// <param name="format">The format.</param>
		/// <param name="args">The args.</param>
		public override void Error(Exception exception, string format, params object[] args)
		{
			string customMessage = CreateLogMessage(format, args);
			Trace.WriteLine(string.Format(@"{0}{1}Exception = {2}", customMessage, Environment.NewLine, exception), ErrorCategory);
		}

		/// <summary>
		/// Logs the message as info.
		/// </summary>
		/// <param name="format">A formatted message.</param><param name="args">Parameters to be injected into the formatted message.</param>
		public override void Info(string format, params object[] args)
		{
			Trace.WriteLine(CreateLogMessage(format, args), InfoCategory);
		}

		/// <summary>
		/// Logs the message as a warning.
		/// </summary>
		/// <param name="format">A formatted message.</param><param name="args">Parameters to be injected into the formatted message.</param>
		public override void Warn(string format, params object[] args)
		{
			Trace.WriteLine(CreateLogMessage(format, args), WarnCategory);
		}
	}
}