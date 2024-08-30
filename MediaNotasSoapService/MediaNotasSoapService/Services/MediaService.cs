using MediaNotasSoapService.Models;

namespace MediaNotasSoapService.Services
{
    public class MediaService : IMediaService
    {
        public float CalcularMedia(float nota1, float nota2)
        {
            return (nota1 + nota2) / 2;
        }

        public Prova GetProva(string nomeDaMateria)
        {
            switch(nomeDaMateria)
            {
                case "Matematica":
                    return new Prova { Materia = "Matematica", Nota = 40 };
                case "Portugues":
                    return new Prova { Materia = "Portugues", Nota = 55 };
                default:
                    return new Prova { Materia = "NA", Nota = 0 };
            }
        }
    }
}
