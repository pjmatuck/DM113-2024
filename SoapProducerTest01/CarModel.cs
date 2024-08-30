using System.Runtime.Serialization;

namespace SoapCar {
    [DataContract]
    public class CarModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string HorsePower {get; set; }
    }
}