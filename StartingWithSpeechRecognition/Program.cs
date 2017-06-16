using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Runtime.InteropServices;
using System.IO;
using System.Net;
using System.Net.Sockets;

//Tauheed


namespace StartingWithSpeechRecognition
{
    class Program
    {
        static SpeechRecognitionEngine _recognizer = null;
        static ManualResetEvent manualResetEvent = null;
        static TcpClient tcpclnt;
        static void Main(string[] args)
        {
            tcpclnt = new TcpClient();
            Console.WriteLine("Connecting.....\n");
            tcpclnt.Connect("127.0.0.1", 12345);
            Console.WriteLine("Connected\n");
            manualResetEvent = new ManualResetEvent(false);
            Console.WriteLine("To recognize speech using a DictationGrammar, press 1");
            ConsoleKeyInfo pressedKey = Console.ReadKey(true);
            char keychar = pressedKey.KeyChar;
            Console.WriteLine("You pressed '{0}'", keychar);
            switch (keychar)
            {
                case '1':
                    SpeechRecognitionWithDictationGrammar();


                    break;
                default:
                    Console.WriteLine("You didn't press 1");
                    Console.WriteLine("Press any key to continue . . .");
                    Console.ReadKey(true);
                    Environment.Exit(0);
                    break;
            }
            if (keychar != '5')
            {
                manualResetEvent.WaitOne();
            }
            if (_recognizer != null)
            {
                _recognizer.Dispose();
            }

            Console.WriteLine("Press any key to continue . . .");
            Console.ReadKey(true);
        }
  
        #region Speech recognition with DictationGrammar
        static void SpeechRecognitionWithDictationGrammar()
        {
            _recognizer = new SpeechRecognitionEngine();
            _recognizer.LoadGrammar(new Grammar(new GrammarBuilder("exit")));
            _recognizer.LoadGrammar(new DictationGrammar());
            _recognizer.SpeechRecognized += speechRecognitionWithDictationGrammar_SpeechRecognized;
            _recognizer.SetInputToDefaultAudioDevice();
            _recognizer.RecognizeAsync(RecognizeMode.Multiple);
        }

        static void speechRecognitionWithDictationGrammar_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            if (e.Result.Text == "exit")
            {
                manualResetEvent.Set();
                return;
            }


            Console.WriteLine("You said: " + e.Result.Text);
            String str = e.Result.Text;
            Stream stm = tcpclnt.GetStream();

            ASCIIEncoding asen = new ASCIIEncoding();
            byte[] ba;


            //stm.Close();

