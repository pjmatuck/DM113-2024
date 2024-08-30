using MediaNotasSoapService.Models;
using System.ServiceModel;

namespace MediaNotasSoapService.Services
{
    [ServiceContract]
    public interface IMediaService
    {
        [OperationContract]
        public float CalcularMedia(float nota1, float nota2);
        [OperationContract]
        public Prova GetProva(string nomeDaMateria);
    }
}
