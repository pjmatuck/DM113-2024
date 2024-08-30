using System.Xml.Linq;
using SoapCar;

public class AccelerationService : IAccelerationService
{
    public string Speed(string s)
    {
        System.Console.WriteLine($"{s} MPH");
        return s;
    }

    public CarModel TestCar(CarModel car)
    {
        return car;
    }

    /*public void XmlMethod(XElement xml)
    {
        System.Console.WriteLine(xml.ToString());
    }*/
}