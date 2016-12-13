using AplicacionMantenimiento.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionMantenimiento.Interfaces
{
    public interface IAlquilerInterface
    {
        Boolean alquilarVideo(Alquiler alquiler);
        Boolean verificarVideo(Alquiler alquiler);
        List<Video> getPeliculaByUser(string userId);
        List<Video> getPeliculaByMembresia(string membresia);
        List<Video> getPeliculaByTipo(string tipo);
    }
}
