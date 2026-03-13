using FlaUI.Core.AutomationElements;
using FlaUI.Core.Conditions;
using FlaUI.Core.Input;
using FlaUI.UIA3;
using Flit;
using System.Diagnostics;
using System.Drawing;
using System.Text.RegularExpressions;
using Capture = FlaUI.Core.Capturing.Capture;
using System.Drawing;
using System.Threading;

namespace Demo {

   [TestFixture (100, "Setuppage")]
   #region createpage------------------------------------------------------------------------------
   public class createpage {

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

      /// <summary>Homming button</summary>
      [Test (0001, "Homing button")]
      public void C002 () {
         Thread.Sleep (300);
         Point value = new Point (381, 696);
         Mouse.LeftClick (value);
         Keyboard.Type ("200");
         win.FindFirstDescendant (x => x.ByAutomationId ("BtnYStart"))!.Click ();
         win.FindFirstDescendant (x => x.ByName ("homing")).AsButton ()!.Click (); //"homing"
         Thread.Sleep (500);
         var homingWindow = win.Parent.FindFirstDescendant (x => x.ByAutomationId ("HomingDialog"));
         homingWindow.FindFirstDescendant (x => x.ByName ("Automatic")).AsButton ()!.Click ();
         homingWindow.FindFirstDescendant (x => x.ByName ("start")).AsButton ()!.Click ();
         Thread.Sleep (400);
         homingWindow.FindFirstDescendant (x => x.ByName ("Close"))!.Click ();
         Thread.Sleep (300);
      }

      /// <summary>Offeset/summary>
      [Test (0003, "work offset")]
      public void C003 () {
         win.FindFirstDescendant (x => x.ByName ("work offset")).AsButton ()!.Click ();
         Thread.Sleep (400);
         win.FindFirstDescendant (x => x.ByName ("Nozzle center"))!.Click ();
         Thread.Sleep (300);
         win.FindFirstDescendant (x => x.ByAutomationId ("BtnDone"))!.Click ();
         Thread.Sleep (300);
         var TickButton = win.FindFirstDescendant (x => x.ByAutomationId ("BtnYes"));
         TickButton.Click ();
      }

      /// <summary>Speed override</summary>
      [Test (0004, "Speed override")]
      public void C004 () {
         win.FindFirstDescendant (x => x.ByName ("speed override"))!.Click ();
         Point p = new Point (1148, 532);
         Mouse.LeftClick (p);
         Mouse.DragHorizontally (p, -50);
         Thread.Sleep (500);
         Point p2 = new Point (1106, 534);
         Mouse.LeftClick (p2);
         Mouse.DragHorizontally (p2, 40);
         win.Parent.FindFirstDescendant (x => x.ByAutomationId ("Close"))!.Click ();
         Thread.Sleep (500);
      }

      /// <summary>Speed</summary>
      [Test (0005, "Setiings")]
      public static void C005 () {
         win.FindFirstDescendant (x => x.ByName ("settings"))!.Click ();
         Point point = new Point (908, 635);
         Mouse.Click (point);
         Keyboard.Type ("15");
         Thread.Sleep (400);
         //win.FindFirstDescendant (x => x.ByName ("Close")).Click ();
      }

