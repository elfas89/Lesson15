using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
//using System.Threading.Tasks;

namespace Lesson15
{
    class Fridge
    {
        private bool power;
        private FridgeModes mode;
        private string powerMess;

        public Fridge(bool power, FridgeModes mode)
        {
            this.power = power;
            this.mode = mode;
            this.powerMess = " ";
        }


        public void On()
        {

            if (!power)
            {
                power = true;
                mode = FridgeModes.normal;
                powerMess = " ";
                
            }


        }

        public void Off(object o)
        {
            if (power)
            {
                power = false;
                mode = FridgeModes.south;
                powerMess = "Холодильник выключен, продукты портятся!";
            }

        }


        public void Normal()
        {
            if (power)
            {
                mode = FridgeModes.normal;
            }
            else
            {
                powerMess = "Включите холодос!";
            }

        }

        public void North()
        {
            if (power)
            {
                mode = FridgeModes.north;
            }
            else
            {
                powerMess = "Включите холодос!";
            }
        }

        public void South()
        {
            if (power)
            {
                mode = FridgeModes.south;
            }
            else
            {
                powerMess = "Включите холодос!";
            }
        }


        public string Info()
        {
            string power;
            if (this.power)
            {
                power = "включен";
            }
            else
            {
                power = "выключен";
            }

            string mode;
            if (this.mode == FridgeModes.normal)
            {
                mode = "нормальный";
            }
            else if (this.mode == FridgeModes.north)
            {
                mode = "заморозки к чертям";
            }
            else
            {
                mode = "разморозки к лужам";
            }

            return "Состояние холодильника: " + power + ", режим: " + mode + "\n" + powerMess;
        }

    }
}
