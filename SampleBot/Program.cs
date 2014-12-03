
using Kaldi;
using Kaldi.KaldiToolkit;
using OpenMetaverse;
using System;
using System.Collections.Generic;
using System.Collections;
using System.Threading;
using System.Reflection;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Timers;
using System.Reflection;
using log4net;
using log4net.Config;

namespace SampleBot
{	
	class DemoMethodType {
		public string methodName;
		public string[] paras;
	}
	class Program
	{
		private static readonly ILog Log = LogManager.GetLogger (typeof(Program));
		private static readonly GridClient OpenMetaverseClient = new GridClient ();
		private static readonly FliteClient FliteClient = new FliteClient ("/usr/bin/flite");
		private static readonly List<string> FliteVoiceNames = new List<string> (new string[] {
			"awb",
			"rms",
			"slt",
			"kal16"
		});
		private static int LastVoiceIndex = 0;
		private static readonly Dictionary<UUID, string> FliteVoicesByID = new Dictionary<UUID, string> ();
		private static readonly string UserAgent = "RichInteractionBot";
		private static readonly string UserVersion = "1.0";
		private static readonly string FirstName = "Friend";
		private static readonly string LastName = "Bot";
		private static readonly string Password = "alive";
		private static readonly string StartLocation = NetworkManager.StartLocation ("Master", 128, 128, 25);
		private static readonly Client KaldiClient = new Client ("localhost", 9999);
		private static readonly System.Timers.Timer ASRTimer = new System.Timers.Timer (1000);
		private static readonly IList<Primitive> objects = new List<Primitive> ();
		private static Hashtable keyWordsDict = new Hashtable ();
		private static Hashtable keyWordToCmdMap = new Hashtable ();

		public static void Main (string[] args) {
			LoadCmdDicts ("/Users/cruan/Downloads/18781/project/cmd_transcription");
			sayName (null);
			XmlConfigurator.Configure (new System.IO.FileInfo ("SampleBot.exe.config"));

			OpenMetaverseClient.Settings.LOGIN_SERVER = "http://192.168.56.101:9000";

			//OpenMetaverseClient.Network.OnConnected += new NetworkManager.ConnectedCallback(Network_OnConnected);
			OpenMetaverseClient.Network.LoginProgress += Network_OnConnected;

			//OpenMetaverseClient.Self.OnChat += new AgentManager.ChatCallback(Self_OnChat);
			OpenMetaverseClient.Self.ChatFromSimulator += Self_OnChat;

			OpenMetaverseClient.Objects.ObjectProperties += new EventHandler<ObjectPropertiesEventArgs> (Objects_OnObjectProperties);
			OpenMetaverseClient.Objects.TerseObjectUpdate += new EventHandler<TerseObjectUpdateEventArgs> (Objects_OnNewPrim);

			if (OpenMetaverseClient.Network.Login (FirstName, LastName, Password, UserAgent, StartLocation, UserVersion)) {
				Log.Info ("Connected successfully.");
			} else {
				Log.Fatal ("Unable to connect to grid: " + OpenMetaverseClient.Network.LoginMessage);
				Environment.Exit (1);
			}

		}

		private static void LoadCmdDicts(string dir) {
			string path = dir + "/valid_cmds_dict.txt";
			string[] words = System.IO.File.ReadAllLines (path);
			for (int i = 0; i < words.Length; i++) {
				keyWordsDict.Add(words[i].Replace("\n",""), 0);
			}

			path = dir + "/valid_cmds_filtered_demo.txt";
			string[] cmd_keywords = System.IO.File.ReadAllLines (path);
			path = dir + "/valid_cmds_funcs_demo.txt";
			string[] cmds = System.IO.File.ReadAllLines (path);
			for (int i = 0; i < cmd_keywords.Length; i++) {
				keyWordToCmdMap.Add(cmd_keywords[i], cmds[i]);
			}
		}

		private static string FilterCmd(List<String[]> wordList) {
			string cmdFiltered = "";
			Boolean bFirstWord = true;
			foreach(string[] words in wordList) {
				if (keyWordsDict.ContainsKey(words[2])) {
					if (bFirstWord) {
						cmdFiltered += words [2];
						bFirstWord = false;
					} else {
						cmdFiltered += " ";
						cmdFiltered += words [2];
					}
				}
			}
			return cmdFiltered;
		}

