using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1.Logica
{
    class Automata
    {
        private int[,] tablaTransiciones = new int[17, 22];
        private List<int> estadosAceptacion;

        public Automata()
        {
            llenarTabla();
            setearTransiciones();
            setearEstadosAceptacion();
            estadosAceptacion = new List<int>();
        }

        private void llenarTabla()
        {
            for (int i = 0; i < tablaTransiciones.GetLength(0); i++)
            {
                for (int j = 0; j < tablaTransiciones.GetLength(1); j++)
                {
                    tablaTransiciones[i, j] = -1;
                }
            }
        }

        private void setearTransiciones()
        {
            //Transiciones desde el estado 0
            tablaTransiciones[0, 0] = 1;
            tablaTransiciones[0, 1] = 7;
            tablaTransiciones[0, 2] = 6;
            tablaTransiciones[0, 3] = 5;
            tablaTransiciones[0, 4] = 4;
            tablaTransiciones[0, 6] = 2;
            tablaTransiciones[0, 7] = 3;
            tablaTransiciones[0, 8] = 8;
            tablaTransiciones[0, 9] = 8;
            tablaTransiciones[0, 10] = 8;
            tablaTransiciones[0, 11] = 8;
            tablaTransiciones[0, 12] = 9;
            tablaTransiciones[0, 13] = 10;
            tablaTransiciones[0, 14] = 5;
            tablaTransiciones[0, 15] = 5;
            tablaTransiciones[0, 16] = 5;

            //Transiciones desde el estado 1
            tablaTransiciones[1, 0] = 5;
            tablaTransiciones[1, 6] = 2;

            //Transiciones desde el estado 2
            tablaTransiciones[2, 6] = 2;
            tablaTransiciones[2, 17] = 11;

            //Transiciones desde el estado 3
            tablaTransiciones[3, 7] = 5;
            tablaTransiciones[3, 18] = 3;
            tablaTransiciones[3, 21] = 3;

            //Transiciones desde el estado 4
            tablaTransiciones[4, 4] = 12;
            tablaTransiciones[4, 5] = 12;

            //Transiciones desde el estado 6
            tablaTransiciones[6, 2] = 13;
            tablaTransiciones[6, 3] = 14;

            //Transiciones desde el estado 7
            tablaTransiciones[7, 1] = 5;

            //Transiciones desde el estado 8
            tablaTransiciones[8, 10] = 5;

            //Transiciones desde el estado 9
            tablaTransiciones[9, 12] = 5;

            //Transiciones desde el estado 10
            tablaTransiciones[10, 13] = 5;

            //Transiciones desde el estado 11
            tablaTransiciones[11, 6] = 15;

            //Transiciones desde el estado 12
            tablaTransiciones[12, 4] = 12;
            tablaTransiciones[12, 5] = 12;

            //Transiciones desde el estado 13
            tablaTransiciones[13, 18] = 13;
            tablaTransiciones[13, 19] = 13;
            tablaTransiciones[13, 20] = 13;

            //Transiciones desde el estado 14
            tablaTransiciones[14, 3] = 16;
            tablaTransiciones[14, 18] = 14;
            tablaTransiciones[14, 21] = 14;

            //Transiciones desde el estado 15
            tablaTransiciones[15, 6] = 15;

            //Transiciones desde el estado 16
            tablaTransiciones[16, 2] = 5;
        }

        private void setearEstadosAceptacion()
        {
            estadosAceptacion.Add(1);
            estadosAceptacion.Add(2);
            estadosAceptacion.Add(4);
            estadosAceptacion.Add(5);
            estadosAceptacion.Add(6);
            estadosAceptacion.Add(7);
            estadosAceptacion.Add(8);
            estadosAceptacion.Add(12);
            estadosAceptacion.Add(13);
            estadosAceptacion.Add(15);
            estadosAceptacion.Add(16);

        }

        public Boolean estadoAceptacion(int estadoActual)
        {
            if (estadosAceptacion.Contains(estadoActual))
            {
                return true;
            }

            return false;
        }

        public int devolverColumna(int codigoASCCI)
        {
            if (codigoASCCI==45)
            {
                //Signo menos
                return 0;
            }
            else if (codigoASCCI==43)
            {
                //Signo mas
                return 1;
            }
            else if (codigoASCCI == 47)
            {
                return 2;
                //barra inclinada
            }
            else if (codigoASCCI == 42)
            {
                return 3;
                //asterisco
            }
            else if ((codigoASCCI >= 65 && codigoASCCI <= 90) ||( codigoASCCI>= 97 && codigoASCCI<= 122)
                || codigoASCCI>= 160 && codigoASCCI<= 165 || codigoASCCI==130 || codigoASCCI == 181
                || codigoASCCI == 144 || codigoASCCI == 214 || codigoASCCI==224 || codigoASCCI==233)
            {
                //cualquier letra
                return 4;
            }
            else if (codigoASCCI == 95)
            {
                //guion bajo
                return 5;
            }
            else if (codigoASCCI >=48 && codigoASCCI<= 57)
            {
                //numero
                return 6;
            }
            else if (codigoASCCI == 34)
            {
                //comillas dobles
                return 7;
            }
            else if (codigoASCCI == 62)
            {
                //mayor que
                return 8;
            }
            else if (codigoASCCI == 60)
            {
                //menor que
                return 9;
            }
            else if (codigoASCCI == 61)
            {
                //igual
                return 10;
            }
            else if (codigoASCCI == 33)
            {
                //signo admiracion
                return 11;
            }
            else if (codigoASCCI == 124)
            {
                //barra vertical
                return 12;
            }
            else if (codigoASCCI == 38)
            {
                //ampersand o signo de &
                return 13;
            }
            else if (codigoASCCI == 59)
            {
                //punto y coma
                return 14;
            }
            else if (codigoASCCI == 40)
            {
                //abrir parentesis
                return 15;
            }
            else if (codigoASCCI == 41)
            {
                //cerrar parentesis
                return 16;
            }
            else if (codigoASCCI == 46)
            {
                //punto
                return 17;
            }
            else if ((codigoASCCI >= 33 && codigoASCCI<=126) || (codigoASCCI>= 128 && codigoASCCI<=253))
            {
                //cualquier char
                return 18;
            }
            else if (codigoASCCI == 9)
            {
                //tab
                return 19;
            }
            else if (codigoASCCI == 32)
            {
                //espacio
                return 20;
            }
            else if (codigoASCCI == 9|| codigoASCCI == 10 || codigoASCCI ==32)
            {
                //cualquier espacio en blanco
                return 21;
            }

            return -1;
        }

        public int retornarTransicion(int fila, int columna)
        {
            return tablaTransiciones[fila, columna];
        }
    }
}
