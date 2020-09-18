using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1.Logica
{
    public class AnalizadorLexico
    {
        byte[] charAnalizar;
        Automata automata;
        int estadoActual = 0;

        public AnalizadorLexico(byte[] charAnalizar)
        {
            this.charAnalizar = charAnalizar;
            automata = new Automata();
        }

        public void ejecutarAnalizador()
        {
            for (int i = 0; i < charAnalizar.Length; i++)
            {
                int charActual = charAnalizar[i];
                int columnaAutomata = automata.devolverColumna(charActual);

                int transicion = automata.retornarTransicion(estadoActual, columnaAutomata);
            }
        }
    }
}
/* Lo primero es buscar que tipo de char es con su columna
 * segundo buscar su transicion
 */