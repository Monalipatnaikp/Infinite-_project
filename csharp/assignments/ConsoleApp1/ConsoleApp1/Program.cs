using System;

namespace MobilePhoneNotification
{
    
    class MobilePhone
    {
        
        public delegate void RingEventHandler();

        public event RingEventHandler OnRing;

        
        public void ReceiveCall()
        {
            Console.WriteLine("\n Incoming Call");
            OnRing?.Invoke(); 
        }
    }

    
    class RingtonePlayer
    {
        public void PlayRingtone()
        {
            Console.WriteLine("Playing ringtone");
        }
    }

    
    class ScreenDisplay
    {
        public void ShowCallerInfo()
        {
            Console.WriteLine(" Displaying caller information");
        }
    }

    
    class VibrationMotor
    {
        public void Vibrate()
        {
            Console.WriteLine("Phone is vibrating");
        }
    }

    
    class Program
    {
        static void Main(string[] args)
        {
            
            MobilePhone phone = new MobilePhone();
            RingtonePlayer ringtone = new RingtonePlayer();
            ScreenDisplay display = new ScreenDisplay();
            VibrationMotor vibration = new VibrationMotor();
            phone.OnRing += ringtone.PlayRingtone;
            phone.OnRing += display.ShowCallerInfo;
            phone.OnRing += vibration.Vibrate;

            while (true)
            {
                
                string input = Console.ReadLine()?.Trim().ToLower();

                if (input == "call")
                {
                    phone.ReceiveCall();
                }
                else if (input == "exit")
                {
                    Console.WriteLine(" Exit");
                    break;
                }
                else
                {
                    Console.WriteLine(" Invalid input");
                    Console.ReadLine();
                }
            }
        }
    }
}