		private static DemoMethodType AnalysisFunctionPrototype (string funcStr) {
			string[] strSplit = funcStr.Split (' ');
			DemoMethodType method = new DemoMethodType ();
			method.methodName = strSplit [0];
			method.paras = new string[strSplit.Length-1];
			for (int i = 1; i < strSplit.Length; i++) {
				method.paras [i - 1] = strSplit [i];
			}
			return method;
		}

		private static void WriteToChat (string text) {
			OpenMetaverseClient.Self.Chat (text, 0, ChatType.Normal);
			Speak (text, "awb");
		}

		private static void Speak (string text, string voice)
		{
			ASRTimer.Stop ();
			FliteClient.Speak (text, voice);

			// flush recognized speech (twice) for next 2 seconds
			/*for (int i = 0; i < 2; i++) {
				System.Threading.Thread.Sleep(1000);
				KaldiClient.Send ("dummyMessage");
				KaldiClient.Receive ();
			}		*/	
			ASRTimer.Start ();
		}

		static void Network_OnConnected (object sender, LoginProgressEventArgs e)
		{
			if (e.Status != LoginStatus.Success)
				return;

			WriteToChat ("Hey there! Welcome to my world! Ask me something!");

			ASRTimer.Elapsed += new ElapsedEventHandler (OnASREvent);
			ASRTimer.Enabled = true;

			getObjects (); // why does execution not get here?
		}
		//static void Self_OnChat(string message, ChatAudibleLevel audible, ChatType type, ChatSourceType sourceType, string fromName, UUID id, UUID ownerid, Vector3 position)
		static void Self_OnChat (object sender, ChatEventArgs e)
		{
			UUID id = e.SourceID;

			if (id == OpenMetaverseClient.Self.AgentID)
				return;

			System.Console.WriteLine (e.Message);

			if (e.Message == "Dog laugh") {
				OpenMetaverseClient.Self.AnimationStart (new UUID ("18b3a4b5-b463-bd48-e4b6-71eaac76c515"), false);
				WriteToChat ("ha ha ha HAHAHA!");
				Thread.Sleep (5000);
				OpenMetaverseClient.Self.AnimationStop (new UUID ("18b3a4b5-b463-bd48-e4b6-71eaac76c515"), false);
			}

		}

		private static string ChooseNextVoiceName ()
		{
			return FliteVoiceNames [++LastVoiceIndex % FliteVoiceNames.Count];
		}
		//static void Objects_OnNewPrim(Simulator simulator, Primitive primd, ulong regionHandle, ushort timeDilation)
		static void Objects_OnNewPrim (object sender, TerseObjectUpdateEventArgs e)
		{
			lock (objects) {
				Primitive primd = e.Prim;
				objects.Add (primd);
			}
		}

		private static void getObjects ()
		{
			float radius = 20;

			objects.Clear (); // forget what we know; object may have been deleted

			Vector3 location = OpenMetaverseClient.Self.SimPosition;
			//bool flag;

			List<Primitive> prims = OpenMetaverseClient.Network.CurrentSim.ObjectsPrimitives.FindAll (
				delegate(Primitive prim) {
					Vector3 pos = prim.Position;

					return ((prim.ParentID == 0) && (pos != Vector3.Zero) && (Vector3.Distance (pos, location) < radius));
				});

			// *** request properties of (only) these objects ***
			RequestObjectProperties (prims, 500, true);

			foreach (Primitive p in prims)
				objects.Add (p);
			//Console.Out.WriteLine("Properties completed: " + complete);
		}
		// Request Object properties
		// if synchronous == false, the msPerRequest is not needed
		// and it returns immediately, letting event handlers deal
		// with the results
		private static bool RequestObjectProperties (List<Primitive> objects, int msPerRequest, bool synchronous)
		{
			// Create an array of the local IDs of all the prims we are requesting properties for
			uint[] localids = new uint[objects.Count];

			lock (PrimsWaiting) {
				PrimsWaiting.Clear ();

				for (int i = 0; i < objects.Count; ++i) {
					localids [i] = objects [i].LocalID;
					PrimsWaiting.Add (objects [i].ID, objects [i]);
				}
			}

			OpenMetaverseClient.Objects.SelectObjects (OpenMetaverseClient.Network.CurrentSim, localids);

			if (synchronous)
				return AllPropertiesReceived.WaitOne (2000 + msPerRequest * objects.Count, false);
			else
				return true;
		}
		// Callback for ObjectProperties request received
		static Dictionary<UUID, Primitive> PrimsWaiting = new Dictionary<UUID, Primitive> ();
		static AutoResetEvent AllPropertiesReceived = new AutoResetEvent (false);

