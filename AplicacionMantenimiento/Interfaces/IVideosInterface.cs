using AplicacionMantenimiento.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionMantenimiento.Interfaces
{
    public interface IVideosInterface
    {
        List<Video> obtenerVideos();
        Video LeerVideo(int id);
        void crearVideo(Video videoNuevo);
        void editarVideo(Video videoEditar);
        void eliminarVideo(int id);
    }
}
