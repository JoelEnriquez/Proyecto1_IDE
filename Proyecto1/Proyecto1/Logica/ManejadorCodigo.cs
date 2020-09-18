using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Proyecto1.Logica
{
    public class ManejadorCodigo
    {
        String codigoAnalizar;
        String codigoAnalizado;
        AnalizadorLexico analizador;

        public void ejecutarManejador()
        {
            byte[] asciiBytes = Encoding.ASCII.GetBytes(codigoAnalizar);
            analizador = new AnalizadorLexico(asciiBytes);
            analizador.ejecutarAnalizador();
        }

        public void recibirCodigo(String codigoAnalizar)
        {
            this.codigoAnalizar = codigoAnalizar;
        }

        public void agregarCodigo(String token)
        {
            codigoAnalizado += token;
        }



        public void pruebaCodigo()
        {
            byte[] asciiBytes = Encoding.ASCII.GetBytes(codigoAnalizar);

            for (int i = 0; i < asciiBytes.Length; i++)
            {
                //Console.WriteLine(asciiBytes[i]);
                if (asciiBytes[i] == 9)
                {
                    //MessageBox.Show("tab", "", MessageBoxButton.OK);
                    //Console.WriteLine(Char.ConvertToUtf32(codigoAnalizar, i));
                }
                else if (asciiBytes[i] == 10)
                {
                    //MessageBox.Show("salto de linea", "", MessageBoxButton.OK);
                }
                else if (asciiBytes[i] == 32)
                {
                    // MessageBox.Show("espacio", "", MessageBoxButton.OK);
                }

            }
        } 
        
    }
}