		static void Objects_OnObjectProperties (object sender, ObjectPropertiesEventArgs e)
		{
			lock (PrimsWaiting) {
				Primitive prim;
				if (PrimsWaiting.TryGetValue (e.Properties.ObjectID, out prim)) {
					prim.Properties = e.Properties;
				}
				PrimsWaiting.Remove (e.Properties.ObjectID);
				if (PrimsWaiting.Count == 0)
					AllPropertiesReceived.Set ();
			}
		}

		static private void OnASREvent (object source, ElapsedEventArgs e) {
			ASRTimer.Stop ();
			String[] locations = new String[3] { "nearest", "closest", "farthest" };
			KaldiClient.Send ("ASREvent speech request");
			String replyString = KaldiClient.Receive (); 

			System.Console.WriteLine (replyString);
			if (!replyString.Equals ("---NO SPEECH---")) {
				String[] reply = replyString.Split ('\t'); //string, parse, dependencies
				List<String[]> dep = new List<String[]> ();
				//[['advmod', 'is', 'where'], ['root', 'ROOT', 'is'], ['det', 'tree', 'the'], ['amod', 'tree', 'nearest'], ['nsubj', 'is', 'tree']]
				String outer = reply [2].Substring (1, reply [2].Length - 2);
				String[] outerList = outer.Split (new String[] { "], [" }, StringSplitOptions.None);
				outerList [0] = outerList [0].Substring (1);
				outerList [outerList.Length - 1] = outerList [outerList.Length - 1].Substring (0, outerList [outerList.Length - 1].Length - 1);
				// remove nonsense characters
				foreach (String s in outerList) {
					String[] inner = s.Split (',');
					for (int i = 0; i < inner.Length; i++) {
						inner [i] = inner [i].Replace ("'", ""); // remove " ' "
						inner [i] = inner [i].Replace (" ", ""); // remove space before each word
					}
					dep.Add (inner);
				}
				String cmdFiltered = FilterCmd(dep);
				if (keyWordToCmdMap.ContainsKey(cmdFiltered)) {
					string funcStr = keyWordToCmdMap [cmdFiltered].ToString();
					DemoMethodType methodInfo = AnalysisFunctionPrototype (funcStr);

					Type type = typeof(Program);
					string methodName = methodInfo.methodName;
					string[] paras = methodInfo.paras;
					MethodInfo info = type.GetMethod(methodName);
					info.Invoke(null, new object[]{paras});
				}
			} else {
				System.Console.WriteLine ("NO SPEECH");
			}
			ASRTimer.Start ();
		}

		static public void sitDown(string[] paras) {
			OpenMetaverseClient.Self.SitOnGround ();
		}

		static public void standUp(string[] paras) {
			OpenMetaverseClient.Self.Stand ();
		}

		static public void superman(string[] paras) {
			OpenMetaverseClient.Self.AnimationStart (Animations.FLY, false);
			WriteToChat ("go go Go!");
			Thread.Sleep (5000);
			OpenMetaverseClient.Self.AnimationStop (Animations.FLY, false);
		}

		static public void jump(string[] paras) {
			OpenMetaverseClient.Self.AnimationStart (Animations.JUMP_FOR_JOY, false);
			WriteToChat ("Oh Yeah");
			Thread.Sleep (5000);
			OpenMetaverseClient.Self.AnimationStop (Animations.JUMP_FOR_JOY, false);
		}

		static public void sayName(string[] paras) {
			WriteToChat ("My Name is wa ha ha!");
		}

		static public void sayAge(string[] paras) {
			WriteToChat ("It's a secret");
		}

		static public void backflip(string[] paras) {
			OpenMetaverseClient.Self.AnimationStart (Animations.BACKFLIP, false);
			WriteToChat ("Oh Yeah");
			Thread.Sleep (5000);
			OpenMetaverseClient.Self.AnimationStop (Animations.BACKFLIP, false);
		}

