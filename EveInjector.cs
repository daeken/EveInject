using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Runtime.Remoting;
using EasyHook;

class EveInjector {
	public static void Main(string[] args) {
		new EveInjector().Attach("exefile", args[0]);
	}
	
	EveInjector() {
		Config.Register(
				"Eve injector", 
				"Obj/EveInjector.exe", 
				"Obj/EIInject.dll"
			);
	}
	
	void Attach(string procname, string fn) {
		procname = procname.ToLower();
		Process process = null;
		foreach(Process proc in Process.GetProcesses()) {
			if(procname == proc.ProcessName.ToLower()) {
				process = proc;
				break;
			}
		}
		
		StreamReader sr = new StreamReader(File.OpenRead(fn));
		string code = sr.ReadToEnd();
		
		RemoteHooking.Inject(
				process.Id, 
				"Obj/EIInject.dll", 
				"Obj/EIInject.dll", 
				code
			);
	}
}
