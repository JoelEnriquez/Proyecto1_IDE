using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto1.Logica
{
    public class AnalizadorLexico
    {
        private byte[] charAnalizar;
        private ManejadorCodigo manejador;
        private EditorCodigo editor;
        private Automata automata;
        private int estadoActual = 0;
        private int columnaAutomata = 0;
        private int apuntadorTexto = 0;
        private String auxTokenAceptado = "";
        private String auxCadenaMomentanea = "";
        private String auxRutaToken = "";
        private String palabraReservadaFalloAux = "";
        private RichTextBox ingresoCodigoRich;

        public AnalizadorLexico(byte[] charAnalizar, ManejadorCodigo manejador, EditorCodigo editor)
        {
            this.charAnalizar = charAnalizar;
            this.manejador = manejador;
            this.editor = editor;
            this.ingresoCodigoRich = editor.GetRichTextBox();
            automata = new Automata();
        }

        public void ejecutarAnalizador()
        {
            for (int i = 0; i < charAnalizar.Length; i++)
            {
                int charActual = charAnalizar[i];

                if (estadoActual == 3)
                {
                    //verificar si viene comillas, sino que vendra cualquier caracter o cualquier espacio
                    columnaAutomata = automata.sonComillas(charActual);
                    if (columnaAutomata == -1)
                    {
                        if (automata.comprobarCharOEspacioBlanco(charActual) == 18)
                        {
                            columnaAutomata = 18;
                        }
                        else
                        {
                            columnaAutomata = 21;
                        }
                    }
                }
                else if (estadoActual == 13)
                {
                    //verificar si viene un tab, espacio, o un char, sino viene un salto de linea
                    columnaAutomata = automata.comprobarCharOEspacioBlanco(charActual);
                }
                else if (estadoActual == 14)
                {
                    //verificar si viene un *(asterisco), sino que venga cualquier char o espacio
                    columnaAutomata = automata.comprobarAstericoCharEspacio(charActual);
                }
                else
                {
                    columnaAutomata = automata.devolverColumna(charActual); //Se obtiene la columna correspondiente al char
                }

                //Si estamos en el estado 0 y viene un wspace, hacer caso omiso.
                if (estadoActual == 0 && columnaAutomata == 21)
                {
                    estadoActual = 0;
                    auxTokenAceptado = "";
                    auxCadenaMomentanea = "";
                    auxRutaToken = "";
                    apuntadorTexto++;
                }
                else if (estadoActual == 13 && charActual == 10)
                {
                    //pasar para analizar el siguiente char, y devolver la cadena valida
                    asignarColor(i, Color.Red);
                    estadoActual = 0;
                    auxTokenAceptado = "";
                    auxCadenaMomentanea = "";
                    auxRutaToken = "";
                }
                else
                {
                    int transicion = automata.retornarTransicion(estadoActual, columnaAutomata);
                    //verifiar si la nueva transicion nos dirige a un estado de aceptacion

                    if (transicion == -1) //No hay transicion valida
                    {
                        //retornar la ultima cadena valida
                        if (automata.esEstadoAceptacion(estadoActual))
                        {
                            apuntadorTexto = i;
                            //Se vuelve a analizar el char entrante
                            i--;
                        }
                        else
                        {
                            //si no hay cadena aceptada
                            if (estadoActual == 0)
                            {
                                //el token erroneo es el entrante
                                manejador.agregarTokenErroneo(Char.ToString((char)charActual));
                                asignarColor(i + 1, Color.OrangeRed);
                            }
                            else
                            {
                                //poner el token erroneo en rojo y se vuelve a analizar la cadena entrante
                                manejador.agregarTokenErroneo(auxCadenaMomentanea.Substring(auxTokenAceptado.Length));
                                apuntadorTexto = i - 1;
                                asignarColor(i, Color.OrangeRed);

                                apuntadorTexto = i;
                                i--;//Volver a analizar el token entrante   
                            }
                        }
                        estadoActual = 0;
                        auxTokenAceptado = "";
                        auxCadenaMomentanea = "";
                        auxRutaToken = "";
                        palabraReservadaFalloAux = "";
                    }
                    else
                    {
                        String cadenaTransicion = Char.ToString((char)charActual);

                        //Ruta del token para obtener luego el color si se llega a un estado de aceptacion
                        if (estadoActual == 0)
                        {
                            auxRutaToken = columnaAutomata + "-" + transicion;
                        }
                        else
                        {
                            if (estadoActual != transicion)
                            {
                                auxRutaToken += "," + columnaAutomata + "-" + transicion;
                            }
                        }

                        //concatenar la cadena momentanea y proseguir al siguiente
                        auxCadenaMomentanea += cadenaTransicion;
                        if (automata.esEstadoAceptacion(transicion))
                        {
                            auxTokenAceptado = auxCadenaMomentanea;

                            //pintar el token valido
                            Color color;
                            if (transicion == 5 || transicion == 8)
                            {
                                color = automata.devolverColorPorRuta(auxRutaToken);
                            }
                            else
                            {
                                color = automata.devolverColorPorEstado(transicion, auxTokenAceptado);
                                //es palabra reservada erronea
                                if (color == Color.OrangeRed)
                                {
                                    //nos asegurmos que no se repita la palabra reservada erronea
                                    if (!palabraReservadaFalloAux.Equals(""))
                                    {
                                        manejador.eliminarPalabraInicialRepetida(palabraReservadaFalloAux);

                                    }
                                    manejador.agregarTokenErroneo(auxTokenAceptado);
                                    palabraReservadaFalloAux = auxTokenAceptado;
                                }
                            }
                            asignarColor(i + 1, color);
                        }

                        //Para el siguiente char, nos pasamos al siguiente estado
                        estadoActual = transicion;
                    }
                }
            }

            ////se verifica si hay una cadena aux restante, de ser asi, es porque no esta en un estado de aceptacion

            if (!automata.esEstadoAceptacion(estadoActual))
            {
                apuntadorTexto = charAnalizar.Length - (auxCadenaMomentanea.Length - auxTokenAceptado.Length);
                asignarColor(charAnalizar.Length, Color.OrangeRed);

                manejador.agregarTokenErroneo(auxCadenaMomentanea.Substring(auxTokenAceptado.Length));
            }
        }

        public void asignarColor(int indiceCiclo, Color colorTexto)
        {
            int index = ingresoCodigoRich.SelectionStart;

            ingresoCodigoRich.Select(apuntadorTexto, indiceCiclo);
            ingresoCodigoRich.SelectionColor = colorTexto;

            //Volver a deseleccionar el texto que ya esta pintado
            ingresoCodigoRich.SelectionStart = index;
            ingresoCodigoRich.SelectionLength = 0;
        }
    }
}