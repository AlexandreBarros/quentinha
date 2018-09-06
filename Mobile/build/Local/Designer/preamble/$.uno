using Uno;
using Uno.Collections;
using Uno.UX;
using Uno.IO;
using Outracks.Simulator;
using Outracks.Simulator.Bytecode;
using Outracks.Simulator.Runtime;
using Outracks.Simulator.Client;
namespace Outracks.Simulator 
{ 
	public class GeneratedApplication : Outracks.Simulator.Client.Application
	{
		public GeneratedApplication()
			: base(
				new [] 
				{new Uno.Net.IPEndPoint(Uno.Net.IPAddress.Parse("127.0.0.1"), 12124), new Uno.Net.IPEndPoint(Uno.Net.IPAddress.Parse("169.254.80.80"), 12124), new Uno.Net.IPEndPoint(Uno.Net.IPAddress.Parse("192.168.8.17"), 12124), new Uno.Net.IPEndPoint(Uno.Net.IPAddress.Parse("192.168.1.9"), 12124), new Uno.Net.IPEndPoint(Uno.Net.IPAddress.Parse("10.0.75.1"), 12124)},"E:\\Projetos\\Quentinha-Carioca\\Mobile\\Mobile.unoproj",new string[] 
				{ })
		{
			Runtime.Bundle.Initialize("Mobile");

			if defined(DotNet)
				Reflection = new DotNetReflectionWrapper(DotNetReflection.Load("E:/Projetos/Quentinha-Carioca/Mobile/build/Local/Designer"));
			if defined(CPLUSPLUS)
				Reflection = new NativeReflection(new SimpleTypeMap());
		}
	}
}