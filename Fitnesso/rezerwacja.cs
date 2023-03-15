using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fitnesso
{
    public class Rezerwacja
    {
        int idRezerwacji;
        int idKonta;
        int idZajec;
        int idPlatnosci;
        DateTime dataRezerwacji;
        string statusRezerwacji;
        Boolean czyOplacona;
        string platnosc;
        konto konto;
        platnosc platnosc;
    }
}