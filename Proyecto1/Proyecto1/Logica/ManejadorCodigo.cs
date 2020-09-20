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
        private String codigoAnalizar;
        private String codigoAnalizado;
        private AnalizadorLexico analizador;
        private EditorCodigo editor;
        private List<String> tokensInvalidos;

        public ManejadorCodigo(EditorCodigo editor)
        {
            this.editor = editor;
            tokensInvalidos = new List<String>();
        }

        public void ejecutarManejador()
        {
            if (tokensInvalidos!=null)
            {
                tokensInvalidos.Clear();
            }
            byte[] asciiBytes = Encoding.ASCII.GetBytes(codigoAnalizar);
            analizador = new AnalizadorLexico(asciiBytes,this,editor);
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

        public void agregarTokenErroneo(String token)
        {
            tokensInvalidos.Add(token);
        }

        
    }
}
