using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Writer.Helper
{
    public class WriterHelper
    {
        public string UnosZaDumping()
        {
            string message = DateTime.Now.ToString();
            message += "+";




            string code = "-1";

            while (code != "0" && code != "1" && code != "2" && code != "3" && code != "4" && code != "5" && code != "6" && code != "7" && code != "8" && code != "9")
            {

                Console.WriteLine("0. CODE_ANALOG\n");
                Console.WriteLine("1. CODE_DIGITAL\n");
                Console.WriteLine("2. CODE_CUSTOM\n");
                Console.WriteLine("3. CODE_LIMITSET\n");
                Console.WriteLine("4. CODE_SINGLENODE\n");
                Console.WriteLine("5. CODE_MULTIPLENODE\n");
                Console.WriteLine("6. CODE_CONSUMER\n");
                Console.WriteLine("7. CODE_SOURCE\n");
                Console.WriteLine("8. CODE_MOTION\n");
                Console.WriteLine("9. CODE_SENSOR\n");
                Console.WriteLine("Please select code:");
                code = Console.ReadLine();
            }

            message += code;
            message += "+";
            string geoId = "";
            int geooId;
            bool isNumber = false;
            do
            {
                Console.WriteLine("Please enter Geographical ID:\n");
                isNumber = false;
                try
                {
                    geooId = Int32.Parse(Console.ReadLine());
                    geoId = geooId.ToString();
                }
                catch (Exception)
                {

                    isNumber = true;
                }

            } while (isNumber == true);


            message += geoId;



            string consumption = "";
            isNumber = false;
            do
            {
                Console.WriteLine("Please enter number of consumpted mW/H:\n");
                isNumber = false;
                try
                {
                    consumption = Console.ReadLine();

                }
                catch (Exception)
                {
                    isNumber = true;
                }

            } while (isNumber == true);

            message += "+";
            message += consumption;

            return message;
        }

    }
}
