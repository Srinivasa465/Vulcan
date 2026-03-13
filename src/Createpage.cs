using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Conditions;
using FlaUI.Core.Input;
using FlaUI.UIA3;
using Flit;

namespace Demo {
   [TestFixture (2,"Createpage")]
   #region createpage------------------------------------------------------------------------------
   public class Createpage {
      #region method-------------------------------------------------
      [FixtureInitialize]
      public void C001 () {
         Array.ForEach (Process.GetProcessesByName ("Vulcan"), x => x?.Kill ());
         var procInfo = new ProcessStartInfo {
            FileName = @"C:\Program Files\Metamation\Vulcan\Vulcan.exe",
            WorkingDirectory = $@"C:\Program Files\Metamation\Vulcan\Vulcan.exe".Replace ("Vulcan.exe", "")
         };
         Process.Start (procInfo);
         Thread.Sleep (TimeSpan.FromSeconds (8));
         var uia3 = new UIA3Automation ();
         win = uia3.GetDesktop ().FindFirstDescendant (x => x.ByAutomationId ("HomePage")).AsWindow ()!; // Home window
         ConditionFactory cf = new ConditionFactory (uia3.PropertyLibrary);
      }

      /// <summary>job creation</summary>
      [Test (02, "createjob")]
      public static void C002 () {
         var uia3 = new UIA3Automation ();
         var window = uia3.GetDesktop ().FindFirstDescendant (x => x.ByAutomationId ("HomePage")).AsWindow ();
         window.FindFirstDescendant (x => x.ByName ("Create"))!.Click ();
         window.FindFirstDescendant (x => x.ByAutomationId ("SearchTB"))!.Click ();
         Keyboard.Type ("circle");
         Point searchbtn = new (906, 25);
         Mouse.Click (searchbtn);
         Point createjob = new Point (1228, 90);
         Mouse.Click (createjob);
         Thread.Sleep (300);
         Point Quantity = new Point (466, 320);
         Mouse.Click (Quantity);
         Keyboard.Type ("20");
         window.FindFirstDescendant (x => x.ByAutomationId ("GrainCtrl")).AsComboBox ().Select ("Vertical")!.Click ();
         window.FindFirstDescendant (x => x.ByAutomationId ("RotationCtrl")).AsComboBox ().Select ("90°")!.Click ();
         window.FindFirstDescendant (x => x.ByName ("Configuration")).AsButton ().Click ();
         window.FindFirstDescendant (x => x.ByAutomationId ("NameCtrl")).AsComboBox ().Select ("AL010MD0-O2H0-30-2")!.Click ();
         window.FindFirstDescendant (x => x.ByAutomationId ("MaterialCtrl")).AsComboBox ().Select ("ALMg3");
         window.FindFirstDescendant (x => x.ByAutomationId ("ThicknessCtrl")).AsComboBox ().Select ("2");
         window.FindFirstDescendant (x => x.ByAutomationId ("GasTypeCtrl")).AsComboBox ().Select ("N2");
         var win = window.FindFirstDescendant (x => x.ByAutomationId ("WndJobSettings")).AsWindow ();
         win.FindFirstDescendant (x => x.ByName ("Layouts"))!.AsTabItem ().DoubleClick ();
         Thread.Sleep (1200);
         win.FindFirstDescendant (x => x.ByName ("save layouts"))!.Click ();
         Thread.Sleep (400);
         Keyboard.Type ("Sample2");
         Thread.Sleep (400);
         Mouse.Click (new Point (769, 554));
         Thread.Sleep (400);
         Mouse.Click (new Point (820, 580)); 
         Thread.Sleep (500);
         Mouse.Click (new Point (111, 56));
      }
      public static Window win;
   }
      #endregion
}
   #endregion