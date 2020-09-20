using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1.Logica
{
    public class AnalizadorLexico
    {
        byte[] charAnalizar;
        private ManejadorCodigo manejador;
        private EditorCodigo editor;
        private Automata automata;
        int estadoActual = 0;
        int columnaAutomata = 0;
        int apuntadorTexto = 0;
        int ultimoEstadoAceptado = 0;
        String auxTokenAceptado = "";
        String auxCadenaMomentanea = "";
        String auxRutaToken = "";

        public AnalizadorLexico(byte[] charAnalizar,ManejadorCodigo manejador,EditorCodigo editor)
        {
            this.charAnalizar = charAnalizar;
            this.manejador = manejador;
            this.editor = editor;
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
                if (estadoActual == 0 && columnaAutomata==21)
                {
                    estadoActual = 0;
                    ultimoEstadoAceptado = 0;
                    auxTokenAceptado = "";
                    auxCadenaMomentanea = "";
                    auxRutaToken = "";
                    apuntadorTexto++;
                }
                else if(estadoActual==13 && charActual==10){
                    //pasar para analizar el siguiente char, y devolver la cadena valida
                    asignarColor(i, Color.Red);
                    estadoActual = 0;
                    ultimoEstadoAceptado = 0;
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
                            Color color;
                            if (estadoActual==5||estadoActual==8)
                            {
                                color = automata.devolverColorPorRuta(auxRutaToken);
                            }
                            else
                            {
                                color = automata.devolverColorPorEstado(estadoActual,auxTokenAceptado);
                            }
                            asignarColor(i, color);
                            i--;
                        }                        
                        else
                        {
                            //si no hay cadena aceptada
                            if (estadoActual==0)
                            {
                                //el token erroneo es el entrante
                                asignarColor(i+1, Color.Red);
                            }
                            else
                            {
                                if (auxTokenAceptado.Length>0)
                                {
                                    Color color;
                                    if (ultimoEstadoAceptado==5||ultimoEstadoAceptado==8)
                                    {
                                        color = automata.devolverColorPorRuta(auxRutaToken);
                                    }
                                    else
                                    {
                                        color = automata.devolverColorPorEstado(ultimoEstadoAceptado, auxTokenAceptado);
                                    }
                                    asignarColor(i - 1, color);
                                    asignarColor(i, Color.Red);
                                }
                                else
                                {
                                    asignarColor(i+1,Color.Red);
                                }
                            }
                        }
                        estadoActual = 0;
                        ultimoEstadoAceptado = 0;
                        auxTokenAceptado = "";
                        auxCadenaMomentanea = "";
                        auxRutaToken = "";
                    }
                    else
                    {
                        String cadenaTransicion = Char.ToString((char)charActual);

                        //concatenar la cadena momentanea y proseguir al siguiente
                        auxCadenaMomentanea += cadenaTransicion;
                        if (automata.esEstadoAceptacion(transicion))
                        {
                            auxTokenAceptado = auxCadenaMomentanea;
                            ultimoEstadoAceptado = transicion;
                        }

                        if (estadoActual == 0)
                        {
                            auxRutaToken = columnaAutomata + "-" + transicion;
                        }
                        else
                        {
                            if (estadoActual!=transicion)
                            {
                                auxRutaToken += "," + columnaAutomata + "-" + transicion;
                            }                           
                        }

                        //Para el siguiente char, nos pasamos al siguiente estado
                        estadoActual = transicion;
                    }
                }


            }

            //verificamos si terminamos en un estado de aceptacion, sino se devuelve la parte erronea.
        }

        public void asignarColor(int indiceCiclo, Color colorTexto)
        {
            System.Windows.Forms.RichTextBox ingresoCodigoRich = editor.GetRichTextBox();
            int index = ingresoCodigoRich.SelectionStart;

            ingresoCodigoRich.Select(apuntadorTexto,indiceCiclo);
            ingresoCodigoRich.SelectionColor = colorTexto;

            ingresoCodigoRich.SelectionStart = index;
            ingresoCodigoRich.SelectionLength = 0;
            editor.setRichTextBox(ingresoCodigoRich);

            apuntadorTexto = indiceCiclo;
        }
    }
}
/* Lo primero es buscar que tipo de char es con su columna
 * segundo buscar su transicion
 */
