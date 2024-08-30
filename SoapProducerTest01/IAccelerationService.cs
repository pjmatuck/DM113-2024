using System.ServiceModel;
namespace SoapCar {
    [ServiceContract]
    public interface IAccelerationService
    {
        [OperationContract]
        string Speed(string s);
        //[OperationContract]
        //void XmlMethod(System.Xml.Linq.XElement xml);
        [OperationContract]
        CarModel TestCar(CarModel car);
    }
}