           if (e.Result.Text.Equals("Move Right") || 
                e.Result.Text.Equals("Moved Right") ||
                e.Result.Text.Equals("knee right") ||
                e.Result.Text.Equals("move the night") ||
                e.Result.Text.Equals("knee site") ||
                e.Result.Text.Equals("will the night") ||
                e.Result.Text.Equals("in the right") ||
                e.Result.Text.Equals("You might") ||
                e.Result.Text.Equals("knee and right") ||
                e.Result.Text.Equals("Overwrite") ||
                e.Result.Text.Equals("override") ||
                e.Result.Text.Equals("move right"))
            {
                ba = asen.GetBytes("Move Right");
                Console.WriteLine("Transmitting.....");
                Console.WriteLine("You said: Move Right");
                stm.Write(ba, 0, ba.Length);
            }
            if (e.Result.Text.Equals("You'll get") ||
                e.Result.Text.Equals("more left") ||
                e.Result.Text.Equals("move left") ||
                e.Result.Text.Equals("mole left") ||
                e.Result.Text.Equals("move death") ||
                e.Result.Text.Equals("mold if") ||
                e.Result.Text.Equals("no left") ||
                e.Result.Text.Equals("the old left") ||
                e.Result.Text.Equals("move left") ||
                e.Result.Text.Equals("movie if") ||
                e.Result.Text.Equals("you'll see if") ||
                e.Result.Text.Equals("movie if") ||
                e.Result.Text.Equals("you'll be if") ||
                e.Result.Text.Equals("move left") ||
                e.Result.Text.Equals("no lift") ||
                e.Result.Text.Equals("below left") ||
                e.Result.Text.Equals("no left") ||
                e.Result.Text.Equals("movie if") ||
                e.Result.Text.Equals("old left") ||
                e.Result.Text.Equals("no left") ||
                e.Result.Text.Equals("more than if") ||
                e.Result.Text.Equals("Dole left") ||
                e.Result.Text.Equals("You'll death") ||
                e.Result.Text.Equals("knell death") ||
                e.Result.Text.Equals("move the death") ||
                e.Result.Text.Equals("you lift    ") ||
                e.Result.Text.Equals("move death  ") ||
                e.Result.Text.Equals("you'll give ") ||
                e.Result.Text.Equals("You'll be left") ||
                e.Result.Text.Equals("in the old left") ||
                e.Result.Text.Equals("you left") ||
                e.Result.Text.Equals("no death") ||
                e.Result.Text.Equals("mold F") ||
                e.Result.Text.Equals("Moulds left") ||
                e.Result.Text.Equals("you left") ||
                e.Result.Text.Equals("your left") ||
                e.Result.Text.Equals("More than if") ||
                e.Result.Text.Equals("know if") ||
                e.Result.Text.Equals("you'll give") ||
                e.Result.Text.Equals("move that if") ||
                e.Result.Text.Equals("you lift") ||
                e.Result.Text.Equals("will lift") ||
                e.Result.Text.Equals("you'll let") ||
                e.Result.Text.Equals("you know that if") ||
                e.Result.Text.Equals("you're left") ||
                e.Result.Text.Equals("He left") ||
                e.Result.Text.Equals("knee and left") ||
                e.Result.Text.Equals("knee and left") ||
                e.Result.Text.Equals("you'll left") ||
                e.Result.Text.Equals("null death") ||
                e.Result.Text.Equals("toll that if") ||
                e.Result.Text.Equals("you'll left") ||
                e.Result.Text.Equals("no death"))
            {
                ba = asen.GetBytes("Move Left");
                Console.WriteLine("Transmitting.....");
                Console.WriteLine("You said: Move Left");
                stm.Write(ba, 0, ba.Length);
            }
            if (e.Result.Text.Equals("Move Up") ||
                e.Result.Text.Equals("Move up") ||
                e.Result.Text.Equals("more up") ||
                e.Result.Text.Equals("the live up") ||
                e.Result.Text.Equals("moved up") ||
                e.Result.Text.Equals("hold up") ||
                e.Result.Text.Equals("war of") ||
                e.Result.Text.Equals("one of") ||
                e.Result.Text.Equals("rows of") ||
                e.Result.Text.Equals("rules of") ||
                e.Result.Text.Equals("war of") ||
                e.Result.Text.Equals("warm up") ||
                e.Result.Text.Equals("move up") )
            {
                ba = asen.GetBytes("Move Up");
                Console.WriteLine("Transmitting.....");
                Console.WriteLine("You said: Move Up");
                stm.Write(ba, 0, ba.Length);
            }
            if (e.Result.Text.Equals("Move Down") ||
                e.Result.Text.Equals("You don't") ||
                e.Result.Text.Equals("need go") ||
                e.Result.Text.Equals("no go") ||
                e.Result.Text.Equals("and go") ||
                e.Result.Text.Equals("man go") ||
                e.Result.Text.Equals("been billed") ||
                e.Result.Text.Equals("moved all") ||
                e.Result.Text.Equals("you don't") ||
                e.Result.Text.Equals("know don't") ||
                e.Result.Text.Equals("move go") ||
                e.Result.Text.Equals("need down") ||
                e.Result.Text.Equals("the old don't") ||
                e.Result.Text.Equals("move down") ||
                e.Result.Text.Equals("being held") ||
                e.Result.Text.Equals("you don't") ||
                e.Result.Text.Equals("move down") ||
                e.Result.Text.Equals("been down") ||
                e.Result.Text.Equals("You'll go") ||
                e.Result.Text.Equals("you'll go") ||
                e.Result.Text.Equals("moved down") ||
                e.Result.Text.Equals("north dome") ||
                e.Result.Text.Equals("you go") ||
                e.Result.Text.Equals("moved oh") ||
                e.Result.Text.Equals("will go") ||
                e.Result.Text.Equals("blow down") ||
                e.Result.Text.Equals("the dow"))
            {
                ba = asen.GetBytes("Move Down");
                Console.WriteLine("Transmitting.....");
                Console.WriteLine("You said: Move Down");
                stm.Write(ba, 0, ba.Length);
            }
            if (e.Result.Text.Equals("move gripper") ||
                e.Result.Text.Equals("Move gripper") ||
                e.Result.Text.Equals("The move gripper")
                )
            {
                ba = asen.GetBytes("Move Gripper");
                Console.WriteLine("Transmitting.....");
                stm.Write(ba, 0, ba.Length);
            }

        }
        #endregion
    }
}
