using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenHardwareMonitor.Hardware;
namespace CPUTemp2
{
    class Program
    {
        public class UpdateVisitor : IVisitor
        {
            public void VisitComputer(IComputer computer)
            {
                computer.Traverse(this);
            }
            public void VisitHardware(IHardware hardware)
            {
                hardware.Update();
                foreach (IHardware subHardware in hardware.SubHardware) subHardware.Accept(this);
            }
            public void VisitSensor(ISensor sensor) { }
            public void VisitParameter(IParameter parameter) { }
        }
        //static IEnumerable<string> GetSystemInfo(string device)
        //just adding new text to implement the commit to git hub
        static void GetSystemInfo()
        {
            UpdateVisitor updateVisitor = new UpdateVisitor();
            Computer computer = new Computer();
            var output = new List<string>();

            computer.Open();
            computer.CPUEnabled = true;
            computer.GPUEnabled = true;
            computer.FanControllerEnabled = true;
            computer.HDDEnabled = true;
            computer.MainboardEnabled = true;
            computer.RAMEnabled = true;

            computer.Accept(updateVisitor);
            for (int i = 0; i < computer.Hardware.Length; i++)
            {
                // iterate through the computer.hardware
                //Console.WriteLine($"Hello, {name}! Today is {date.DayOfWeek}, it's {date:HH:mm} now.");
                Console.WriteLine($"Name: {computer.Hardware[i].Name}, Type: {computer.Hardware[i].HardwareType}");
                Console.WriteLine();
                //if (computer.Hardware[i].HardwareType == HardwareType.CPU)
                //{
                for (int j = 0; j < computer.Hardware[i].Sensors.Length; j++)
                {
                    
                Console.WriteLine($"Name: {computer.Hardware[i].Sensors[j].Name}, Type: {computer.Hardware[i].Sensors[j].SensorType}, Value: {computer.Hardware[i].Sensors[j].Value}");

                    //if (computer.Hardware[i].Sensors[j].SensorType == SensorType.Temperature)
                    //    Console.WriteLine(computer.Hardware[i].Sensors[j].Name + ":" + computer.Hardware[i].Sensors[j].Value.ToString() + "\r");
                }
                //}
            }
            computer.Close();
            Console.ReadLine();
            //return new string[] { "1","2" };
        }
        static void Main(string[] args)
        {
            GetSystemInfo();
            //while (true)
            //{
            //    GetSystemInfo();
            //}
        }
    }
}