      /// <summary>Diagnostics setting</summary>
      [Test (0006, "Mainsettings")]
      public void C006 () {
         var diagnostics = win.FindFirstDescendant (x => x.ByAutomationId ("BtnDiagnostics"));
         diagnostics.Click ();
         Thread.Sleep (500);
         var homingWindow = win.Parent.FindFirstDescendant (x => x.ByAutomationId ("DiagnosticsWnd")).AsWindow ();
         var pfeild = homingWindow.FindFirstDescendant (x => x.ByName ("PField Parameter"));
         pfeild.Click ();
         Thread.Sleep (500);
         win.FindFirstDescendant (x => x.ByName ("Consecutive")).Click ();
         Thread.Sleep (500);
         win.FindFirstDescendant (x => x.ByName ("Close")).Click ();
         Thread.Sleep (400);
         win.FindFirstDescendant (x => x.ByAutomationId ("BtnDiagnostics")).Click ();
         Thread.Sleep (500);
         homingWindow.FindFirstDescendant (x => x.ByName ("I/O monitor"))!.Click ();
         Thread.Sleep (10000);
         win.FindFirstDescendant (x => x.ByName ("Close")).Click ();
         Thread.Sleep (500);
         win.FindFirstDescendant (x => x.ByAutomationId ("BtnDiagnostics")).Click ();
         Thread.Sleep (500);
         homingWindow.FindFirstDescendant (x => x.ByName ("Log"))!.Click ();
         Thread.Sleep (500);
         win.FindFirstDescendant (x => x.ByAutomationId ("BtnDone")).Click ();
         Thread.Sleep (500);
         win.FindFirstDescendant (x => x.ByAutomationId ("BtnDiagnostics")).Click ();
         Thread.Sleep (500);
         homingWindow.FindFirstDescendant (x => x.ByName ("License"))!.Click ();
         Thread.Sleep (500);
         win.FindFirstDescendant (x => x.ByAutomationId ("BtnDone")).Click ();
         Thread.Sleep (500);
         win.FindFirstDescendant (x => x.ByAutomationId ("BtnDiagnostics")).Click ();
         Thread.Sleep (500);
         homingWindow.FindFirstDescendant (x => x.ByName ("Oscillator data"))!.Click ();
         Thread.Sleep (400);
         win.FindFirstDescendant (x => x.ByAutomationId ("BtnYes")).Click ();
         Thread.Sleep (400);
         win.FindFirstDescendant (x => x.ByAutomationId ("BtnDiagnostics")).Click ();
         Thread.Sleep (500);
         homingWindow.FindFirstDescendant (x => x.ByName ("Load PLC"))!.Click ();
         Thread.Sleep (500);
         win.FindFirstDescendant (x => x.ByAutomationId ("BtnDone")).Click ();
         Thread.Sleep (500);
         win.FindFirstDescendant (x => x.ByAutomationId ("BtnYes")).Click ();
         Thread.Sleep (500);
         win.FindFirstDescendant (x => x.ByAutomationId ("BtnDiagnostics")).Click ();
         Thread.Sleep (500);
         homingWindow.FindFirstDescendant (x => x.ByName ("Save backup"))!.Click ();
         win.FindFirstDescendant (x => x.ByName ("Data"))!.Click ();
         win.FindFirstDescendant (x => x.ByName ("Log"))!.Click ();
         win.FindFirstDescendant (x => x.ByName ("Programs"))!.Click ();
         Thread.Sleep (500);
         win.FindFirstDescendant (x => x.ByAutomationId ("BtnDone")).Click ();
         Thread.Sleep (5000);
         win.FindFirstDescendant (x => x.ByAutomationId ("BtnYes")).Click ();
         Thread.Sleep (500);
         win.FindFirstDescendant (x => x.ByAutomationId ("BtnDiagnostics")).Click ();
         Thread.Sleep (500);
         homingWindow.FindFirstDescendant (x => x.ByName ("Load backup"))!.Click ();
         Thread.Sleep (400);
         win.FindFirstDescendant (x => x.ByName ("10.03.2026"))!.Click ();
         Thread.Sleep (500);
         win.FindFirstDescendant (x => x.ByName ("CUILib.FileOpenDlg+FileData"))!.Click ();
         Thread.Sleep (500);
         win.FindFirstDescendant (x => x.ByAutomationId ("BtnDone")).Click ();
         Thread.Sleep (500);
         win.FindFirstDescendant (x => x.ByAutomationId ("BtnYes")).Click ();
         Thread.Sleep (500);
      }

      /// <summary> Trumpflogo </summary>
      [Test (0007, "Trumpflogo")]
      public void C007 () {
         win.FindFirstDescendant (x => x.ByAutomationId ("ImgLogo")).Click ();
         Thread.Sleep (1000);
         win.FindFirstDescendant (x => x.ByAutomationId ("BtnDone")).Click ();
      }

