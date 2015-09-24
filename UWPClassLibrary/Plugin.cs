using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//Everything Windows 10 specific has to be handled with compiler directives
#if NETFX_CORE
using System.Threading.Tasks;
using Windows.Devices.Gpio;
using Windows.Devices;
#endif
namespace UWPClassLibrary
{

     public class Plugin
    {
        //store status information and make it displayable within Unity
        public string status;
#if NETFX_CORE
        public GpioPin pin;
#endif
        //just a little check that the plugin is called.
        public string ExportedMethod()
        {
            return "Plugin included correctly!";
        }
        public bool InitGPIO()
        {
            //compiler directive to check whether it's running on the correct system.
#if NETFX_CORE
            var gpio = GpioController.GetDefault();
            if (gpio == null)
            {
                pin = null;
                status = "There is no GPIO controller on this device";
                return false;
            }
            
            //If you have an LED on pin 2 - otherwise change the number
            pin = gpio.OpenPin(2);

            //make sure the pin has been initialised correctly
            if (pin == null)
            {
                status = "There was a problem initialising the GPIO Pin";
                return false;
            }

            pin.Write(GpioPinValue.High);
            pin.SetDriveMode(GpioPinDriveMode.Output);
            status = "GPIO pin is set correctly";
            return true;
           
#else
        status = "NO GPIO Hardware";   
            return true;   
#endif
        }
        //turn on the LED
        public bool SwitchON()
        {
#if NETFX_CORE
            this.pin.Write(GpioPinValue.High);
            status = "on";
#endif
            return true;
        }
        //turn off the LED again.
        public bool SwitchOFF()
        {
#if NETFX_CORE
            this.pin.Write(GpioPinValue.Low);
            status = "Off";
#endif
            return true;

        }
    }


}