		private static int danceId = 0;
		static public void dance(string[] paras) {
			danceId = danceId % 8 + 1;
			switch (danceId) {
				case 1:
					OpenMetaverseClient.Self.AnimationStart (Animations.DANCE1, false);
					WriteToChat ("Oh Yeah");
					Thread.Sleep (5000);
					OpenMetaverseClient.Self.AnimationStop (Animations.DANCE1, false);
					break;
				case 2:
					OpenMetaverseClient.Self.AnimationStart (Animations.DANCE2, false);
					WriteToChat ("Oh Yeah");
					Thread.Sleep (5000);
					OpenMetaverseClient.Self.AnimationStop (Animations.DANCE2, false);
					break;
				case 3:
					OpenMetaverseClient.Self.AnimationStart (Animations.DANCE3, false);
					WriteToChat ("Oh Yeah");
					Thread.Sleep (5000);
					OpenMetaverseClient.Self.AnimationStop (Animations.DANCE3, false);
					break;
				case 4:
					OpenMetaverseClient.Self.AnimationStart (Animations.DANCE4, false);
					WriteToChat ("Oh Yeah");
					Thread.Sleep (5000);
					OpenMetaverseClient.Self.AnimationStop (Animations.DANCE4, false);
					break;
				case 5:
					OpenMetaverseClient.Self.AnimationStart (Animations.DANCE5, false);
					WriteToChat ("Oh Yeah");
					Thread.Sleep (5000);
					OpenMetaverseClient.Self.AnimationStop (Animations.DANCE5, false);
					break;
				case 6:
					OpenMetaverseClient.Self.AnimationStart (Animations.DANCE6, false);
					WriteToChat ("Oh Yeah");
					Thread.Sleep (5000);
					OpenMetaverseClient.Self.AnimationStop (Animations.DANCE6, false);
					break;
				case 7:
					OpenMetaverseClient.Self.AnimationStart (Animations.DANCE7, false);
					WriteToChat ("Oh Yeah");
					Thread.Sleep (5000);
					OpenMetaverseClient.Self.AnimationStop (Animations.DANCE7, false);
					break;
				case 8:
					OpenMetaverseClient.Self.AnimationStart (Animations.DANCE8, false);
					WriteToChat ("Oh Yeah");
					Thread.Sleep (5000);
					OpenMetaverseClient.Self.AnimationStop (Animations.DANCE8, false);
					break;
				default:
					break;
			}
		}

		static public void moveObjectToLocation(string[] paras) {
			return;
		}

		static private double getDistance(Vector3 v1, Vector3 v2) {
			double distance = Math.Sqrt (Math.Pow (v1.X - v2.X, 2.0) +
				Math.Pow (v1.Y - v2.Y, 2.0) +
				Math.Pow (v1.Z - v2.Z, 2.0));
			return distance;
		}
		// answer the distance of nearest object
		static private Primitive getNearestObject(string objectName) {
			Vector3 botPosition = OpenMetaverseClient.Self.SimPosition;
			Vector3 objectPosition;
			Primitive nearestObject = null;
			double minDistance = Double.MaxValue;
			lock (objects) {
				foreach (Primitive worldObject in objects) {
					string name;
					switch (worldObject.PrimData.PCode) {
					case PCode.Prim:
						name = worldObject.Properties.Name.ToString ();
						break;
					default:
						name = worldObject.PrimData.PCode.ToString ();
						break;
					}
					name = name.ToLower ();
					if (name.Contains (objectName)) {
						objectPosition = worldObject.Position;
						double distance = getDistance (botPosition, objectPosition);
						if (distance < minDistance) {
							minDistance = distance;
							nearestObject = worldObject;
						}
					}
				}
			}
			if (nearestObject == null) {
				lock (objects) {
					foreach (Primitive worldObject in objects) {
						string type;
						switch (worldObject.PrimData.PCode) {
						case PCode.Prim:
							type = worldObject.Type.ToString ();
							break;
						default:
							type = worldObject.PrimData.PCode.ToString ();
							break;
						}
						type = type.ToLower ();
						if (type == objectName) {
							objectPosition = worldObject.Position;
							double distance = getDistance (botPosition, objectPosition);
							if (distance < minDistance) {
								minDistance = distance;
								nearestObject = worldObject;
							}
						}
					}
				}
			}
			return nearestObject;
		}

		// say the location of nearest object
		static public void answerLocation(string[] paras) {
			string objectName = paras [0];
			getObjects ();
			Primitive targetobj = getNearestObject (objectName);
			string chatText;
			if (targetobj == null) {
				chatText = String.Format ("I can't find {0} around here.", objectName);
			} else {
				double distance = getDistance (OpenMetaverseClient.Self.SimPosition, targetobj.Position);
				StringBuilder chatBuilder = new StringBuilder ("The nearest ");
				chatBuilder.Append (objectName);
				chatBuilder.Append (" from me is ").Append (String.Format ("{0:0.##}", distance)).Append (" meters away.");
				chatText = chatBuilder.ToString ();
			}
			WriteToChat (chatText);
		}


	}
}