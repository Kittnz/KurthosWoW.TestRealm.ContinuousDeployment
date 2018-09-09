using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;

namespace KurthosWoW
{
	public sealed class DeployedProcessManager
	{
		private string ProcessPath { get; }

		public Process DeployedProcess { get; private set; }

		private Process _compilationTaskProcess;

		/// <summary>
		/// The process responsible for compilation.
		/// (May be null)
		/// </summary>
		public Process CompilationTaskProcess
		{
			get
			{
				lock(SyncObj)
					return _compilationTaskProcess;
			}
			set
			{
				lock(SyncObj)
				{
					//We don't care about null or initialization multiple times
					if(value == null)
						return;

					if(CompilationTaskProcess != null)
						if(CompilationTaskProcess.Id == value.Id)
							return;

					_compilationTaskProcess = value;

					//We do care when it's new, because we need to add an event listener to it.
					_compilationTaskProcess.Exited += (sender, args) => StartProcess();
				}
					
			}
			
		}

		/// <summary>
		/// Syncronization object.
		/// </summary>
		public readonly object SyncObj = new object();

		public DeployedProcessManager(string processPath)
		{
			ProcessPath = processPath ?? throw new ArgumentNullException(nameof(processPath));
		}

		public bool IsRunning => DetermineRunningStatus();

		public bool IsCompiling => DetermineCompilingStatus();

		//TODO: Consolidate this.
		private bool DetermineCompilingStatus()
		{
			lock(SyncObj)
				return CompilationTaskProcess != null && !CompilationTaskProcess.HasExited;
		}

		private bool DetermineRunningStatus()
		{
			lock(SyncObj)
				return DeployedProcess != null && !DeployedProcess.HasExited;
		}

		private void ShutdownProcess()
		{
			lock(SyncObj)
				DeployedProcess.Kill();
		}

		public bool StartProcess()
		{
			if(IsCompiling)
				return false;

			//TODO: What should we do if it is already running?
			lock(SyncObj)
			{
				//double check locking
				if(IsCompiling)
					return false;

				if(IsRunning)
					return false;

				DeployedProcess?.Dispose();

				ProcessStartInfo startInfo = new ProcessStartInfo(ProcessPath);
				startInfo.UseShellExecute = false;
				startInfo.CreateNoWindow = false;
				startInfo.WorkingDirectory = Path.GetDirectoryName(ProcessPath);
				DeployedProcess = new Process(){ StartInfo = startInfo};
				DeployedProcess.EnableRaisingEvents = true;

				//By default we should restart if it exits.
				DeployedProcess.Exited += (sender, args) => StartProcess();

				return DeployedProcess.Start();
			}
		}
	}
}
