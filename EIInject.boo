namespace EIInject

import System
import System.Runtime.InteropServices
import EasyHook

class EIInject(EasyHook.IEntryPoint):
	def constructor(context as RemoteHooking.IContext, code as string):
		pass
	
	def Run(context as RemoteHooking.IContext, code as string):
		Py_Initialize()
		
		PyRun_SimpleString(code)
		
		RemoteHooking.WakeUpProcess()
	
	[DllImport(
			'bin\\python25.dll', 
			CallingConvention: CallingConvention.Cdecl
		)]
	static def Py_Initialize() as void:
		pass
	
	[DllImport(
			'bin\\python25.dll', 
			CallingConvention: CallingConvention.Cdecl, 
			CharSet: CharSet.Ansi
		)]
	static def PyRun_SimpleString(code as string) as int:
		pass
