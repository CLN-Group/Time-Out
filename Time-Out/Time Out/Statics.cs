using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeOut
{
    public class Estadisticas
    {
        int asistencias;
        int puntos;
        int rebotesOfensivos;
        int rebotesDefensivos;
        int robos;
        int faltas;

        #region Propiedades
        public int Asistencias
        {
            get { return asistencias; }
            set { asistencias = value; }
        }
        public int Puntos
        {
            get { return puntos; }
            set { puntos = value; }
        }
        public int RebotesOfensivos
        {
            get { return rebotesOfensivos; }
            set { rebotesOfensivos = value; }
        }
        public int RebotesDefensivos
        {
            get { return rebotesDefensivos; }
            set { rebotesDefensivos = value; }
        }
        public int Rebotes
        {
            get { return rebotesDefensivos + rebotesOfensivos; }
        }
        public int Robos
        {
            get { return robos; }
            set { robos = value; }
        }
        public int Faltas
        {
            get { return faltas; }
            set { faltas = value; }
        }
        #endregion

        public Estadisticas()
        {
            asistencias = 0;
            puntos = 0;
            rebotesOfensivos = 0;
            rebotesDefensivos = 0;
            robos = 0;
            faltas = 0;
        }
    }
}