      /// <summary>X,Y,Z jog</summary>
      [Test (0008, "x,Y,zjog")]
      public void C008 () {
         String[] Yup = ["YPosJogUpFast1", "YPosJogMedium2", "YPosJogUpSlow3"];
         foreach (var ymove in Yup) win.FindFirstDescendant (x => x.ByAutomationId (ymove))!.Click ();
         Thread.Sleep (400);
         String[] Ydown = ["YNegJogDownFast1", "YNegJogMedium2", "YNegJogDownSlow3"];
         foreach (var ydownmove in Ydown) win.FindFirstDescendant (x => x.ByAutomationId (ydownmove))!.Click ();
         Thread.Sleep (300);
         String[] Xupmove = ["XPosJogUpFast1", "XPosJogMedium2", "XPosJogUpSlow3"];
         foreach (var xumove in Xupmove) win.FindFirstDescendant (x => x.ByAutomationId (xumove))!.Click ();
         Thread.Sleep (300);
         String[] Xdownmove = ["XNegJogDownFast1", "XNegJogMedium2", "XNegJogDownSlow3"];
         foreach (var xdmove in Xdownmove) win.FindFirstDescendant (x => x.ByAutomationId (xdmove))!.Click ();
         Thread.Sleep (300);
         String[] zupmove = ["ZPosJogUpFast1", "ZPosJogMedium2", "ZPosJogUpSlow3"];
         foreach (var zumove in zupmove) win.FindFirstDescendant (x => x.ByAutomationId (zumove))!.Click ();
         Thread.Sleep (300);
         String[] zdownmove = ["ZNegJogDownFast1", "ZNegJogMedium2", "ZNegJogDownSlow3"];
         foreach (var zdmove in zdownmove) win.FindFirstDescendant (x => x.ByAutomationId (zdmove))!.Click ();
         Thread.Sleep (300);
         String[] Xuppmove = ["XPosJogUpFast1", "XPosJogMedium2", "XPosJogUpSlow3"];
         foreach (var xupmove in Xuppmove) win.FindFirstDescendant (x => x.ByAutomationId (xupmove))!.Click ();
         Thread.Sleep (300);
         win.FindFirstDescendant (x => x.ByName ("homing")).AsButton ()!.Click (); //"homing"
         Thread.Sleep (300);
         Point Xbtn = new Point (987, 330);
         Mouse.Click (Xbtn);
         Thread.Sleep (300);
         Point Start = new Point (1068, 457);
         Mouse.Click (Start);
         Thread.Sleep (300);
         String[] Yupp = ["YPosJogUpFast1", "YPosJogMedium2", "YPosJogUpSlow3"];
         foreach (var ypmove in Yupp) win.FindFirstDescendant (x => x.ByAutomationId (ypmove))!.Click ();
         Thread.Sleep (400);
         win.FindFirstDescendant (x => x.ByName ("homing")).AsButton ()!.Click (); //"homing"
         Point Ybtn = new Point (990, 362);
         Mouse.Click (Ybtn);
         Thread.Sleep (300);
         Mouse.Click (Start);
         String[] zuppmove = ["ZPosJogUpFast1", "ZPosJogMedium2", "ZPosJogUpSlow3"];
         foreach (var zpmove in zuppmove) win.FindFirstDescendant (x => x.ByAutomationId (zpmove))!.Click ();
         Thread.Sleep (300);
         win.FindFirstDescendant (x => x.ByName ("homing")).AsButton ()!.Click (); //"homing"
         Point zbtn = new Point (1002, 400);
         Mouse.Click (zbtn);
         Thread.Sleep (300);
         Mouse.Click (Start);
         Thread.Sleep (300);
         var homingWindow = win.Parent.FindFirstDescendant (x => x.ByAutomationId ("HomingDialog")).Parent;
         homingWindow.FindFirstDescendant (x => x.ByName ("Close"))!.Click ();
      }

