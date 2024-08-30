using System.Runtime.Serialization;

namespace MediaNotasSoapService.Models
{
    [DataContract]
    public class Prova
    {
        [DataMember]
        public string Materia { get; set; }
        [DataMember]
        public float Nota { get; set; }
    }
}
