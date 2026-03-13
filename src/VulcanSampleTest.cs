
using FlaUI.Core.AutomationElements;
using FlaUI.UIA3;
using Flit;
using System.Diagnostics;

#region class VulcanTests -------------------------------------------------------------------------------
[TestFixture (5, "Vulcan test fixture")]
class VulcanTests {
   #region Initialization and cleanup -------------------------------
   [FixtureInitialize]
   public static void OpenVulcanApplication () => OpenVulcan ();
   #endregion

   #region Methods --------------------------------------------------
   /// <summary>Sample test 1.</summary>
   [Test (1001, "Open application and clear the demo prompt")]
   public void VulcanTest () {
      PromptClick ();
      Assert.IsNotNull (MainWindow, "Main window is null");
      CloseVulcan ();
      Assert.True (5 == 5);
   }
   #endregion

   #region Implementaion --------------------------------------------
   // Open Vulcan, if it is already open, close it and open again, then wait for 8 seconds to make sure Vulcan is ready for automation
   static void OpenVulcan () {
      Array.ForEach (Process.GetProcessesByName ("Vulcan"), x => x?.Kill ());
      var procInfo = new ProcessStartInfo {
         FileName = @"C:\Program Files\Metamation\Vulcan\Vulcan.exe",
         WorkingDirectory = $@"C:\Program Files\Metamation\Vulcan\Vulcan.exe".Replace ("Vulcan.exe", "")
      };
      Process.Start (procInfo);
      Thread.Sleep (TimeSpan.FromSeconds (8));
      // Find Vulcan main window and assign it to main window variable
      var uia3 = new UIA3Automation ();
      MainWindow = uia3.GetDesktop ().FindFirstDescendant (x => x.ByAutomationId ("HomePage")).AsWindow (); // Home window
   }

   // This method will click the demo prompt 
   static void PromptClick () {
      Thread.Sleep (3000);
      var btnDone = MainWindow!.FindFirstDescendant (x => x.ByAutomationId ("BtnYes"));
      btnDone.AsButton ()!.Click ();
      Thread.Sleep (500);
   }

   // close the application
   static void CloseVulcan () {
      MainWindow?.FindFirstDescendant (x => x.ByName ("Off"))?.AsButton ()!.Click ();
      MainWindow?.FindFirstDescendant (x => x.ByName ("Close Vulcan"))?.AsButton ()!.Click ();
      var vulcanProcess = Process.GetCurrentProcess ();
      if (!vulcanProcess.HasExited) vulcanProcess.Kill ();
   }
   #endregion

   #region Propertie ------------------------------------------------
   /// <summary>Main window of the Vulcan application</summary>
   public static Window? MainWindow;
   #endregion
}
#endregion