      /// <summary>X,Y,Z axis movements</summary>
      [Test (150882, "X,Y,Z Axis movement")]
      public void C150882 () {
         win.FindFirstDescendant (x => x.ByName ("homing")).AsButton ()!.Click (); //"homing"
         Thread.Sleep (500);
         var homingWindow = win.Parent.FindFirstDescendant (x => x.ByAutomationId ("HomingDialog"));
         homingWindow.FindFirstDescendant (x => x.ByName ("Automatic")).AsButton ()!.Click ();
         Thread.Sleep (300);
         String[] start = ["start", "Close"];
         foreach (var stbtn in start) homingWindow.FindFirstDescendant (x => x.ByName (stbtn)).AsButton ()!.Click ();
         Thread.Sleep (400);
         string[] XYZ = { "NEditX", "BtnYStart", "NEditY", "BtnXStart", "NEditZ", "BtnZStart" };
         foreach (var xyz in XYZ) {
            var element = win.FindFirstDescendant (x => x.ByAutomationId (xyz));
            if (element != null) {
               element.Click ();
               Keyboard.Type ("200");
            }
            var equalsButton = win.FindFirstDescendant (x => x.ByAutomationId ("BtnNEditEquals"));
            Thread.Sleep (300);
            if (equalsButton != null) equalsButton.Click ();
         }
         win.FindFirstDescendant (x => x.ByName ("work offset")).AsButton ()!.Click ();
         Thread.Sleep (400);
         win.FindFirstDescendant (x => x.ByName ("Positioning diode"))!.Click ();
         Thread.Sleep (500);
         win.FindFirstDescendant (x => x.ByAutomationId ("BtnDone"))!.Click ();
         Thread.Sleep (500);
         win.FindFirstDescendant (x => x.ByAutomationId ("BtnYes")).Click ();
         Thread.Sleep (500);
         win.FindFirstDescendant (x => x.ByName ("Configure")).AsButton ()!.Click ();
         Thread.Sleep (400);
         win.FindFirstDescendant (x => x.ByName ("Work offsets")).AsButton ()!.Click ();
         Thread.Sleep (500);
         var expectedcapture = Capture.Rectangle (new Rectangle (7, 44, 1176, 117));
         expectedcapture.ToFile (@"C:\Work\Temp\S1currentvalue.png");
         Thread.Sleep (300);
         Bitmap actual = new Bitmap (@"C:\Work\S1actualvalue.png");
         Bitmap expected = new Bitmap (@"C:\Work\Temp\S1currentvalue.png");
         bool imagesAreSame = true;
         for (int y = 0; y < expected.Height; y++) {
            for (int x = 0; x < expected.Width; x++) {
               if (expected.GetPixel (x, y) != actual.GetPixel (x, y)) {
                  imagesAreSame = false;
                  break;
               }
            }
         }
         if (imagesAreSame)
            Console.WriteLine ("Screenshots match!");
         else
            Console.WriteLine ("Screenshots differ!");
         Thread.Sleep (300);
         Mouse.Click (new Point (1234, 968));
         Thread.Sleep (300);
         Mouse.Click (new Point (111, 56));
      }

      /// <summary> d</summary>
      [Test (9, "capture")]
      public void imagecampare () {
         win.FindFirstDescendant (x => x.ByName ("Configure")).AsButton ()!.Click ();
         Thread.Sleep (400);
         win.FindFirstDescendant (x => x.ByName ("Work offsets")).AsButton ()!.Click ();
         Thread.Sleep (500);
         var expectedcapture = Capture.Rectangle (new Rectangle (7, 44, 1176, 117));
         expectedcapture.ToFile (@"C:\Work\Temp\S1currentvalue.png");
         Thread.Sleep (300);
         Assert.AreBitmapsEqual (@"C:\Work\S1actualvalue.png", @"C:\Work\S1currentvalue.png",90);
      }

      public static Window win;
   }
      #endregion
}
   #endregion
