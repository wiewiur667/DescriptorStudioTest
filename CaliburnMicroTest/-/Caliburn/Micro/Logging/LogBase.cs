using System;

namespace Caliburn.Micro.Logging
{
	internal abstract class LogBase : ILog
	{
		protected const string ErrorCategory = "ERROR";
		protected const string InfoCategory = "INFO";
		protected const string WarnCategory = "WARN";

		private readonly Type _type;

		private string _dateTimeFormat = "o";

		/// <summary>
		/// Initializes a new instance of the <see cref="LogBase"/> class.
		/// </summary>
		/// <param name="type">The type.</param>
		protected LogBase(Type type)
		{
			_type = type;
		}

		public string DateTimeFormat
		{
			get { return _dateTimeFormat; }
			set { _dateTimeFormat = value; }
		}

		protected Type Type
		{
			get { return _type; }
		}

		/// <summary>
		/// Logs the exception.
		/// </summary>
		/// <param name="exception">The exception.</param>
		public abstract void Error(Exception exception);

		/// <summary>
		/// Logs the message as error.
		/// </summary>
		/// <param name="format">The format.</param>
		/// <param name="args">The args.</param>
		public abstract void Error(string format, params object[] args);

		/// <summary>
		/// Logs the exception, with the additional message.
		/// </summary>
		/// <param name="exception">The exception.</param>
		/// <param name="format">The format.</param>
		/// <param name="args">The args.</param>
		public abstract void Error(Exception exception, string format, params object[] args);

		/// <summary>
		/// Logs the message as info.
		/// </summary>
		/// <param name="format">A formatted message.</param><param name="args">Parameters to be injected into the formatted message.</param>
		public abstract void Info(string format, params object[] args);

		/// <summary>
		/// Logs the message as a warning.
		/// </summary>
		/// <param name="format">A formatted message.</param><param name="args">Parameters to be injected into the formatted message.</param>
		public abstract void Warn(string format, params object[] args);

		protected string CreateLogMessage(string format, params object[] args)
		{
			return string.Format("[{0}] {1}", DateTime.Now.ToString(_dateTimeFormat), string.Format(format, args));
		}
	}
}